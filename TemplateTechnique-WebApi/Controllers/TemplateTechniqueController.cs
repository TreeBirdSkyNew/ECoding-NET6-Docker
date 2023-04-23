using _4___E_CODING_DAL.Models;
using AutoMapper;
using E_CODING_Service_Abstraction;
using E_CODING_Services;
using E_CODING_Services.Technique;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;

namespace TemplateTechnique_WebApi
{
    [Route("api/TemplateTechnique")]
    [ApiController]
    public class TemplateTechniqueController : ControllerBase
    {
        private readonly ITechniqueRepositoryWrapper _techniqueRepositoryWrapper;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        public TemplateTechniqueController(
            ILoggerManager logger,
            IMapper mapper ,
            ITechniqueRepositoryWrapper techniqueRepositoryWrapper)
        {
            _logger = logger;
            _mapper = mapper;
            _techniqueRepositoryWrapper = techniqueRepositoryWrapper;
        }

        [HttpGet]
        [Route("Index")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Index()
        {   
            try
            {
                IEnumerable<TemplateTechnique> templateTechniques = _techniqueRepositoryWrapper.TechniqueRepository.GetAllTemplateTechnique();
                _logger.LogInfo($"Returned all templateTechniques from database.");
                IEnumerable<TemplateTechniqueVM> templateTechniquesVM = _mapper.Map<IEnumerable<TemplateTechniqueVM>>(templateTechniques);
                return Ok(templateTechniquesVM);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateTechnique/Index action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("TechniqueAllItems")]
        public IActionResult TemplateTechniqueAllItems(int id)
        {
            try
            {
                IEnumerable<TemplateTechniqueItem> TemplateTechniqueAllItems = _techniqueRepositoryWrapper.TechniqueItemRepository.GetAllTemplateTechniqueItem(id);
                if (TemplateTechniqueAllItems.ToList().Count==0)
                {
                    _logger.LogError($"Returned TechniqueAllItems for TemplateTechniqueId={id} from database.");
                    return NotFound();
                }
                else
                { 
                    _logger.LogInfo($"Returned all TechniqueAllItems for TemplateTechniqueId={id} from database.");
                    IEnumerable<TemplateTechniqueItemVM> TemplateTechniqueAllItemsVM = _mapper.Map<List<TemplateTechniqueItemVM>>(TemplateTechniqueAllItems);
                    return Ok(TemplateTechniqueAllItemsVM);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateTechniqueItems for TemplateTechniqueId={id} action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "TemplateTechniqueById")]
        [Route("TechniqueDetails/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TemplateTechnique))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult TemplateTechniqueDetails(int id)
        {
            try
            {
                TemplateTechnique templateTechnique = _techniqueRepositoryWrapper.TechniqueRepository.FindByCondition(id);
                if (templateTechnique is null)
                {
                    _logger.LogError($"Returned templateTechnique for TemplateTechniqueId={id} from database.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned templateTechnique with TemplateTechniqueId: {id}");
                    List<TemplateTechniqueItem> templateTechniqueItems = _techniqueRepositoryWrapper.TechniqueItemRepository.GetAllTemplateTechniqueItem(id).ToList();
                    TemplateTechniqueVM templateTechniqueVM = _mapper.Map<TemplateTechniqueVM>(templateTechnique);
                    if (templateTechniqueItems.Any())
                    {
                        _logger.LogInfo($"Returned templateTechniqueItems with TemplateTechniqueId: {id}");
                        List<TemplateTechniqueItemVM> templateTechniqueItemsVM = _mapper.Map<List<TemplateTechniqueItemVM>>(templateTechniqueItems);
                        templateTechniqueVM.TemplateTechniqueItem = templateTechniqueItemsVM;
                    }
                    return Ok(templateTechniqueVM);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateTechniqueDetails for TemplateTechniqueId={id} action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
     
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CreateTechnique")]
        //[ValidateAntiForgeryToken]
        public IActionResult TemplateTechniqueCreate([FromBody] TemplateTechniqueVMForCreation templateTechniqueVM)
        {
            try
            {
                if (templateTechniqueVM is null)
                {
                    _logger.LogError("templateTechnique object sent from client is null.");
                    return BadRequest("templateTechnique object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid templateTechnique object sent from client.");
                    return BadRequest("Invalid model object");
                }
                TemplateTechnique templateTechniqueEntity = _mapper.Map<TemplateTechnique>(templateTechniqueVM);
                _techniqueRepositoryWrapper.TechniqueRepository.CreateTemplateTechnique(templateTechniqueEntity);
                _techniqueRepositoryWrapper.Save();
                var templateTechnique = _mapper.Map<TemplateTechniqueVM>(templateTechniqueEntity);
                return CreatedAtRoute("TemplateTechniqueById", new { id = templateTechnique.TemplateTechniqueId }, templateTechnique);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateTechniqueDetails for TemplateTechniqueId action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut("{id}")]
        [Route("EditTechnique/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult TemplateTechniqueEdit(int id, [FromBody] TemplateTechniqueVMForUpdate templateTechniqueVM)
        {
            try
            {
                if (templateTechniqueVM is null)
                {
                    _logger.LogError("templateTechnique object sent from client is null.");
                    return BadRequest("templateTechnique object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid templateTechnique object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var templateTechniqueEntity = _techniqueRepositoryWrapper.TechniqueRepository.FindByCondition(id);
                if (templateTechniqueEntity is null)
                {
                    _logger.LogError($"templateTechnique with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(templateTechniqueVM, templateTechniqueEntity);
                _techniqueRepositoryWrapper.TechniqueRepository.UpdateTemplateTechnique(templateTechniqueEntity);
                _techniqueRepositoryWrapper.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateTechniqueEdit for TemplateTechniqueId={id} action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [Route("DeleteTechnique/{id}")]
        [HttpDelete]
        public void DeleteTemplateTechnique(int id)
        {
            try
            {
                var templateTechnique = _techniqueRepositoryWrapper.TechniqueRepository.FindByCondition(id);
                if (templateTechnique == null)
                {
                    _logger.LogError($"templateTechnique with id: {id}, hasn't been found in db.");
                }
                if (_techniqueRepositoryWrapper.TechniqueItemRepository.GetAllTemplateTechniqueItem(id).Any())
                {
                    _logger.LogError($"Cannot delete owner with id: {id}. It has related accounts. Delete those accounts first");
                }
                _techniqueRepositoryWrapper.TechniqueRepository.DeleteTemplateTechnique(templateTechnique);
                _techniqueRepositoryWrapper.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteOwner action: {ex.Message}");
            }
        }

        [HttpGet("{id}", Name = "TemplateTechniqueItemById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("TechniqueItemDetails/{id}")]
        public IActionResult TemplateTechniqueItemDetails(int id)
        {
            try
            {
                TemplateTechniqueItem templateTechniqueItem = _techniqueRepositoryWrapper.TechniqueItemRepository.FindByCondition(id);
                if (templateTechniqueItem is null)
                {
                    _logger.LogError($"Returned TemplateTechniqueItemDetails for TemplateTechniqueId={id} from database.");
                    return NotFound();
                }
                else 
                {
                    _logger.LogInfo($"Returned TemplateTechniqueItemDetails with TemplateTechniqueItemId: {id}");
                    TemplateTechniqueItemVM templateTechniqueVM = _mapper.Map<TemplateTechniqueItemVM>(templateTechniqueItem);
                    return Ok(templateTechniqueVM);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateTechniqueItemDetails for TemplateTechniqueItemId={id} action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CreateTechniqueItem")]
        //[ValidateAntiForgeryToken]
        public IActionResult TemplateTechniqueItemCreate([FromBody] TemplateTechniqueItemVMForCreation templateTechniqueItemVM)
        {
            try
            {
                if (templateTechniqueItemVM is null)
                {
                    _logger.LogError("templateTechniqueItem object sent from client is null.");
                    return BadRequest("templateTechniqueItem object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid templateTechniqueItem object sent from client.");
                    return BadRequest("Invalid model object");
                }
                TemplateTechniqueItem templateTechniqueItemEntity = _mapper.Map<TemplateTechniqueItem>(templateTechniqueItemVM);
                _techniqueRepositoryWrapper.TechniqueItemRepository.CreateTemplateTechniqueItem(templateTechniqueItemEntity);
                _techniqueRepositoryWrapper.Save();
                TemplateTechniqueItemVM templateTechniqueItem = _mapper.Map<TemplateTechniqueItemVM>(templateTechniqueItemEntity);
                return CreatedAtRoute("TemplateTechniqueItemById", new { id = templateTechniqueItem.TemplateTechniqueItemId }, templateTechniqueItem);
            }
            catch (Exception ex)
            {
                    _logger.LogError($"Something went wrong inside TemplateTechniqueItem  action: {ex.Message}");
                    return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("EditTechniqueItem/{id}")]
        //[ValidateAntiForgeryToken]
        public IActionResult EditTemplateTechniqueItem(int id, [FromBody] TemplateTechniqueItemVMForUpdate templateTechniqueItemVM)
        {            
            try
            {
                if (templateTechniqueItemVM is null)
                {
                    _logger.LogError("templateTechniqueItem object sent from client is null.");
                    return BadRequest("templateTechniqueItem object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid templateTechniqueItem object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var templateTechniqueItemEntity = _techniqueRepositoryWrapper.TechniqueItemRepository.FindByCondition(id);
                if (templateTechniqueItemEntity is null)
                {
                    _logger.LogError($"templateTechniqueItem with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(templateTechniqueItemVM, templateTechniqueItemEntity);
                _techniqueRepositoryWrapper.TechniqueItemRepository.UpdateTemplateTechniqueItem(templateTechniqueItemEntity);
                _techniqueRepositoryWrapper.Save();
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest("EditTemplateTechniqueItem error: " + ex.Message);
            }
        }

        [Route("DeleteTechniqueItem/{id}")]
        [HttpDelete]
        public void DeleteTemplateTechniqueItem(int id)
        {
            try
            {
                var templateTechnique = _techniqueRepositoryWrapper.TechniqueRepository.FindByCondition(id);
                if (templateTechnique == null)
                {
                    _logger.LogError($"templateTechnique with id: {id}, hasn't been found in db.");
                }
                if (_techniqueRepositoryWrapper.TechniqueItemRepository.GetAllTemplateTechniqueItem(id).Any())
                {
                    _logger.LogError($"Cannot delete owner with id: {id}. It has related accounts. Delete those accounts first");
                }
                _techniqueRepositoryWrapper.TechniqueRepository.DeleteTemplateTechnique(templateTechnique);
                _techniqueRepositoryWrapper.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteOwner action: {ex.Message}");
            }
        }
    }
}
