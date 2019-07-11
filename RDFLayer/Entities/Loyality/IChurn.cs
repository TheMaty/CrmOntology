using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;
using CRMOntology.RDFLayer.Entities.Party.Customer;

namespace CRMOntology.RDFLayer.Entities.Loyality
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#churn")]
    public interface IChurn
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:churn#")]
        string Id { get; }

        // TODO: Add other property references here
        [PropertyType("ex:rate#")]
        int Rate { get; set; }

        [PropertyType("ex:subClassOf#")]
        ICustomer baseClass { get; set; }
    }
}
