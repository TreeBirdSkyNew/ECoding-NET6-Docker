using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using _4___E_CODING_DAL.Models;

namespace _4___E_CODING_DAL.DesignPattern
{
    public class BuilderResultXML
    {
        private readonly TemplateResultItem _result;
        private XmlDocument xmlDoc;

        public BuilderResultXML(TemplateResultItem result)
        {
            _result = result;
            xmlDoc = new XmlDocument();            
            ResultXML();
        }

        public void ResultXML()
        {
            XmlNode resultNode = xmlDoc.CreateElement("TemplateResultItem");

            XmlAttribute attributeResultItemId = xmlDoc.CreateAttribute("TemplateResultItemId");
            attributeResultItemId.Value = _result.TemplateResultItemId.ToString();
            resultNode.Attributes.Append(attributeResultItemId);
            resultNode.InnerText = _result.TemplateResultItemId.ToString();
            resultNode.AppendChild(attributeResultItemId);
            
            XmlAttribute attributeInitialContent = xmlDoc.CreateAttribute("TemplateResultInitialContent");
            attributeInitialContent.Value = _result.TemplateResultInitialContent;
            resultNode.Attributes.Append(attributeInitialContent);
            resultNode.InnerText = _result.TemplateResultInitialContent.ToString();
            resultNode.AppendChild(attributeInitialContent);

            XmlAttribute attributeFinalContent = xmlDoc.CreateAttribute("TemplateResultFinalContent");
            attributeFinalContent.Value = _result.TemplateResultFinalContent;
            resultNode.Attributes.Append(attributeFinalContent);
            resultNode.InnerText = _result.TemplateResultFinalContent.ToString();
            resultNode.AppendChild(attributeFinalContent);

            XmlAttribute attributeItemDescription = xmlDoc.CreateAttribute("TemplateResultItemDescription");
            attributeItemDescription.Value = _result.TemplateResultItemDescription;
            resultNode.Attributes.Append(attributeItemDescription);
            resultNode.InnerText = _result.TemplateResultItemDescription;
            resultNode.AppendChild(attributeItemDescription);

            XmlAttribute attributeItemTitle = xmlDoc.CreateAttribute("TemplateResultItemTitle");
            attributeItemTitle.Value = _result.TemplateResultItemTitle;
            resultNode.Attributes.Append(attributeItemTitle);
            resultNode.InnerText = _result.TemplateResultItemTitle.ToString();
            resultNode.AppendChild(attributeItemTitle);

            XmlAttribute attributeItemVersion = xmlDoc.CreateAttribute("TemplateResultItemVersion");
            attributeItemVersion.Value = _result.TemplateResultItemVersion;
            resultNode.Attributes.Append(attributeItemVersion);
            resultNode.InnerText = _result.TemplateResultItemVersion.ToString();
            resultNode.AppendChild(attributeItemVersion);

            XmlAttribute attributeItemVersionNET = xmlDoc.CreateAttribute("TemplateResultItemVersionNET");
            attributeItemVersionNET.Value = _result.TemplateResultItemVersionNET;
            resultNode.Attributes.Append(attributeItemVersionNET);
            resultNode.InnerText = _result.TemplateResultItemVersionNET;
            resultNode.AppendChild(attributeItemVersion);

            xmlDoc.AppendChild(resultNode);

            xmlDoc.Save(@"TemplateResultXML-Name-Id");
        }

        

    }
}
