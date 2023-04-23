using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TemplateTechnique_WebApi
{
    public class ProjectTechniqueVM
    {
        public int TemplateProjectId { get; set; }
        public TemplateProjectVM TemplateProject { get; set; }

        public int TemplateTechniqueId { get; set; }
        public TemplateTechniqueVM TemplateTechnique { get; set; }
    }
}
