﻿using System;
using System.Collections.Generic;

namespace TemplateTechnique_WebApi
{
    public class TemplateProjectVM
    {
        public int TemplateProjectId { get; set; }
        public string TemplateProjectName { get; set; } = string.Empty;
        public string TemplateProjectTitle { get; set; } = string.Empty;
        public string TemplateProjectDescription { get; set; } = string.Empty;
        public string TemplateProjectVersion { get; set; } = string.Empty;
        public string TemplateProjectVersionNet { get; set; } = string.Empty;
    }
}
