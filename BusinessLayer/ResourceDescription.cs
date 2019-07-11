using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CRMOntology.BusinessLayer
{
    class ResourceDescription
    {
        public string DatabaseMapName;
        public ResourceDatabase SourceDatabase;
        public ResourceDatabase StagingDatabase;
        public ResourceOWL OWLResource;
        public List<ResourceTable> ResourceTables;

        public ResourceDescription(XElement DatabaseMap)
        {
            ResourceTables = new List<ResourceTable>(); 
            DatabaseMapName = DatabaseMap.Attribute(XName.Get("name")).Value;
            foreach(XElement _xelement in DatabaseMap.Descendants(XName.Get("Database")))
            {
                ResourceDatabase _database = new ResourceDatabase(_xelement);
                if (_database.Type == "source")
                    SourceDatabase = _database;
                else
                    StagingDatabase = _database;

            }
            OWLResource = new ResourceOWL(DatabaseMap.Element(XName.Get("OWL")));

            foreach (XElement _xelement in DatabaseMap.Descendants(XName.Get("Table")))
            {
                ResourceTables.Add(new ResourceTable(_xelement));
            }
        }              
    }

}