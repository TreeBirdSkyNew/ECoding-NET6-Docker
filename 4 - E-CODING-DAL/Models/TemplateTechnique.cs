﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _4___E_CODING_DAL.Models
{
    public class TemplateTechnique
    {
        public TemplateTechnique()
        {
            TemplateTechniqueItem = new HashSet<TemplateTechniqueItem>();
        }
        public int TemplateTechniqueId { get; set; }
        public string TemplateTechniqueName { get; set; } = string.Empty;
        public string TemplateTechniqueVersion { get; set; } = string.Empty;
        public string TemplateTechniqueTitle { get; set; } = string.Empty;
        public string TemplateTechniqueDescription { get; set; } = string.Empty;
        public string TemplateTechniqueVersionNET { get; set; } = string.Empty;
        public int TemplateProjectId { get; set; }
        public ICollection<ProjectTechnique> ProjectTechnique { get; set; }
        public ICollection<TemplateTechniqueItem> TemplateTechniqueItem { get; set; }
    }
}
