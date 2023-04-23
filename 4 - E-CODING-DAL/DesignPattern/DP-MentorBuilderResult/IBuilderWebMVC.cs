using System;
using System.Collections.Generic;
using System.Text;
using _4___E_CODING_DAL.Models;

namespace _4___E_CODING_DAL.DesignPattern
{
    public interface IBuilderWebMVC
    {
        TemplateResultItem BuilderControllerMVC(string item);
        TemplateResultItem BuilderControllerRouting(string item);
        TemplateResultItem BuilderActionFilter(string item);
        TemplateResultItem BuilderResultFilter(string item);
        TemplateResultItem BuilderMiddleWare(string item);
        TemplateResultItem BuilderConfigure(string item);
        TemplateResultItem BuilderConfiguration(string item);
    }
}
