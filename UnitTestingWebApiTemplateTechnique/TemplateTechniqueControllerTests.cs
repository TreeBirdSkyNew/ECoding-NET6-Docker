using _4___E_CODING_DAL.Models;
using AutoMapper;
using E_CODING_MVC_NET6_0.Models;
using E_CODING_Services.Technique;
using FluentAssertions;
using LoggerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Hosting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TemplateProject_WebApi;
using TemplateTechnique_WebApi;
using UnitTestingWebApiTechniqueProject.Mock;
using Xunit;

namespace UnitTestingWebApiTechniqueProject
{
    public class TemplateTechniqueControllerTests
    {
        public IMapper GetMapper()
        {
            var mappingProfile = new TemplateTechnique_WebApi.MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
            return new Mapper(configuration);
        }

        [Fact]
        public void WhenGettingAllTemplateTechnique_ThenAllTemplateTechniqueReturn()
        {
            var repositoryWrapperMock = MockTechniqueRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var TemplateTechniqueController = new TemplateTechniqueController(logger, mapper, repositoryWrapperMock.Object);

            var result = TemplateTechniqueController.Index() as ObjectResult;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsAssignableFrom<IEnumerable<TemplateProjectVM>>(result.Value);
            Assert.NotEmpty(result.Value as IEnumerable<TemplateProjectVM>);
        }

        [Fact]
        public void GivenAnIdOfAnExistingTemplateTechnique_WhenGettingTemplateTechniqueItemsById_ThenTemplateTechniqueItemsReturns()
        {
            var repositoryWrapperMock = MockTechniqueRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var TemplateTechniqueController = new TemplateTechniqueController(logger, mapper, repositoryWrapperMock.Object);
            var id = 1;
            var result = TemplateTechniqueController.TemplateTechniqueAllItems(id) as ObjectResult;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsAssignableFrom<IEnumerable<TemplateTechniqueItemVM>>(result.Value);
            Assert.NotEmpty(result.Value as IEnumerable<TemplateTechniqueItemVM>);
        }

        [Fact]
        public void GivenAnIdOfANonExistingTechnique_WhenGettingTechniqueItemsById_ThenNotFoundReturns()
        {
            var repositoryWrapperMock = MockTechniqueRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var TemplateTechniqueController = new TemplateTechniqueController(logger, mapper, repositoryWrapperMock.Object);
            var id = 2;
            var result = TemplateTechniqueController.TemplateTechniqueAllItems(id) as StatusCodeResult;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
        }

        [Fact]
        public void GivenAnIdOfAnExistingTemplateTechnique_WhenGettingTemplateTechniqueById_ThenTemplateTechniqueReturns()
        {
            var repositoryWrapperMock = MockTechniqueRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var TemplateTechniqueController = new TemplateTechniqueController(logger, mapper, repositoryWrapperMock.Object);
            var id = 1;
            var result = TemplateTechniqueController.TemplateTechniqueDetails(id) as ObjectResult;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsAssignableFrom<TemplateTechniqueVM>(result.Value);
            Assert.NotNull(result.Value as TemplateTechniqueVM);
        }

        [Fact]
        public void GivenAnIdOfANonExistingTechniqueDetails_WhenGettingTechniqueDetailsById_ThenNotFoundReturns()
        {
            var repositoryWrapperMock = MockTechniqueRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var TemplateTechniqueController = new TemplateTechniqueController(logger, mapper, repositoryWrapperMock.Object);
            var id = 2;
            var result = TemplateTechniqueController.TemplateTechniqueDetails(id) as StatusCodeResult;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
        }

        [Fact]
        public void GivenValidRequest_WhenCreatingOwner_ThenCreatedReturns()
        {
            var repositoryWrapperMock = MockTechniqueRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var TemplateTechniqueController = new TemplateTechniqueController(logger, mapper, repositoryWrapperMock.Object);
            var owner = new TemplateTechniqueVMForCreation()
            {
                TemplateTechniqueName = "TemplateTechniqueName1",
                TemplateTechniqueVersion = "TemplateTechniqueVersion1",
                TemplateTechniqueTitle = "TemplateTechniqueTitle1",
                TemplateTechniqueDescription = "TemplateTechniqueDescription1",
                TemplateTechniqueVersionNET = "TemplateTechniqueVersionNET1",
                TemplateProjectId = 1
            };
            var result = TemplateTechniqueController.TemplateTechniqueCreate(owner) as ObjectResult;
            Assert.NotNull(result);
            Assert.IsAssignableFrom<CreatedAtRouteResult>(result);
            Assert.Equal((int)HttpStatusCode.Created, result!.StatusCode);
            Assert.Equal("TemplateTechniqueById", (result as CreatedAtRouteResult)!.RouteName);
        }

        [Fact]
        public void GivenValidRequest_WhenUpdatingTemplateTechnique_ThenCreatedReturns()
        {
            var repositoryWrapperMock = MockTechniqueRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var TemplateTechniqueController = new TemplateTechniqueController(logger, mapper, repositoryWrapperMock.Object);

            var techniqueFinal = new TemplateTechniqueVMForUpdate()
            {
                TemplateTechniqueName = "TemplateTechniqueName3",
                TemplateTechniqueVersion = "TemplateTechniqueVersion3",
                TemplateTechniqueTitle = "TemplateTechniqueTitle3",
                TemplateTechniqueDescription = "TemplateTechniqueDescription3",
                TemplateTechniqueVersionNET = "TemplateTechniqueVersionNET3",
                TemplateProjectId = 1
            };           
            
            var getTechniqueFinal = TemplateTechniqueController.TemplateTechniqueEdit(1, techniqueFinal);
            var getTestTechniqueInitial = TemplateTechniqueController.TemplateTechniqueDetails(1) as ObjectResult;
            var ObjectResult = Assert.IsType<OkObjectResult>(getTestTechniqueInitial);
            var techniqueTestFinal = getTestTechniqueInitial.Value as TemplateTechniqueVM;
            Assert.Equal(techniqueTestFinal.TemplateTechniqueName, techniqueFinal.TemplateTechniqueName);
            Assert.Equal(techniqueTestFinal.TemplateTechniqueVersion, techniqueFinal.TemplateTechniqueVersion);
            Assert.Equal(techniqueTestFinal.TemplateTechniqueTitle, techniqueFinal.TemplateTechniqueTitle);
            Assert.Equal(techniqueTestFinal.TemplateTechniqueDescription, techniqueFinal.TemplateTechniqueDescription);
            Assert.Equal(techniqueTestFinal.TemplateTechniqueVersionNET, techniqueFinal.TemplateTechniqueVersionNET);
        }
    }
}
