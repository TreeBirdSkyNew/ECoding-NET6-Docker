using System;
using System.Collections.Generic;
using System.Text;
using _4___E_CODING_DAL.Models;

namespace _4___E_CODING_DAL.DesignPattern
{
    public class BuilderWebMVC : IBuilderWebMVC
    {
        private BuilderTemplateResult _builderResult;
        private TemplateFonctionnel _fonctionnel;
        private TemplateTechnique _technique;
        private TemplateTechniqueItem _techniqueItem;

        public BuilderWebMVC(TemplateFonctionnel fonctionnel, TemplateTechnique technique)
        {
            _fonctionnel = fonctionnel;
            _technique = technique;
            _builderResult = new BuilderTemplateResult(_technique, _fonctionnel);
            _builderResult.AddParent();
        }

        public TemplateResultItem BuilderActionFilter(string item)
        {
            _techniqueItem = FindTemplateTechniqueItem(item);
            TemplateResultItem result = _builderResult.AddChildren(_techniqueItem);
            _builderResult.GetTemplateResult().TemplateResultItem.Add(result);
            return result;
        }

        public TemplateResultItem BuilderConfiguration(string item)
        {
            _techniqueItem = FindTemplateTechniqueItem(item);
            TemplateResultItem result = _builderResult.AddChildren(_techniqueItem);
            _builderResult.GetTemplateResult().TemplateResultItem.Add(result);
            return result;
        }

        public TemplateResultItem BuilderConfigure(string item)
        {
            _techniqueItem = FindTemplateTechniqueItem(item);
            TemplateResultItem result = _builderResult.AddChildren(_techniqueItem);
            _builderResult.GetTemplateResult().TemplateResultItem.Add(result);
            return result;
        }

        public TemplateResultItem BuilderControllerMVC(string item)
        {
            _techniqueItem = FindTemplateTechniqueItem(item);
            TemplateResultItem result = _builderResult.AddChildren(_techniqueItem);
            _builderResult.GetTemplateResult().TemplateResultItem.Add(result);
            return result;
        }

        public TemplateResultItem BuilderControllerRouting(string item)
        {
            _techniqueItem = FindTemplateTechniqueItem(item);
            TemplateResultItem result = _builderResult.AddChildren(_techniqueItem);
            _builderResult.GetTemplateResult().TemplateResultItem.Add(result);
            return result;
        }

        public TemplateResultItem BuilderMiddleWare(string item)
        {
            _techniqueItem = FindTemplateTechniqueItem(item);
            TemplateResultItem result = _builderResult.AddChildren(_techniqueItem);
            _builderResult.GetTemplateResult().TemplateResultItem.Add(result);
            return result;
        }

        public TemplateResultItem BuilderResultFilter(string item)
        {
            _techniqueItem = FindTemplateTechniqueItem(item);
            TemplateResultItem result = _builderResult.AddChildren(_techniqueItem);
            _builderResult.GetTemplateResult().TemplateResultItem.Add(result);
            return result;
        }

        public TemplateTechniqueItem FindTemplateTechniqueItem(string item)
        {
            foreach (TemplateTechniqueItem techniqueItem in _technique.TemplateTechniqueItem)
            {
                if (techniqueItem.TemplateTechniqueItemName.ToLower() == item.ToLower())
                {
                    return techniqueItem;
                }
            }
            return null;
        }
    }

        
    
}
