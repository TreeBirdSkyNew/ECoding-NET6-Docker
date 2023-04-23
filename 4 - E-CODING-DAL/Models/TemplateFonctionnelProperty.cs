using System;
using System.Collections.Generic;
using System.Text;

namespace _4___E_CODING_DAL.Models
{
    public class TemplateFonctionnelProperty
    {
        public int TemplateFonctionnelPropertyId { get; set; }
        public int TemplateFonctionnelEntityId { get; set; }
        public int TemplateFonctionnelId { get; set; }
        public string TemplateFonctionnelPropertyName { get; set; } = string.Empty;
        public string TemplateFonctionnelPropertyTitle { get; set; } = string.Empty;
        public string TemplateFonctionnelPropertyDescription { get; set; } = string.Empty;
        public string TemplateFonctionnelPropertyVersionEF { get; set; } = string.Empty;
        public string TemplateFonctionnelPropertyVersionNET { get; set; } = string.Empty;
        //public TemplateSharpToSQLType PropertyType { get; set; }
        public TemplateFonctionnelEntity TemplateFonctionnelEntity { get; set; }
    }
}
