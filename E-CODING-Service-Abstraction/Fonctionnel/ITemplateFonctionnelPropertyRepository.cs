using _4___E_CODING_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Service_Abstraction.Fonctionnel
{
    public interface ITemplateFonctionnelPropertyRepository : IRepositoryBase<TemplateFonctionnelProperty>
    {
        IEnumerable<TemplateFonctionnelProperty> GetAllTemplateFonctionnelProperty(int id);
        TemplateFonctionnelProperty FindByCondition(int id);
        void CreateTemplateFonctionnelProperty(TemplateFonctionnelProperty TemplateFonctionnelProperty);
        void UpdateTemplateFonctionnelProperty(TemplateFonctionnelProperty TemplateFonctionnelProperty);
        void DeleteTemplateFonctionnelProperty(TemplateFonctionnelProperty TemplateFonctionnelProperty);

    }
}
