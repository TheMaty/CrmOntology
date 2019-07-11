using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;
using CRMOntology.RDFLayer.Entities.Party.Customer;

namespace CRMOntology.RDFLayer.Entities.Characteristics
{
    public enum belief
    {
        high_quality_product,
        innovative,
        leader,
        low_price,
        trust
    }
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#characteristics")]
    public interface ICharacteristics
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:characteristics#")]
        string Id { get; }

        // TODO: Add other property references here 
        [PropertyType("ex:belief#")]
        string Belief { get; set; }

        [PropertyType("ex:subClassOf#")]
        ICustomer baseClass { get; set; }
    }
}
