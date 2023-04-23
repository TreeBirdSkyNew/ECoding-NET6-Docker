using System;
using System.Collections.Generic;
using System.Text;
using _4___E_CODING_DAL.Models;

namespace _4___E_CODING_DAL.DesignPattern
{
    public class AdapteeResult
    {
        private TemplateResultItem _templateResultAdaptee;
        private BuilderResultXML _builderXML;
        private BuilderResultTEXT _builderTEXT;

        public AdapteeResult(TemplateResultItem templateResultAdaptee)
        {
            _templateResultAdaptee = templateResultAdaptee;
            _builderXML = new BuilderResultXML(_templateResultAdaptee);
        }

        public void GetResultXML()
        {
            _builderXML = new BuilderResultXML(_templateResultAdaptee);
        }

        public void GetResultTEXT()
        {
            _builderTEXT = new BuilderResultTEXT(_templateResultAdaptee);
        }


    }
}
