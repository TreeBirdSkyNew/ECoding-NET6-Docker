using _4___E_CODING_DAL.Models;
using E_CODING_Service_Abstraction.Fonctionnel;
using E_CODING_Service_Abstraction.Project;
using E_CODING_Service_Abstraction.Result;
using E_CODING_Service_Abstraction.Technique;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Services
{
    public interface IFonctionnelRepositoryWrapper
    {
        ITemplateFonctionnelRepository FonctionnelRepository { get; }
        ITemplateFonctionnelEntityRepository FonctionnelEntityRepository { get; }
        ITemplateFonctionnelPropertyRepository FonctionnelPropertyRepository { get; }
        void Save();
    }
}
