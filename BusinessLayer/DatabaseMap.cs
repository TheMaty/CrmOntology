using CRMOntology.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CRMOntology.BusinessLayer
{
    public class DatabaseMap
    {        
        List<XElement> _databaseMaps;
        private XDocument _xDoc;
        public List<XElement> DatabaseMaps
        {
            get 
            { 
                return _databaseMaps; 
            }
            set
            {
                _databaseMaps = value;
            }
        }
        public DatabaseMap()
        {
            XmlDocument xdoc = new XmlDocument();
            if (!File.Exists("DatabaseMap.xml"))
            {
                xdoc.LoadXml(Resources.DatabaseMapXSD);
                xdoc.Save("DatabaseMap.xsd");
                xdoc.LoadXml(Resources.DatabaseMapXML);
                xdoc.Save("DatabaseMap.xml");
            }
            else
                xdoc.Load("DatabaseMap.xml");

            _xDoc = XDocument.Parse(xdoc.InnerXml);
            _databaseMaps = _xDoc.Descendants(XName.Get("DatabaseMap")).ToList<XElement>();
        }
        public void Save()
        {
            using (StreamWriter writer = new StreamWriter(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\DatabaseMap.xml"))
            {
                writer.WriteLine(@"<?xml version=""1.0"" encoding=""utf-8"" ?>");
                writer.WriteLine("<Ontology>");
                writer.WriteLine(string.Concat(_databaseMaps));
                writer.WriteLine("</Ontology>");
                writer.Flush();
            }
        }
    }
}
