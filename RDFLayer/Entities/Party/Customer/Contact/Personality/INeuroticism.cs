using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;
using CRMOntology.RDFLayer.Entities.Characteristics.Perception;

namespace CRMOntology.RDFLayer.Entities.Party.Customer.Contact.Personality
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#neuroticism")]
    public interface INeuroticism
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:neuroticism#")]
        string Id { get; }

        // TODO: Add other property references here

        [PropertyType("ex:negative#")]
        IPerception Negative { get; set; }

        [PropertyType("ex:subClassOf#")]
        IPersonality baseClass { get; set; }
    }
}
