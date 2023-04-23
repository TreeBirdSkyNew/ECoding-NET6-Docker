using _4___E_CODING_DAL.Models;
using AutoMapper;
using E_CODING_MVC_NET6_0;
using E_CODING_MVC_NET6_0.Models;
using E_CODING_Service_Abstraction;
using E_CODING_Services;
using E_CODING_Services.Project;
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

namespace TemplateFonctionnel_WebApi
{
    [ApiController]
    [Route("api/TemplateFonctionnel")]
    public class TemplateFonctionnelController : ControllerBase
    {
        private readonly IFonctionnelRepositoryWrapper _fonctionnelRepositoryWrapper;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        public TemplateFonctionnelController(
            IFonctionnelRepositoryWrapper fonctionnelRepositoryWrapper,
            IMapper mapper,
            ILoggerManager logger
            )
        {
            _fonctionnelRepositoryWrapper = fonctionnelRepositoryWrapper;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("Index")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TemplateFonctionnelVM>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Index()
        {
            try
            {
                IEnumerable<TemplateFonctionnel> templateFonctionnels = _fonctionnelRepositoryWrapper.FonctionnelRepository.GetAllTemplateFonctionnel();
                _logger.LogInfo($"Returned all templateFonctionnels from database.");
                IEnumerable<TemplateProjectVM> templateProjectsVM = _mapper.Map<IEnumerable<TemplateProjectVM>>(templateFonctionnels);
                return Ok(templateProjectsVM);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateProject/Index action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("FonctionnelDetails")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TemplateFonctionnelVM))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> TemplateFonctionnelDetail(int id)
        {            
            try
            {
                TemplateFonctionnel templateFonctionnel = _fonctionnelRepositoryWrapper.FonctionnelRepository.FindByCondition(id);
                TemplateFonctionnelVM templateFonctionnelVM = _mapper.Map<TemplateFonctionnelVM>(templateFonctionnel);
                IEnumerable<TemplateFonctionnelEntity> templateFonctionnelEntities =
                    _fonctionnelRepositoryWrapper.FonctionnelEntityRepository.GetAllTemplateFonctionnelEntity(id);
                IEnumerable<TemplateFonctionnelEntityVM> templateFonctionnelEntitiesVM = _mapper.Map<IEnumerable<TemplateFonctionnelEntityVM>>(templateFonctionnelEntities);
                IEnumerable<TemplateFonctionnelProperty> templateFonctionnelProperties =
                    _fonctionnelRepositoryWrapper.FonctionnelPropertyRepository.GetAllTemplateFonctionnelProperty(id);
                IEnumerable<TemplateFonctionnelPropertyVM> templateFonctionnelPropertiesVM = _mapper.Map<IEnumerable<TemplateFonctionnelPropertyVM>>(templateFonctionnelProperties);
                if(templateFonctionnelEntitiesVM!=null)
                    templateFonctionnelVM.TemplateFonctionnelEntity = templateFonctionnelEntitiesVM.ToList();
                return Ok(templateFonctionnelVM);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateFonctionnel/Details action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }       

        [HttpGet]
        [Route("CreateFonctionnel")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> TemplateFonctionnelCreate()
        {            
            try
            {
                TemplateFonctionnel templateFonctionnel = new ();
                TemplateFonctionnelVM templateFonctionnelVM = _mapper.Map<TemplateFonctionnelVM>(templateFonctionnel);
                return CreatedAtAction("templateFonctionnelVM", new { id = templateFonctionnelVM.TemplateFonctionnelId }, templateFonctionnelVM);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateFonctionnel/Create action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("CreateFonctionnel")]
        [ValidateAntiForgeryToken]
        public IActionResult TemplateFonctionnelCreate([FromBody] TemplateFonctionnelVM templateFonctionnelVM)
        {
            try
            {
                if (templateFonctionnelVM is null)
                {
                    _logger.LogError("templateFonctionnel object sent from client is null.");
                    return BadRequest("templateFonctionnel object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid templateFonctionnel object sent from client.");
                    return BadRequest("Invalid model object");
                }
                TemplateFonctionnel TemplateFonctionnelEntity = _mapper.Map<TemplateFonctionnel>(templateFonctionnelVM);
                _fonctionnelRepositoryWrapper.FonctionnelRepository.CreateTemplateFonctionnel(TemplateFonctionnelEntity);
                _fonctionnelRepositoryWrapper.Save();
                var templateFonctionnel = _mapper.Map<TemplateFonctionnelVM>(TemplateFonctionnelEntity);
                return CreatedAtAction("templateFonctionnelVM", new { id = templateFonctionnel.TemplateFonctionnelId }, templateFonctionnel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateTechniqueCreate action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ValidateAntiForgeryToken]
        [Route("EditFonctionnel")]
        public IActionResult TemplateFonctionnelEdit(int id, [FromBody] TemplateFonctionnelVM templateFonctionnelVM)
        {
            try
            {
                if (templateFonctionnelVM is null)
                {
                    _logger.LogError("templateFonctionnel object sent from client is null.");
                    return BadRequest("templateFonctionnel object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid templateFonctionnel object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var templateFonctionnelEntity = _fonctionnelRepositoryWrapper.FonctionnelRepository.FindByCondition(id);
                if (templateFonctionnelEntity is null)
                {
                    _logger.LogError($"TemplateFonctionnel with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(templateFonctionnelVM, templateFonctionnelEntity);
                _fonctionnelRepositoryWrapper.FonctionnelRepository.UpdateTemplateFonctionnel(templateFonctionnelEntity);
                _fonctionnelRepositoryWrapper.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateProject action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [Route("DeleteFonctionnel")]
        [HttpDelete("{id}")]
        public void DeleteTemplateFonctionnel(int id)
        {
            try
            {
                var templateProject = _fonctionnelRepositoryWrapper.FonctionnelRepository.FindByCondition(id);
                if (templateProject == null)
                {
                    _logger.LogError($"TemplateResult with id: {id}, hasn't been found in db.");
                }
                if (_fonctionnelRepositoryWrapper.FonctionnelEntityRepository.GetAllTemplateFonctionnelEntity(id).Any())
                {
                    _logger.LogError($"Cannot delete owner with id: {id}. It has related entities. Delete those accounts first");
                }
                if (_fonctionnelRepositoryWrapper.FonctionnelPropertyRepository.GetAllTemplateFonctionnelProperty(id).Any())
                {
                    _logger.LogError($"Cannot delete owner with id: {id}. It has related properties. Delete those accounts first");
                }
                _fonctionnelRepositoryWrapper.FonctionnelRepository.DeleteTemplateFonctionnel(templateProject);
                _fonctionnelRepositoryWrapper.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteTemplateFonctionnel action: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("FonctionnelEntityDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> TemplateFonctionnelDetailsEntity(int id)
        {
            try
            {
                TemplateFonctionnelEntity templateFonctionnelEntity =
                    _fonctionnelRepositoryWrapper.FonctionnelEntityRepository.FindByCondition(id);
                TemplateFonctionnelEntityVM templateFonctionnelEntityVM = _mapper.Map<TemplateFonctionnelEntityVM>(templateFonctionnelEntity);
                return Ok(templateFonctionnelEntityVM);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateFonctionnelEntity/DetailsEntity action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("CreateFonctionnelEntity")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TemplateFonctionnelEntityCreate()
        {
            try
            {
                TemplateFonctionnelEntity templateFonctionnelEntity = new ();
                TemplateFonctionnelEntityVM templateFonctionnelEntityVM = _mapper.Map<TemplateFonctionnelEntityVM>(templateFonctionnelEntity);
                return Ok(templateFonctionnelEntityVM);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateFonctionnelEntityCreate action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("CreateFonctionnelEntity")]
        [ValidateAntiForgeryToken]
        public IActionResult TemplateFonctionnelEntityCreate([FromBody] TemplateFonctionnelEntityVM templateFonctionnelEntityVM)
        {
            try
            {
                if (templateFonctionnelEntityVM is null)
                {
                    _logger.LogError("TemplateFonctionnelEntity object sent from client is null.");
                    return BadRequest("TemplateFonctionnelEntity object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid TemplateFonctionnelEntity object sent from client.");
                    return BadRequest("Invalid model object");
                }
                TemplateFonctionnelEntity templateFonctionnelEntity = _mapper.Map<TemplateFonctionnelEntity>(templateFonctionnelEntityVM);
                _fonctionnelRepositoryWrapper.FonctionnelEntityRepository.Create(templateFonctionnelEntity);
                _fonctionnelRepositoryWrapper.Save();
                var templateFonctionnel = _mapper.Map<TemplateFonctionnelEntityVM>(templateFonctionnelEntity);
                return CreatedAtAction("templateFonctionnelEntity", new { id = templateFonctionnel.TemplateFonctionnelId }, templateFonctionnel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateFonctionnelEntityCreate action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("FonctionnelPropertyDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> TemplateFonctionnelDetailsProperty(int id)
        {
            try
            {
                TemplateFonctionnelProperty templateFonctionnelProperty =
                    _fonctionnelRepositoryWrapper.FonctionnelPropertyRepository.FindByCondition(id);
                TemplateFonctionnelPropertyVM templateFonctionnelPropertyVM = _mapper.Map<TemplateFonctionnelPropertyVM>(templateFonctionnelProperty);
                return Ok(templateFonctionnelPropertyVM);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateFonctionnelEntity/DetailsEntity action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("CreateFonctionnelProperty")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TemplateFonctionnelPropertyCreate()
        {
            try
            {
                TemplateFonctionnelProperty templateFonctionnelProperty = new ();
                TemplateFonctionnelPropertyVM templateFonctionnelPropertyVM = _mapper.Map<TemplateFonctionnelPropertyVM>(templateFonctionnelProperty);
                return CreatedAtAction("templateFonctionnelPropertyVM", new { id = templateFonctionnelPropertyVM.TemplateFonctionnelPropertyId }, templateFonctionnelPropertyVM);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateFonctionnelEntityCreate action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("CreateFonctionnelProperty")]
        [ValidateAntiForgeryToken]
        public IActionResult TemplateFonctionnelPropertyCreate([FromBody] TemplateFonctionnelPropertyVM templateFonctionnelPropertyVM)
        {
            try
            {
                if (templateFonctionnelPropertyVM is null)
                {
                    _logger.LogError("templateFonctionnelProperty object sent from client is null.");
                    return BadRequest("templateFonctionnelProperty object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid templateFonctionnelProperty object sent from client.");
                    return BadRequest("Invalid model object");
                }
                TemplateFonctionnelProperty templateFonctionnelPropertyEntity = _mapper.Map<TemplateFonctionnelProperty>(templateFonctionnelPropertyVM);
                _fonctionnelRepositoryWrapper.FonctionnelPropertyRepository.Create(templateFonctionnelPropertyEntity);
                _fonctionnelRepositoryWrapper.Save();
                var templateFonctionnelProperty = _mapper.Map<TemplateFonctionnelPropertyVM>(templateFonctionnelPropertyEntity);
                return CreatedAtAction("templateFonctionnelProperty", new { id = templateFonctionnelProperty.TemplateFonctionnelId }, templateFonctionnelProperty);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside templateFonctionnelProperty action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [Route("DeleteFonctionnelEntity")]
        [HttpDelete("{id}")]
        public void DeleteTemplateFonctionnelEntity(int id)
        {
            try
            {
                var templateFonctionnelEntity = _fonctionnelRepositoryWrapper.FonctionnelEntityRepository.FindByCondition(id);
                if (templateFonctionnelEntity == null)
                {
                    _logger.LogError($"templateFonctionnelEntity with id: {id}, hasn't been found in db.");
                }
                _fonctionnelRepositoryWrapper.FonctionnelEntityRepository.DeleteTemplateFonctionnelEntity(templateFonctionnelEntity);
                _fonctionnelRepositoryWrapper.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteTemplateFonctionnelEntity action: {ex.Message}");
            }
        }

        [Route("DeleteFonctionnelProperty")]
        [HttpDelete("{id}")]
        public void DeleteTemplateFonctionnelProperty(int id)
        {
            try
            {
                var templateFonctionnelProperty = _fonctionnelRepositoryWrapper.FonctionnelPropertyRepository.FindByCondition(id);
                if (templateFonctionnelProperty == null)
                {
                    _logger.LogError($"templateFonctionnelProperty with id: {id}, hasn't been found in db.");
                }
                _fonctionnelRepositoryWrapper.FonctionnelPropertyRepository.DeleteTemplateFonctionnelProperty(templateFonctionnelProperty);
                _fonctionnelRepositoryWrapper.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteTemplateFonctionnelProperty action: {ex.Message}");
            }
        }
    }
}
