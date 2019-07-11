using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace CRMOntology.RDFLayer.Entities.Party.Customer
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#lead")]
    public interface ILead
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:lead#")]
        string Id { get; }

        // TODO: Add other property references here        
        [PropertyType("ex:subClassOf#")]
        ICustomer baseClass { get; set; }
    }
}
