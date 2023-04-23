using _4___E_CODING_DAL;
using _4___E_CODING_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Service_Abstraction.Fonctionnel
{
    public class TemplateFonctionnelRepository 
        : RepositoryBase<TemplateFonctionnel>, ITemplateFonctionnelRepository
    {
        public TemplateFonctionnelRepository(TemplateProjectDbContext templateProjectDbContext) : base(templateProjectDbContext)
        { }

        public IEnumerable<TemplateFonctionnel> GetAllTemplateFonctionnel()
        {
            return FindAll().ToList();
        }

        public TemplateFonctionnel FindByCondition(int id)
        {
            return FindByCondition(TemplateFonctionnel => TemplateFonctionnel.TemplateFonctionnelId.Equals(id))
                    .FirstOrDefault();
        }
        
        public void CreateTemplateFonctionnel(TemplateFonctionnel templateFonctionnel)
        {
            CreateTemplateFonctionnel(templateFonctionnel);
        }

        public void UpdateTemplateFonctionnel(TemplateFonctionnel templateFonctionnel)
        {
            UpdateTemplateFonctionnel(templateFonctionnel);
        }
        
        public void DeleteTemplateFonctionnel(TemplateFonctionnel templateFonctionnel)
        {
            DeleteTemplateFonctionnel(templateFonctionnel);
        }

        
    }
}
