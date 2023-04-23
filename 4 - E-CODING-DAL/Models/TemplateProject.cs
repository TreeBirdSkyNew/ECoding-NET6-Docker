using System;
using System.Collections.Generic;

namespace _4___E_CODING_DAL.Models
{
    public class TemplateProject
    {
        public int TemplateProjectId { get; set; }
        public string TemplateProjectName { get; set; } = string.Empty;
        public string TemplateProjectTitle { get; set; } = string.Empty;
        public string TemplateProjectDescription { get; set; } = string.Empty;
        public string TemplateProjectVersion { get; set; } = string.Empty;
        public string TemplateProjectVersionNet { get; set; } = string.Empty;
        public TemplateFonctionnel TemplateFonctionnel { get; set; }
        public ICollection<ProjectTechnique> ProjectTechnique { get; set; }
        public ICollection<ProjectResult> ProjectResult { get; set; }
    }
}
