using System;
using System.Collections.Generic;
using System.Text;
using _4___E_CODING_DAL.Models;

namespace _4___E_CODING_DAL.DesignPattern
{
    public class BuilderAngular : IBuilderAngular
    {
        private BuilderTemplateResult _builderResult;
        private TemplateFonctionnel _fonctionnel;
        private TemplateTechnique _technique;
        private TemplateTechniqueItem _techniqueItem;
        private TemplateResult _result;

        public BuilderAngular(TemplateFonctionnel fonctionnel, TemplateTechnique technique)
        {
            _fonctionnel = fonctionnel;
            _technique = technique;            
            _builderResult = new BuilderTemplateResult(_technique,_fonctionnel);
            _result = _builderResult.AddParent();
        }

        public TemplateResultItem BuilderAngularApp(string item)
        {
            _techniqueItem = FindTemplateTechniqueItem(item);
            TemplateResultItem result = _builderResult.AddChildren(_techniqueItem);
            _result.TemplateResultItem.Add(result);
            return result;
        }

        public TemplateResultItem BuilderAngularController(string item)
        {
            _techniqueItem = FindTemplateTechniqueItem(item);
            TemplateResultItem result = _builderResult.AddChildren(_techniqueItem);
            _result.TemplateResultItem.Add(result);
            return result;
        }

        public TemplateResultItem BuilderAngularRounting(string item)
        {
            _techniqueItem = FindTemplateTechniqueItem(item);
            TemplateResultItem result = _builderResult.AddChildren(_techniqueItem);
            _result.TemplateResultItem.Add(result);
            return result;
        }

        public TemplateResultItem BuilderAngularService(string item)
        {
            _techniqueItem = FindTemplateTechniqueItem(item);
            TemplateResultItem result = _builderResult.AddChildren(_techniqueItem);
            _result.TemplateResultItem.Add(result);
            return result;
        }

        public TemplateResultItem BuilderAngularView(string item)
        {
            _techniqueItem = FindTemplateTechniqueItem(item);
            TemplateResultItem result = _builderResult.AddChildren(_techniqueItem);
            _result.TemplateResultItem.Add(result);
            return result;
        }

        public TemplateTechniqueItem FindTemplateTechniqueItem(string item)
        {
            foreach(TemplateTechniqueItem techniqueItem in _technique.TemplateTechniqueItem)
            {
                if (techniqueItem.TemplateTechniqueItemName.ToLower()== item.ToLower())
                {
                    return techniqueItem;
                }
            }
            return null;
        }

        
    }
}
