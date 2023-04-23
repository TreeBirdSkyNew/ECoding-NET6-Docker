using _4___E_CODING_DAL.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplateTechnique_WebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<TemplateProject, TemplateProjectVM>();
            CreateMap<TemplateProjectVM, TemplateProject>();

            CreateMap<TemplateTechnique, TemplateTechniqueVM>();
            CreateMap<TemplateTechniqueVM, TemplateTechnique>();
            CreateMap<TemplateTechniqueVMForCreation, TemplateTechnique>();
            CreateMap<TemplateTechniqueVMForUpdate, TemplateTechnique>();

            CreateMap<TemplateTechniqueItem, TemplateTechniqueItemVM>();
            CreateMap<TemplateTechniqueItemVM, TemplateTechniqueItem>();
            CreateMap<TemplateTechniqueItemVMForCreation, TemplateTechniqueItem>();
            CreateMap<TemplateTechniqueItemVMForUpdate, TemplateTechniqueItem>();

        }
    }
}
