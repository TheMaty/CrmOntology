using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace CRMOntology.BusinessLayer
{
    public class OWLItem : IFactory
    {
        public static IFactory CreateOWLItem(XElement Item)
        {
            switch (Item.Attribute(XName.Get("type")).Value)
            {
                case "Accurate":
                     return new Accurate(Item);
                default:
                     return null;
            }
            
        }

        public virtual string Type
        {
            get { throw new NotImplementedException(); }
        }

        public virtual string toXML
        {
            get { throw new NotImplementedException(); }
        }

        public virtual XElement toElement
        {
            get { throw new NotImplementedException(); }
        }

        public void Save()
        {
            XmlDocument xdoc = new XmlDocument();
            if (!File.Exists("OWLConfiguration.xml"))
            {
                throw new Exception("OWLConfiguration.xml is not found in " + Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            }
            else
                xdoc.Load("OWLConfiguration.xml");

            XDocument _xDoc; _xDoc = XDocument.Parse(xdoc.InnerXml);
            List<XElement> _owlItems = _xDoc.Descendants(XName.Get("OWLItem")).ToList<XElement>();

            XElement _object = _owlItems.Single(x => x.Attribute(XName.Get("type")).Value == Type);
            
            _object.ReplaceWith(toElement);

            using (XmlWriter writer = XmlWriter.Create(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\OWLConfiguration.xml"))
            {
                _xDoc.WriteTo(writer);
                writer.Flush();
            }
        }           
    }
}
