using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CRMOntology.BusinessLayer
{
    public class ResourceMap
    {
        public string From;
        public string FromType;
        public string To;
        public string ToType;
        public ResourceMap(XElement Map)
        {
            From = Map.Attribute(XName.Get("from")).Value;
            FromType = Map.Attribute(XName.Get("fromtype")).Value;
            To = Map.Attribute(XName.Get("to")).Value;
            ToType = Map.Attribute(XName.Get("totype")).Value;
        }
    }
}
