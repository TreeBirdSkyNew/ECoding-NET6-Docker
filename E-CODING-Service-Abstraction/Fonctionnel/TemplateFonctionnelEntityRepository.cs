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
    public class TemplateFonctionnelEntityRepository
        : RepositoryBase<TemplateFonctionnelEntity>, ITemplateFonctionnelEntityRepository
    {
        public TemplateFonctionnelEntityRepository(TemplateProjectDbContext templateProjectDbContext) : base(templateProjectDbContext)
        { }

        public IEnumerable<TemplateFonctionnelEntity> GetAllTemplateFonctionnelEntity(int id)
        {
            return _repositoryContext.Set<TemplateFonctionnelEntity>()
                 .Where(TemplateFonctionnelEntity => TemplateFonctionnelEntity.TemplateFonctionnelId.Equals(id))
                 .AsNoTracking()
                 .ToList();
        }

        public TemplateFonctionnelEntity FindByCondition(int id)
        {
            return FindByCondition(TemplateFonctionnelEntity => TemplateFonctionnelEntity.TemplateFonctionnelEntityId.Equals(id))
                    .FirstOrDefault();
        }

        public void CreateTemplateFonctionnelEntity(TemplateFonctionnelEntity templateFonctionnelEntity)
        {
            CreateTemplateFonctionnelEntity(templateFonctionnelEntity);
        }

        public void UpdateTemplateFonctionnelEntity(TemplateFonctionnelEntity templateFonctionnelEntity)
        {
            UpdateTemplateFonctionnelEntity(templateFonctionnelEntity);
        }

        public void DeleteTemplateFonctionnelEntity(TemplateFonctionnelEntity templateFonctionnelEntity)
        {
            DeleteTemplateFonctionnelEntity(templateFonctionnelEntity);
        }


    }
}
