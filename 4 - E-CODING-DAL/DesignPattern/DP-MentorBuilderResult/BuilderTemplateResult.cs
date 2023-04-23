using System;
using System.Collections.Generic;
using System.Text;
using _4___E_CODING_DAL.Models;

namespace _4___E_CODING_DAL.DesignPattern
{
    public class BuilderTemplateResult
    {
        private TemplateResult _result;
        private readonly TemplateTechnique _technique;
        private readonly TemplateFonctionnel _fonctionnel;
        
        public BuilderTemplateResult(TemplateTechnique technique, TemplateFonctionnel fonctionnel)
        {
            _technique = technique;
            _fonctionnel = fonctionnel;
        }
        
        public TemplateResult AddParent()
        {
            _result = new TemplateResult();
            _result.TemplateResultId = 0;
            _result.TemplateResultName = "TemplateResult for Fonctionnel :" + _fonctionnel.TemplateFonctionnelName
                + " Technique :" + _technique.TemplateTechniqueName;
            _result.TemplateResultTitle = this._result.TemplateResultName;
            _result.TemplateResultDescription = this._result.TemplateResultName;
            
            return _result;
        }

        public TemplateResultItem AddChildren(TemplateTechniqueItem itemTechnique)
        {
            /*
                ICollection<TemplateParameter> parameters = itemTechnique.TemplateParameter;         
            
                string FinalContent = itemTechnique.TemplateTechniqueInitialFile;
                foreach (TemplateParameter parameter in parameters)
                {
                    FinalContent = FinalContent.Replace(parameter.Name, parameter.Value);
                }*/
                
                TemplateResultItem resultItem = new TemplateResultItem();
                resultItem.TemplateResult = _result;
                resultItem.TemplateResultInitialContent = itemTechnique.TemplateTechniqueInitialFile;
               // resultItem.TemplateResultFinalContent = FinalContent;
                _result.TemplateResultItem.Add(resultItem);
                return resultItem;
        }

        public TemplateResult GetTemplateResult()
        {
            return this._result;
        }


    }
}
