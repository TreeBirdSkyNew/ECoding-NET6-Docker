using System;
using System.Collections.Generic;
using System.Text;
using _4___E_CODING_DAL.Models;

namespace _4___E_CODING_DAL.DesignPattern
{
    public class AngularCode
    {
        public Director _director;
        private readonly TemplateTechnique _technique;
        private readonly TemplateFonctionnel _fonctionnel;
        private BuilderTemplateResult _builderResult;
        private IBuilderAngular _builderAngular;

        public AngularCode(TemplateFonctionnel fonctionnel, TemplateTechnique technique)
        {
            _director = new Director();
            _fonctionnel = fonctionnel;
            _technique = technique;
            _builderAngular = new BuilderAngular(_fonctionnel, _technique);
            _builderResult = new BuilderTemplateResult(_technique, _fonctionnel);
        }        
        
        public void BuilderAngularApp()
        {   
            TemplateResultItem appAngular = _builderAngular.BuilderAngularApp("BuilderAngularApp");
            AdapteeResult adapteeAppAngular = new AdapteeResult(appAngular);
            ITarget targetAppAngular = new AdapterResult(adapteeAppAngular);
            adapteeAppAngular.GetResultTEXT();
            adapteeAppAngular.GetResultXML();
        }

        public void BuilderAngularController()
        {
            TemplateResultItem controllerAngular = _builderAngular.BuilderAngularController("BuilderAngularController");
            AdapteeResult adapteeControllerAngular = new AdapteeResult(controllerAngular);
            ITarget targetcontrollerAngular = new AdapterResult(adapteeControllerAngular);
            adapteeControllerAngular.GetResultTEXT();
            adapteeControllerAngular.GetResultXML();
        }

        public void BuilderAngularRounting()
        {
            TemplateResultItem rountingAngular = _builderAngular.BuilderAngularRounting("BuilderAngularRounting");
            AdapteeResult adapteeRountingAngular = new AdapteeResult(rountingAngular);
            ITarget targetadapteerountingAngular = new AdapterResult(adapteeRountingAngular);
            adapteeRountingAngular.GetResultTEXT();
            adapteeRountingAngular.GetResultXML();

        }

        public void BuilderAngularService()
        {
            TemplateResultItem serviceAngular = _builderAngular.BuilderAngularService("BuilderAngularService");
            AdapteeResult adapteeServiceAngular = new AdapteeResult(serviceAngular);
            ITarget targetServiceAngular = new AdapterResult(adapteeServiceAngular);
            adapteeServiceAngular.GetResultTEXT();
            adapteeServiceAngular.GetResultXML();
        }

        public void BuilderAngularView()
        {
            TemplateResultItem resultControllerAngular = _builderAngular.BuilderAngularView("BuilderAngularView");
            AdapteeResult adapteeControllerAngular = new AdapteeResult(resultControllerAngular);
            ITarget targetControllerAngular = new AdapterResult(adapteeControllerAngular);
            adapteeControllerAngular.GetResultTEXT();
            adapteeControllerAngular.GetResultXML();
        }




    }
}
