using System;
using System.Collections.Generic;
using System.Text;
using _4___E_CODING_DAL.Models;

namespace _4___E_CODING_DAL.DesignPattern
{
    public class EntityFrameworkCode
    {
        public Director _director;
        private readonly TemplateTechnique _technique;
        private readonly TemplateFonctionnel _fonctionnel;
        private BuilderTemplateResult _builderResult;
        IBuilderEntityFramework _builderEntityFramework;

        public EntityFrameworkCode(TemplateTechnique technique, TemplateFonctionnel fonctionnel)
        {
            /************************************************************************/
            _director = new Director();
            _technique = technique;
            _fonctionnel = fonctionnel;
            _builderResult = new BuilderTemplateResult(_technique, _fonctionnel);
            _builderEntityFramework = new BuilderEntityFramework(_fonctionnel,_technique);
        }

        public void BuildDAL()
        {   
            TemplateResultItem resultEntityFramework = _builderEntityFramework.BuildDAL("BuildDAL");
            AdapteeResult adapteeEntityFramework = new AdapteeResult(resultEntityFramework);
            ITarget targetEntityFramework = new AdapterResult(adapteeEntityFramework);
            adapteeEntityFramework.GetResultTEXT();
            adapteeEntityFramework.GetResultXML();
        }

        public void BuildEFDbContext()
        {
            TemplateResultItem resultEntityFramework = _builderEntityFramework.BuildEFDbContext("BuildEFDbContext");
            AdapteeResult adapteeEntityFramework = new AdapteeResult(resultEntityFramework);
            ITarget targetEntityFramework = new AdapterResult(adapteeEntityFramework);
            adapteeEntityFramework.GetResultTEXT();
            adapteeEntityFramework.GetResultXML();
        }

        public void BuildEFConfiguration()
        {
            TemplateResultItem resultEntityFramework = _builderEntityFramework.BuildEFConfiguration("BuildEFConfiguration");
            AdapteeResult adapteeEntityFramework = new AdapteeResult(resultEntityFramework);
            ITarget targetEntityFramework = new AdapterResult(adapteeEntityFramework);
            adapteeEntityFramework.GetResultTEXT();
            adapteeEntityFramework.GetResultXML();
        }

    }
}
