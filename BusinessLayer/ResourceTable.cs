using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CRMOntology.BusinessLayer
{
    public class ResourceTable
    {
        public string Name;
        public List<ResourceMap> ResourceMaps;

        public ResourceTable(XElement Table)
        {
            Name = Table.Attribute(XName.Get("name")).Value;
            
            ResourceMaps = new List<ResourceMap>(); 

            foreach (XElement _xelement in Table.Descendants(XName.Get("Map")))
            {
                ResourceMaps.Add(new ResourceMap(_xelement));
            }
        }
    }
}
