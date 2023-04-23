using _4___E_CODING_DAL;
using _4___E_CODING_DAL.Models;
using E_CODING_Service_Abstraction;
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
    public class FonctionnelRepositoryWrapper : IFonctionnelRepositoryWrapper
    {
        private TemplateProjectDbContext _projectDbContext;
        private ITemplateFonctionnelRepository _fonctionnelRepository;
        private ITemplateFonctionnelEntityRepository _fonctionnelEntityRepository;
        private ITemplateFonctionnelPropertyRepository _fonctionnelPropertyRepository;
        public ITemplateFonctionnelRepository FonctionnelRepository
        {
            get
            {
                if (_fonctionnelRepository == null)
                {
                    _fonctionnelRepository = new TemplateFonctionnelRepository(_projectDbContext);
                }
                return _fonctionnelRepository;
            }
        }

        public ITemplateFonctionnelEntityRepository FonctionnelEntityRepository
        {
            get
            {
                if (_fonctionnelEntityRepository == null)
                {
                    _fonctionnelEntityRepository = new TemplateFonctionnelEntityRepository(_projectDbContext);
                }
                return _fonctionnelEntityRepository;
            }
        }

        public ITemplateFonctionnelPropertyRepository FonctionnelPropertyRepository
        {
            get
            {
                if (_fonctionnelPropertyRepository == null)
                {
                    _fonctionnelPropertyRepository = new TemplateFonctionnelPropertyRepository(_projectDbContext);
                }
                return _fonctionnelPropertyRepository;
            }
        }

        public FonctionnelRepositoryWrapper(TemplateProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }
        public void Save()
        {
            _projectDbContext.SaveChanges();
        }
    }
}
