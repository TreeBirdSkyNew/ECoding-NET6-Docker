using _4___E_CODING_DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Service_Abstraction.Fonctionnel
{
    public interface ITemplateFonctionnelRepository : IRepositoryBase<TemplateFonctionnel>
    {
        IEnumerable<TemplateFonctionnel> GetAllTemplateFonctionnel();
        TemplateFonctionnel FindByCondition(int id);
        void CreateTemplateFonctionnel(TemplateFonctionnel templateFonctionnel);
        void UpdateTemplateFonctionnel(TemplateFonctionnel templateFonctionnel);
        void DeleteTemplateFonctionnel(TemplateFonctionnel templateFonctionnel);
        
    }
}
