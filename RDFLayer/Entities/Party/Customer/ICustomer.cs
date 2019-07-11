using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;
using CRMOntology.RDFLayer.Entities.Sales;

namespace CRMOntology.RDFLayer.Entities.Party.Customer
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#customer")]
    public interface ICustomer
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:customer#")]
        string Id { get; }

        // TODO: Add other property references here
        [PropertyType("ex:subClassOf#")]
        IParty baseClass { get; set; }
    }
}
