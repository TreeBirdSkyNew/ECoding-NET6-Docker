using System;
using System.Collections.Generic;
using System.Text;
using _4___E_CODING_DAL.Models;

namespace _4___E_CODING_DAL.DesignPattern
{
    public interface IBuilderApiGateWay
    {
        TemplateResultItem BuilderApiGateWayEnvoy(string item);
        TemplateResultItem BuilderApiGateWayMobileBff(string item);
        TemplateResultItem BuilderApiGateWayWebBff(string item);
    }
}
