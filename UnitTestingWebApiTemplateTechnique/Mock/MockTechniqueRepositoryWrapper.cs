using E_CODING_Service_Abstraction.Technique;
using E_CODING_Services.Technique;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingWebApiTechniqueProject.Mock
{
    internal class MockTechniqueRepositoryWrapper
    {
        public static Mock<ITechniqueRepositoryWrapper> GetMock()
        {
            var mock = new Mock<ITechniqueRepositoryWrapper>();
            var techniqueRepoMock = MockITechniqueRepository.GetMock();
            var techniqueItemRepoMock = MockITechniqueItemRepository.GetMock();

            // Setup the mock
            mock.Setup(m => m.TechniqueRepository).Returns(() => techniqueRepoMock.Object);
            mock.Setup(m => m.TechniqueItemRepository).Returns(() => techniqueItemRepoMock.Object);
            mock.Setup(m => m.Save()).Callback(() => { return; });

            return mock;
        }
    }
}
