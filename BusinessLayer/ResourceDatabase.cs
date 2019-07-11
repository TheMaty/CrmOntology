using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CRMOntology.BusinessLayer
{
    class ResourceDatabase
    {
        public string ConnectionString;
        public string Type;

        public ResourceDatabase (XElement Database)
        {
            ConnectionString = Database.Attribute(XName.Get("connectionString")).Value;
            Type = Database.Attribute(XName.Get("type")).Value;
        }
    }
}
