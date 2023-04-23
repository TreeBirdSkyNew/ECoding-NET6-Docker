using _4___E_CODING_DAL.DesignPattern;
using _4___E_CODING_DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4___E_CODING_DAL.DesignPattern
{
    public class BuilderWebApi : IBuilderWebApi
    {
        private BuilderTemplateResult _builderResult;
        private TemplateFonctionnel _fonctionnel;
        private TemplateTechnique _technique;
        private TemplateTechniqueItem _techniqueItem;

        public BuilderWebApi(TemplateFonctionnel fonctionnel, TemplateTechnique technique)
        {
            _fonctionnel = fonctionnel;
            _technique = technique;
            _builderResult = new BuilderTemplateResult(_technique, _fonctionnel);
            _builderResult.AddParent();
        }

        public TemplateResultItem BuilderApiActionFilter(string item)
        {
            _techniqueItem = FindTemplateTechniqueItem(item);
            TemplateResultItem result = _builderResult.AddChildren(_techniqueItem);
            _builderResult.GetTemplateResult().TemplateResultItem.Add(result);
            return result;
        }

        public TemplateResultItem BuilderApiConfiguration(string item)
        {
            _techniqueItem = FindTemplateTechniqueItem(item);
            TemplateResultItem result = _builderResult.AddChildren(_techniqueItem);
            _builderResult.GetTemplateResult().TemplateResultItem.Add(result);
            return result;
        }

        public TemplateResultItem BuilderApiConfigure(string item)
        {
            _techniqueItem = FindTemplateTechniqueItem(item);
            TemplateResultItem result = _builderResult.AddChildren(_techniqueItem);
            _builderResult.GetTemplateResult().TemplateResultItem.Add(result);
            return result;
        }

        public TemplateResultItem BuilderApiMiddleWare(string item)
        {
            _techniqueItem = FindTemplateTechniqueItem(item);
            TemplateResultItem result = _builderResult.AddChildren(_techniqueItem);
            _builderResult.GetTemplateResult().TemplateResultItem.Add(result);
            return result;
        }

        public TemplateResultItem BuilderApiResultFilter(string item)
        {
            _techniqueItem = FindTemplateTechniqueItem(item);
            TemplateResultItem result = _builderResult.AddChildren(_techniqueItem);
            _builderResult.GetTemplateResult().TemplateResultItem.Add(result);
            return result;
        }

        public TemplateResultItem BuilderApiRouting(string item)
        {
            _techniqueItem = FindTemplateTechniqueItem(item);
            TemplateResultItem result = _builderResult.AddChildren(_techniqueItem);
            _builderResult.GetTemplateResult().TemplateResultItem.Add(result);
            return result;
        }

        public TemplateResultItem BuilderControllerWebApi(string item)
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
