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
using TemplateTechnique_WebApi;
using UnitTestingWebApiTechniqueProject.Mock;
using Xunit;

namespace UnitTestingWebApiTechniqueProject
{
    public class TemplateTechniqueItemControllerTests
    {
        public IMapper GetMapper()
        {
            var mappingProfile = new TemplateTechnique_WebApi.MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
            return new Mapper(configuration);
        }

        [Fact]
        public void GivenAnExistingTemplateTechniqueItemId_ThenTemplateTechniqueItemReturns()
        {
            var repositoryWrapperMock = MockTechniqueRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var TemplateTechniqueController = new TemplateTechniqueController(logger, mapper, repositoryWrapperMock.Object);
            var id = 1;
            var result = TemplateTechniqueController.TemplateTechniqueItemDetails(id) as ObjectResult;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsAssignableFrom<TemplateTechniqueItemVM>(result.Value);
            Assert.NotNull(result.Value as TemplateTechniqueItemVM);
        }

        [Fact]
        public void GivenAnNotExistingTemplateTechniqueItemId_ThenReturnsNotFound()
        {
            var repositoryWrapperMock = MockTechniqueRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var TemplateTechniqueController = new TemplateTechniqueController(logger, mapper, repositoryWrapperMock.Object);
            var id = 2;
            var result = TemplateTechniqueController.TemplateTechniqueItemDetails(id) as StatusCodeResult;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
        }

        [Fact]
        public void GivenValidRequest_WhenCreatingTemplateTechniqueItem_ThenCreatedReturns()
        {
            var repositoryWrapperMock = MockTechniqueRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var TemplateTechniqueController = new TemplateTechniqueController(logger, mapper, repositoryWrapperMock.Object);
            var templateTechniqueItemVM = new TemplateTechniqueItemVMForCreation()
            {
                TemplateTechniqueItemName = "TemplateTechniqueItemName1",
                TemplateTechniqueItemVersion = "TemplateTechniqueItemVersion1",
                TemplateTechniqueItemTitle = "TemplateTechniqueItemTitle1",
                TemplateTechniqueItemDescription = "TemplateTechniqueItemDescription1",
                TemplateTechniqueItemVersionNET = "TemplateTechniqueItemVersionNET1",
                TemplateTechniqueId = 1
            };
            var result = TemplateTechniqueController.TemplateTechniqueItemCreate(templateTechniqueItemVM) as ObjectResult;
            Assert.NotNull(result);
            Assert.IsAssignableFrom<CreatedAtRouteResult>(result);
            Assert.Equal((int)HttpStatusCode.Created, result!.StatusCode);
            Assert.Equal("TemplateTechniqueItemId", (result as CreatedAtRouteResult)!.RouteName);
        }

        [Fact]
        public void GivenValidRequest_WhenUpdatingTemplateTechnique_ThenCreatedReturns()
        {
            var repositoryWrapperMock = MockTechniqueRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var TemplateTechniqueController = new TemplateTechniqueController(logger, mapper, repositoryWrapperMock.Object);

            var templateTechniqueItemfinal = new TemplateTechniqueItemVMForUpdate()
            {
                TemplateTechniqueItemName = "TemplateTechniqueItemName1",
                TemplateTechniqueItemVersion = "TemplateTechniqueItemVersion1",
                TemplateTechniqueItemTitle = "TemplateTechniqueItemTitle1",
                TemplateTechniqueItemDescription = "TemplateTechniqueItemDescription1",
                TemplateTechniqueItemVersionNET = "TemplateTechniqueItemVersionNET1",
                TemplateTechniqueId = 1
            };

            var getTechniqueItemFinal = TemplateTechniqueController.EditTemplateTechniqueItem(1, templateTechniqueItemfinal);
            var getTestTechniqueItemInitial = TemplateTechniqueController.TemplateTechniqueItemDetails(1) as ObjectResult;
            var ObjectResult = Assert.IsType<OkObjectResult>(getTestTechniqueItemInitial);
            var techniqueItemTestFinal = getTestTechniqueItemInitial.Value as TemplateTechniqueItemVM;
            Assert.Equal(techniqueItemTestFinal.TemplateTechniqueItemName, templateTechniqueItemfinal.TemplateTechniqueItemName);
            Assert.Equal(techniqueItemTestFinal.TemplateTechniqueItemVersion, templateTechniqueItemfinal.TemplateTechniqueItemVersion);
            Assert.Equal(techniqueItemTestFinal.TemplateTechniqueItemTitle, templateTechniqueItemfinal.TemplateTechniqueItemTitle);
            Assert.Equal(techniqueItemTestFinal.TemplateTechniqueItemDescription, templateTechniqueItemfinal.TemplateTechniqueItemDescription);
            Assert.Equal(techniqueItemTestFinal.TemplateTechniqueItemVersionNET, templateTechniqueItemfinal.TemplateTechniqueItemVersionNET);
        }

    }
}
