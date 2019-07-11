using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CRMOntology.BusinessLayer
{
    class ResourceOWL
    {
        public string Path;
        public string Type;

        public ResourceOWL (XElement OWL)
        {
            Path = OWL.Attribute(XName.Get("path")).Value;
            Type = OWL.Attribute(XName.Get("type")).Value;
        }
    }
}
