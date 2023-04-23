using _4___E_CODING_DAL.Models;
using E_CODING_MVC_NET6_0.Models;
using E_CODING_Service_Abstraction.Technique;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingWebApiTechniqueProject.Mock
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
                    TemplateTechniqueName="TemplateTechniqueName1",
                    TemplateTechniqueVersion="TemplateTechniqueVersion1",
                    TemplateTechniqueTitle="TemplateTechniqueTitle1",
                    TemplateTechniqueDescription="TemplateTechniqueDescription1",
                    TemplateTechniqueVersionNET="TemplateTechniqueVersionNET1",
                    TemplateProjectId=1,
                    ProjectTechnique= new List<ProjectTechnique>()
                    {
                        new ProjectTechnique()
                        {
                            TemplateTechniqueId=1,
                            TemplateProjectId=1
                        }
                    }
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
