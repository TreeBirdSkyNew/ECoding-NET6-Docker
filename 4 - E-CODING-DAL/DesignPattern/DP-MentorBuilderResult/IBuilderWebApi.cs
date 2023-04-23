using System;
using System.Collections.Generic;
using System.Text;
using _4___E_CODING_DAL.Models;

namespace _4___E_CODING_DAL.DesignPattern
{
    public interface IBuilderWebApi
    {
        TemplateResultItem BuilderControllerWebApi(string item);
        TemplateResultItem BuilderApiRouting(string item);
        TemplateResultItem BuilderApiActionFilter(string item);
        TemplateResultItem BuilderApiResultFilter(string item);
        TemplateResultItem BuilderApiMiddleWare(string item);
        TemplateResultItem BuilderApiConfigure(string item);
        TemplateResultItem BuilderApiConfiguration(string item);
    }
}
