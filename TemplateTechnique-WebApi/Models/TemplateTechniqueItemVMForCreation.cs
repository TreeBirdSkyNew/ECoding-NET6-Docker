﻿


namespace TemplateTechnique_WebApi
{
    public class TemplateTechniqueItemVMForCreation
    {
        public int TemplateTechniqueId { get; set; }
        public string TemplateTechniqueItemName { get; set; } = string.Empty;
        public string TemplateTechniqueItemTitle { get; set; } = string.Empty;
        public string TemplateTechniqueItemDescription { get; set; } = string.Empty;
        public string TemplateTechniqueItemVersion { get; set; } = string.Empty;
        public string TemplateTechniqueItemVersionNET { get; set; } = string.Empty;
        public string TemplateTechniqueInitialFile { get; set; } = string.Empty;
        public string TemplateTechniqueFinalContent { get; set; } = string.Empty;
    }
}
