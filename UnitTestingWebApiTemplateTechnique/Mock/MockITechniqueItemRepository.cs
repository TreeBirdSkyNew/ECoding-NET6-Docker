using _4___E_CODING_DAL.Models;
using E_CODING_Service_Abstraction.Technique;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingWebApiTechniqueProject.Mock
{
    internal class MockITechniqueItemRepository
    {
        public static Mock<ITemplateTechniqueItemRepository> GetMock()
        {
            var mock = new Mock<ITemplateTechniqueItemRepository>();
            var templateTechniqueItems = new List<TemplateTechniqueItem>()
            {
                new TemplateTechniqueItem()
                {
                    TemplateTechniqueItemId=1,
                    TemplateTechniqueId=1,
                    TemplateTechniqueItemName="TemplateTechniqueItemName1",
                    TemplateTechniqueItemVersion="TemplateTechniqueItemVersion1",
                    TemplateTechniqueItemTitle="TemplateTechniqueItemTitle1",
                    TemplateTechniqueItemDescription="TemplateTechniqueItemDescription1",
                    TemplateTechniqueItemVersionNET="TemplateTechniqueItemVersionNET1",
                }
            };

            // Set up
            mock.Setup(m => m.GetAllTemplateTechniqueItem(It.IsAny<int>()))
                .Returns((int id) => templateTechniqueItems.Where(o => o.TemplateTechniqueId == id));

            mock.Setup(m => m.FindByCondition(It.IsAny<int>()))
                .Returns((int id) => templateTechniqueItems.FirstOrDefault(o => o.TemplateTechniqueItemId == id));

            mock.Setup(m => m.CreateTemplateTechniqueItem(It.IsAny<TemplateTechniqueItem>()))
                .Callback(() => { return; });
            mock.Setup(m => m.UpdateTemplateTechniqueItem(It.IsAny<TemplateTechniqueItem>()))
               .Callback(() => { return; });
            mock.Setup(m => m.DeleteTemplateTechniqueItem(It.IsAny<TemplateTechniqueItem>()))
               .Callback(() => { return; });

            return mock;
        }
    }
}
