using System;
using System.Collections.Generic;
using System.Text;
using _4___E_CODING_DAL.Models;

namespace _4___E_CODING_DAL.DesignPattern
{
    public class BuilderEntityFramework : IBuilderEntityFramework
    {
        private BuilderTemplateResult _builderResult;
        private TemplateFonctionnel _fonctionnel;
        private TemplateTechnique _technique;
        private TemplateTechniqueItem _techniqueItem;
        public BuilderEntityFramework(TemplateFonctionnel fonctionnel, TemplateTechnique technique)
        {
            _fonctionnel = fonctionnel;
            _technique = technique;
            _builderResult = new BuilderTemplateResult(_technique, _fonctionnel);
        }

        public TemplateResultItem BuildEFDbContext(string item)
        {
            _techniqueItem = FindTemplateTechniqueItem(item);
            TemplateResultItem result = _builderResult.AddChildren(_techniqueItem);
            _builderResult.GetTemplateResult().TemplateResultItem.Add(result);
            return result;
        }

        public TemplateResultItem BuildEFConfiguration(string item)
        {
            _techniqueItem = FindTemplateTechniqueItem(item);
            TemplateResultItem result = _builderResult.AddChildren(_techniqueItem);
            _builderResult.GetTemplateResult().TemplateResultItem.Add(result);
            return result;
        }

        public TemplateResultItem BuildDAL(string item)
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
