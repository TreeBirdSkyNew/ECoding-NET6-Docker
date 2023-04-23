using E_CODING_Service_Abstraction.Technique;
using E_CODING_Services.Project;
using E_CODING_Services.Technique;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingWebApiTemplateProject.Mock;

namespace UnitTestingWebApiTechniqueProject.Mock
{
    internal class MockProjectRepositoryWrapper
    {
        public static Mock<IProjectRepositoryWrapper> GetMock()
        {
            var mock = new Mock<IProjectRepositoryWrapper>();
            var projectRepoMock = MockIProjectRepository.GetMock();
            var techniqueRepoMock = MockITechniqueRepository.GetMock();


            // Setup the mock
            mock.Setup(m => m.ProjectRepository).Returns(() => projectRepoMock.Object);
            mock.Setup(m => m.TechniqueRepository).Returns(() => techniqueRepoMock.Object);
            mock.Setup(m => m.Save()).Callback(() => { return; });

            return mock;
        }
    }
}
