using _4___E_CODING_DAL.Models;
using AutoMapper;
using E_CODING_Service_Abstraction;
using E_CODING_Services;
using E_CODING_Services.Project;
using E_CODING_Services.Result;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateProject_WebApi;

namespace __WEB_API__TemplateProject_WebApi.Controllers
{
    [Route("api/TemplateProject")]
    public class TemplateProjectController : ControllerBase
    {
        private readonly IProjectRepositoryWrapper _projectRepositoryWrapper;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public TemplateProjectController(
            IProjectRepositoryWrapper projectRepositoryWrapper,
            IMapper mapper,
            ILoggerManager logger)
        {
            _projectRepositoryWrapper = projectRepositoryWrapper;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("Index")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Index()
        {
            try
            {
                IEnumerable<TemplateProject> templateProjects = _projectRepositoryWrapper.ProjectRepository.GetAllTemplateProject();
                _logger.LogInfo($"Returned all templateProjects from database.");
                IEnumerable<TemplateProjectVM> templateProjectsVM = _mapper.Map<IEnumerable<TemplateProjectVM>>(templateProjects);
                return Ok(templateProjectsVM);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateProject/Index action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("ProjectDetails/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TemplateProject))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult TemplateProjectDetails(int id)
        {
            try
            {
                TemplateProject templateProject = _projectRepositoryWrapper.ProjectRepository.FindByCondition(id);
                if (templateProject is null)
                {
                    _logger.LogError($"Returned TemplateProjectDetails TemplateProject={id} from database.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned TemplateProjectDetails TemplateProject: {id}");
                    TemplateProjectVM templateProjectVM = _mapper.Map<TemplateProjectVM>(templateProject);
                    return Ok(templateProjectVM);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateProjectDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Create")]
        //[ValidateAntiForgeryToken]
        public IActionResult TemplateProjectCreate([FromBody] TemplateProject_WebApi.TemplateProjectVMForCreation templateProjectVM)
        {
            try
            {
                if (templateProjectVM is null)
                {
                    _logger.LogError("templateTechnique object sent from client is null.");
                    return BadRequest("templateTechnique object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid templateTechnique object sent from client.");
                    return BadRequest("Invalid model object");
                }
                TemplateProject TemplateProjectEntity = _mapper.Map<TemplateProject>(templateProjectVM);
                _projectRepositoryWrapper.ProjectRepository.CreateTemplateProject(TemplateProjectEntity);
                _projectRepositoryWrapper.Save();
                var templateProject = _mapper.Map<TemplateProjectVM>(TemplateProjectEntity);
                return CreatedAtRoute("TemplateProjectById", new { id = templateProject.TemplateProjectId }, templateProject);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateTechniqueCreate action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]
        [Route("Edit/{id}")]
        public IActionResult TemplateProjectEdit(int id, [FromBody] TemplateProjectVMForUpdate templateProjectVM)
        {
            try
            {
                if (templateProjectVM is null)
                {
                    _logger.LogError("TemplateResult object sent from client is null.");
                    return BadRequest("TemplateResult object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid TemplateResult object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var templateProjectEntity = _projectRepositoryWrapper.ProjectRepository.FindByCondition(id);
                if (templateProjectEntity is null)
                {
                    _logger.LogError($"TemplateProject with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(templateProjectVM, templateProjectEntity);
                _projectRepositoryWrapper.ProjectRepository.UpdateTemplateProject(templateProjectEntity);
                _projectRepositoryWrapper.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateProject action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [Route("Delete/{id}")]
        [HttpPost]
        public void DeleteTemplateProject(int id)
        {
            try
            {
                var templateProject = _projectRepositoryWrapper.ProjectRepository.FindByCondition(id);
                if (templateProject == null)
                {
                    _logger.LogError($"TemplateResult with id: {id}, hasn't been found in db.");
                }
                _projectRepositoryWrapper.ProjectRepository.DeleteTemplateProject(templateProject);
                _projectRepositoryWrapper.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateProject action: {ex.Message}");
            }
        }

    }
}
