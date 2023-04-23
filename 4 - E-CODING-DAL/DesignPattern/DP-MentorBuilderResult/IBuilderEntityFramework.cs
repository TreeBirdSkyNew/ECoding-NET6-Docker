using System;
using System.Collections.Generic;
using System.Text;
using _4___E_CODING_DAL.Models;

namespace _4___E_CODING_DAL.DesignPattern
{
    public interface IBuilderEntityFramework
    {
        TemplateResultItem BuildEFDbContext(string item);
        TemplateResultItem BuildEFConfiguration(string item);
        TemplateResultItem BuildDAL(string item);
    }
}
