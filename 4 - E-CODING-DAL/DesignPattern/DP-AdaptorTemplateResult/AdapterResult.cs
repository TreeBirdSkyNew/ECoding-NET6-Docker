using System;
using System.Collections.Generic;
using System.Text;

namespace _4___E_CODING_DAL.DesignPattern
{
    class AdapterResult : ITarget
    {
        private readonly AdapteeResult _adaptee;

        public AdapterResult(AdapteeResult adaptee)
        {
            this._adaptee = adaptee;
        }

        public void GetResultJSON()
        {
            throw new NotImplementedException();
        }

        public void GetResultTEXT()
        {
            this._adaptee.GetResultTEXT();
        }

        public void GetResultText()
        {
            throw new NotImplementedException();
        }

        public void GetResultXML()
        {
            this._adaptee.GetResultXML();
        }

        
    }
}
