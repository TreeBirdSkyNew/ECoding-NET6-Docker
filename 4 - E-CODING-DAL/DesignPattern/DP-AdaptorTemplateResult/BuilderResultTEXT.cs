using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using _4___E_CODING_DAL.Models;

namespace _4___E_CODING_DAL.DesignPattern
{
    public class BuilderResultTEXT
    {
        private readonly TemplateResultItem _result;
        private FileInfo file;
        private FileStream stream;
        private StreamWriter writer;

        public BuilderResultTEXT(TemplateResultItem result)
        {
            string FileName = @"TemplateResultText-" + _result.TemplateResultItemName;
            file = new FileInfo(FileName);
            stream = file.Open(FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
            writer = new StreamWriter(stream);
            _result = result;
            CreateTemplateResultText();
            CreateTemplateResultItemsText();
            Close();
        }

        public void CreateTemplateResultText()
        {
            writer.WriteLine("TemplateResultId : " + _result.TemplateResultId.ToString());
            writer.WriteLine("TemplateResultName : " + _result.TemplateResultItemName);
            writer.Close();
        }

        public void CreateTemplateResultItemsText()
        {

        }

        public void Close()
        {
            writer.Close();
            stream.Close();
        }
    }
}
