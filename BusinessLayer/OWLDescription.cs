using System;
using System.Collections.Generic;
using BL = CRMOntology.BusinessLayer;
using System.Text;
using System.Xml.Linq;

namespace CRMOntology.BusinessLayer
{
    class OWLDescription
    {
        public ResourceDatabase StagingDatabase;
        public List<IFactory> OWLItems;        

        public OWLDescription(XElement OWLMap)
        {
            StagingDatabase = new ResourceDatabase(OWLMap.Element(XName.Get("Database")));

            OWLItems = new List<IFactory>();
            foreach (XElement _xelement in OWLMap.Descendants(XName.Get("OWLItem")))
            {
                if (_xelement.Attribute(XName.Get("type")).Value == "Accurate")
                    OWLItems.Add(OWLItem.CreateOWLItem(_xelement));
            }
        }       
    }
}
