using CRMOntology.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace CRMOntology.BusinessLayer
{
    public class OWLConfiguration
    {
        List<XElement> _owlConfigurations;
        private XDocument _xDoc;
        public List<XElement> OWLConfigurations
        {
            get 
            { 
                return _owlConfigurations; 
            }
            set
            {
                _owlConfigurations = value;
            }
        }
        public OWLConfiguration()
        {
            XmlDocument xdoc = new XmlDocument();
            if (!File.Exists("OWLConfiguration.xml"))
            {
                xdoc.LoadXml(Resources.OWLConfigurationXSD);
                xdoc.Save("OWLConfiguration.xsd");
                xdoc.LoadXml(Resources.OWLConfigurationXML);
                xdoc.Save("OWLConfiguration.xml");
            }
            else
                xdoc.Load("OWLConfiguration.xml");

            _xDoc = XDocument.Parse(xdoc.InnerXml);
            _owlConfigurations = _xDoc.Descendants(XName.Get("OWLConfiguration")).ToList<XElement>();
        }
        public void Save()
        {
            using (StreamWriter writer = new StreamWriter(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\OWLConfiguration.xml"))
            {
                writer.WriteLine(@"<?xml version=""1.0"" encoding=""utf-8"" ?>");
                writer.WriteLine("<Ontology>");
                writer.WriteLine(string.Concat(_owlConfigurations));
                writer.WriteLine("</Ontology>");
                writer.Flush();
            }
        }

    }
}
