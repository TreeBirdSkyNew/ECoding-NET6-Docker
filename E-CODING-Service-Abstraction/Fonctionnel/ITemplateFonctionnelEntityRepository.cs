using _4___E_CODING_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Service_Abstraction.Fonctionnel
{
    public interface ITemplateFonctionnelEntityRepository : IRepositoryBase<TemplateFonctionnelEntity>
    {
        IEnumerable<TemplateFonctionnelEntity> GetAllTemplateFonctionnelEntity(int id);
        TemplateFonctionnelEntity FindByCondition(int id);
        void CreateTemplateFonctionnelEntity(TemplateFonctionnelEntity TemplateFonctionnelEntity);
        void UpdateTemplateFonctionnelEntity(TemplateFonctionnelEntity TemplateFonctionnelEntity);
        void DeleteTemplateFonctionnelEntity(TemplateFonctionnelEntity TemplateFonctionnelEntity);

    }
}
