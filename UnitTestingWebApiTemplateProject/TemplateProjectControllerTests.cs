using __WEB_API__TemplateProject_WebApi.Controllers;
using _4___E_CODING_DAL.Models;
using AutoMapper;
using E_CODING_MVC_NET6_0.Models;
using LoggerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TemplateProject_WebApi;
using UnitTestingWebApiTechniqueProject.Mock;

namespace UnitTestingWebApiTemplateProject
{
    public class TemplateProjectControllerTests
    {
        public IMapper GetMapper()
        {
            var mappingProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
            return new Mapper(configuration);
        }

        [Fact]
        public void WhenGettingAllTemplateProject_ThenAllTemplateProjectReturn()
        {
            var repositoryWrapperMock = MockProjectRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var TemplateProjectController = new TemplateProjectController(repositoryWrapperMock.Object, mapper,logger );

            var result = TemplateProjectController.Index() as ObjectResult;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsAssignableFrom<IEnumerable<TemplateProjectVM>>(result.Value);
            Assert.NotEmpty(result.Value as IEnumerable<TemplateProjectVM>);
        }

        [Fact]
        public void GivenAnIdOfAnExistingTemplateTechnique_WhenGettingTemplateTechniqueItemsById_ThenTemplateTechniqueItemsReturns()
        {
            var repositoryWrapperMock = MockProjectRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var TemplateProjectController = new TemplateProjectController(repositoryWrapperMock.Object, mapper, logger);
            var id = 1;
            var result = TemplateProjectController.TemplateProjectDetails(id) as ObjectResult;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsAssignableFrom<TemplateProjectVM>(result.Value);
            Assert.NotNull(result.Value as TemplateProjectVM);
        }

        [Fact]
        public void GivenAnIdOfANonExistingTemplateProject_WhenGettingTemplateProjectById_ThenNotFoundReturns()
        {
            var repositoryWrapperMock = MockProjectRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var TemplateProjectController = new TemplateProjectController(repositoryWrapperMock.Object, mapper, logger);
            var id = 2;
            var result = TemplateProjectController.TemplateProjectDetails(id) as StatusCodeResult;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
        }

        [Fact]
        public void GivenValidRequest_WhenCreatingProject_ThenCreatedReturns()
        {
            var repositoryWrapperMock = MockProjectRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var TemplateProjectController = new TemplateProjectController(repositoryWrapperMock.Object, mapper, logger);
            var templateProject = new TemplateProjectVMForCreation()
            {
                TemplateProjectName = "TemplateProjectName1",
                TemplateProjectTitle = "TemplateProjectTitle1",
                TemplateProjectDescription = "TemplateProjectDescription1",
                TemplateProjectVersion = "TemplateProjectVersion1",
                TemplateProjectVersionNet = "TemplateProjectVersionNet1",
            };

            var result = TemplateProjectController.TemplateProjectCreate(templateProject) as ObjectResult;
            Assert.NotNull(result);
            Assert.IsAssignableFrom<CreatedAtRouteResult>(result);
            Assert.Equal((int)HttpStatusCode.Created, result!.StatusCode);
            Assert.Equal("TemplateProjectById", (result as CreatedAtRouteResult)!.RouteName);
        }

        [Fact]
        public void GivenValidRequest_WhenUpdatingTemplateTechnique_ThenCreatedReturns()
        {
            var repositoryWrapperMock = MockProjectRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var TemplateProjectController = new TemplateProjectController(repositoryWrapperMock.Object, mapper, logger);

            var templateProjectFinal = new TemplateProjectVM()
            {
                TemplateProjectId = 1,
                TemplateProjectName = "TemplateProjectName1",
                TemplateProjectTitle = "TemplateProjectTitle1",
                TemplateProjectDescription = "TemplateProjectDescription1",
                TemplateProjectVersion = "TemplateProjectVersion1",
                TemplateProjectVersionNet = "TemplateProjectVersionNet1",
            };
            /*
            var getTemplateProjectFinal = TemplateProjectController.TemplateProjectEdit(1, templateProjectFinal);
            var getTestTemplateProjectInitial = TemplateProjectController.TemplateProjectDetails(1) as ObjectResult;
            var ObjectResult = Assert.IsType<OkObjectResult>(getTestTemplateProjectInitial);
            var TemplateProjectTestFinal = getTestTemplateProjectInitial.Value as TemplateProjectVM;
            Assert.Equal(templateProjectFinal.TemplateProjectId, TemplateProjectTestFinal.TemplateProjectId);
            Assert.Equal(templateProjectFinal.TemplateProjectName, TemplateProjectTestFinal.TemplateProjectName);
            Assert.Equal(templateProjectFinal.TemplateProjectTitle, TemplateProjectTestFinal.TemplateProjectTitle);
            Assert.Equal(templateProjectFinal.TemplateProjectDescription, TemplateProjectTestFinal.TemplateProjectDescription);
            Assert.Equal(templateProjectFinal.TemplateProjectVersion, TemplateProjectTestFinal.TemplateProjectVersion);
            Assert.Equal(templateProjectFinal.TemplateProjectVersionNet, TemplateProjectTestFinal.TemplateProjectVersionNet);*/
        }
    }
}
