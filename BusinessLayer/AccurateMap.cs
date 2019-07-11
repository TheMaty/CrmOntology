using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CRMOntology.BusinessLayer
{
    class AccurateMap
    {
        public string Key;
        public string Value;

        public AccurateMap(XElement Map)
        {
            Key = Map.Attribute(XName.Get("key")).Value;
            Value = Map.Attribute(XName.Get("value")).Value;
        }
    }
}
