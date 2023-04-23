using System;
using System.Collections.Generic;
using System.Text;

namespace _4___E_CODING_DAL.Models
{
    public class TemplateFonctionnelEntity
    {
        public TemplateFonctionnelEntity()
        {
            TemplateFonctionnelProperty = new HashSet<TemplateFonctionnelProperty>();
        }
        public int TemplateFonctionnelEntityId { get; set; }
        public int TemplateFonctionnelId { get; set; }
        public string TemplateFonctionnelEntityName { get; set; } = string.Empty;
        public string TemplateFonctionnelEntityTitle { get; set; } = string.Empty;
        public string TemplateFonctionnelEntityDescription { get; set; } = string.Empty;
        public string TemplateFonctionnelEntityContent { get; set; } = string.Empty;
        public string TemplateFonctionnelEntityTypeNet { get; set; } = string.Empty;
        public string TemplateFonctionnelEntityTypeSQL { get; set; } = string.Empty;
        public string TemplateFonctionnelEntityVersionEF { get; set; } = string.Empty;
        public string TemplateFonctionnelEntityVersionNET { get; set; } = string.Empty;
        public TemplateFonctionnel TemplateFonctionnel { get; set; }
        public ICollection<TemplateFonctionnelProperty> TemplateFonctionnelProperty { get; set; }
    }

}
