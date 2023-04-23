using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _4___E_CODING_DAL.Models;

namespace _4___E_CODING_DAL.DesignPattern
{
    public class ApiGateWayCode
    {
        public Director _director;
        private readonly TemplateTechnique _technique;
        private readonly TemplateFonctionnel _fonctionnel;
        private BuilderTemplateResult _builderResult;
        private IBuilderApiGateWay _builderAngular;

        public ApiGateWayCode(TemplateFonctionnel fonctionnel, TemplateTechnique technique)
        {
            _director = new Director();
            _fonctionnel = fonctionnel;
            _technique = technique;
            _builderAngular = new BuilderApiGateWay(_fonctionnel, _technique);
            _builderResult = new BuilderTemplateResult(_technique, _fonctionnel);
        }

        public void BuilderApiGateWayEnvoy()
        {
            TemplateResultItem appAngular = _builderAngular.BuilderApiGateWayEnvoy("BuilderApiGateWayEnvoy");
            AdapteeResult adapteeAppAngular = new AdapteeResult(appAngular);
            ITarget targetAppAngular = new AdapterResult(adapteeAppAngular);
            adapteeAppAngular.GetResultTEXT();
            adapteeAppAngular.GetResultXML();
        }

        public void BuilderApiGateWayMobileBff()
        {
            TemplateResultItem controllerAngular = _builderAngular.BuilderApiGateWayMobileBff("BuilderApiGateWayMobileBff");
            AdapteeResult adapteeControllerAngular = new AdapteeResult(controllerAngular);
            ITarget targetcontrollerAngular = new AdapterResult(adapteeControllerAngular);
            adapteeControllerAngular.GetResultTEXT();
            adapteeControllerAngular.GetResultXML();
        }

        public void BuilderApiGateWayWebBff()
        {
            TemplateResultItem rountingAngular = _builderAngular.BuilderApiGateWayWebBff("BuilderApiGateWayWebBff");
            AdapteeResult adapteeRountingAngular = new AdapteeResult(rountingAngular);
            ITarget targetadapteerountingAngular = new AdapterResult(adapteeRountingAngular);
            adapteeRountingAngular.GetResultTEXT();
            adapteeRountingAngular.GetResultXML();

        }

    }
}
