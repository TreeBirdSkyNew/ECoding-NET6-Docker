using _4___E_CODING_DAL.Models;
using E_CODING_Service_Abstraction.Project;
using E_CODING_Service_Abstraction.Technique;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingWebApiTemplateProject.Mock
{
    internal class MockITechniqueRepository
    {
        public static Mock<ITemplateTechniqueRepository> GetMock()
        {
            var mock = new Mock<ITemplateTechniqueRepository>();
            var templateTechniques = new List<TemplateTechnique>()
            {
                new TemplateTechnique()
                {
                    TemplateTechniqueId=1,
                    TemplateTechniqueName="TemplateProjectName1",
                    TemplateTechniqueTitle="TemplateProjectTitle1",
                    TemplateTechniqueDescription="TemplateProjectDescription1",
                    TemplateTechniqueVersion="TemplateProjectVersion1"
                }
            };

            // Set up
            mock.Setup(m => m.GetAllTemplateTechnique()).Returns(() => templateTechniques);

            mock.Setup(m => m.FindByCondition(It.IsAny<int>()))
                .Returns((int id) => templateTechniques.FirstOrDefault(o => o.TemplateTechniqueId == id));

            mock.Setup(m => m.CreateTemplateTechnique(It.IsAny<TemplateTechnique>()))
                .Callback(() => { return; });
            mock.Setup(m => m.UpdateTemplateTechnique(It.IsAny<TemplateTechnique>()))
               .Callback(() => { return; });
            mock.Setup(m => m.DeleteTemplateTechnique(It.IsAny<TemplateTechnique>()))
               .Callback(() => { return; });

            return mock;
        }
    }
}
