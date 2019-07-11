using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace CRMOntology.RDFLayer.Entities.Demographics.Address
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#web")]
    public interface IWeb
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:web#")]
        string Id { get; }

        // TODO: Add other property references here

        [PropertyType("ex:URL#")]
        string URL { get; set; }

        [PropertyType("ex:subClassOf#")]
        IAddress baseClass { get; set; }
    }
}
