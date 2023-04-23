using _4___E_CODING_DAL.Models;
using _4___E_CODING_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace E_CODING_Service_Abstraction.Fonctionnel
{
    public class TemplateFonctionnelPropertyRepository
        : RepositoryBase<TemplateFonctionnelProperty>, ITemplateFonctionnelPropertyRepository
    {
        public TemplateFonctionnelPropertyRepository(TemplateProjectDbContext templateProjectDbContext) : base(templateProjectDbContext)
        { }

        public IEnumerable<TemplateFonctionnelProperty> GetAllTemplateFonctionnelProperty(int id)
        {
            return _repositoryContext.Set<TemplateFonctionnelProperty>()
                .Where(TemplateFonctionnelProperty => TemplateFonctionnelProperty.TemplateFonctionnelId.Equals(id))
                .AsNoTracking()
                .ToList();
        }

        public TemplateFonctionnelProperty FindByCondition(int id)
        {
            return FindByCondition(TemplateFonctionnelProperty => TemplateFonctionnelProperty.TemplateFonctionnelPropertyId.Equals(id))
                    .FirstOrDefault();
        }

        public void CreateTemplateFonctionnelProperty(TemplateFonctionnelProperty templateFonctionnelProperty)
        {
            CreateTemplateFonctionnelProperty(templateFonctionnelProperty);
        }

        public void UpdateTemplateFonctionnelProperty(TemplateFonctionnelProperty templateFonctionnelProperty)
        {
            UpdateTemplateFonctionnelProperty(templateFonctionnelProperty);
        }

        public void DeleteTemplateFonctionnelProperty(TemplateFonctionnelProperty templateFonctionnelProperty)
        {
            DeleteTemplateFonctionnelProperty(templateFonctionnelProperty);
        }


    }
}
