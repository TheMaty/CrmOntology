using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace CRMOntology.RDFLayer.Entities.Billing.Credict
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#credict")]
    public interface ICredict
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:credict#")]
        string Id { get; }

        // TODO: Add other property references here
        [PropertyType("ex:hold#")]
        bool Hold { get; set; }

        [PropertyType("ex:limit#")]
        decimal Limit { get; set; }

        [PropertyType("ex:subClassOf#")]
        IBilling baseClass { get; set; }
    }
}
