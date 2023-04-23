using System;
using System.Collections.Generic;
using System.Text;

namespace _4___E_CODING_DAL.Models
{
    public class TemplateFonctionnel
    {
        public TemplateFonctionnel()
        {
            TemplateFonctionnelEntity = new HashSet<TemplateFonctionnelEntity>();
        }
        public int TemplateFonctionnelId { get; set; }
        public string TemplateFonctionnelName { get; set; } = string.Empty;
        public string TemplateFonctionnelTitle { get; set; } = string.Empty;
        public string TemplateFonctionnelDescription { get; set; } = string.Empty;
        public string TemplateFonctionnelContent { get; set; } = string.Empty;
        public string TemplateFonctionnelEFVersion { get; set; } = string.Empty;
        public int TemplateProjectId { get; set; }
        public TemplateProject TemplateProject { get; set; }
        public ICollection<TemplateFonctionnelEntity> TemplateFonctionnelEntity { get; set; }
    }
}
