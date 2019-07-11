using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;
using CRMOntology.RDFLayer.Entities.Characteristics;
using CRMOntology.RDFLayer.Entities.Characteristics.Perception;

namespace CRMOntology.RDFLayer.Entities.Party.Customer.Contact.Personality
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#personality")]
    public interface IPersonality
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:personality#")]
        string Id { get; }

        // TODO: Add other property references here

        [PropertyType("ex:positive#")]
        IPerception perception { get; set; }

        [PropertyType("ex:subClassOf#")]
        IContact baseClass { get; set; }
    }
}
