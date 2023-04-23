using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4___E_CODING_DAL.Models
{
    public class ProjectTechnique
    {
        public int TemplateProjectId { get; set; }
        public TemplateProject TemplateProject { get; set; }

        public int TemplateTechniqueId { get; set; }
        public TemplateTechnique TemplateTechnique { get; set; }
    }
}
