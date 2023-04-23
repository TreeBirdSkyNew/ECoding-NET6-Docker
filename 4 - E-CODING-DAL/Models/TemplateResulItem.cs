using System;
using System.Collections.Generic;
using System.Text;

namespace _4___E_CODING_DAL.Models
{
    public class TemplateResulItem
    {
        public int TemplateResulItemId { get; set; }
        public int TemplateResultId { get; set; }
        public int TemplateFonctionnelId { get; set; }
        public int TemplateTechniqueId { get; set; }
        public string TemplateResulItemName { get; set; } = string.Empty;
        public string TemplateResulItemVersion { get; set; } = string.Empty;
        public string TemplateResulItemVersionNET { get; set; } = string.Empty;
        public string TemplateResulItemTitle { get; set; } = string.Empty;
        public string TemplateResulItemDescription { get; set; } = string.Empty;
    }
}
