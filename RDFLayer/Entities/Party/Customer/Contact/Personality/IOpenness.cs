using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace CRMOntology.RDFLayer.Entities.Party.Customer.Contact.Personality
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#openness")]
    public interface IOpenness
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:openness#")]
        string Id { get; }

        // TODO: Add other property references here

        [PropertyType("ex:subClassOf#")]
        IPersonality baseClass { get; set; }
    }
}
