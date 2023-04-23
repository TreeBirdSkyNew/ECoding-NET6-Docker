using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4___E_CODING_DAL.Models
{
    public class ProjectResult
    {
        public int TemplateProjectId { get; set; }
        public TemplateProject TemplateProject { get; set; }

        public int TemplateResultId { get; set; }
        public TemplateResult TemplateResult { get; set; }

    }
}
