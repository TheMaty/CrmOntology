using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;
using CRMOntology.RDFLayer.Entities.Party.Customer.Account;
using CRMOntology.RDFLayer.Entities.Party.Customer.Contact;

namespace CRMOntology.RDFLayer.Entities.Sales
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#opportunity")]
    public interface IOpportunity
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:opportunity#")]
        string Id { get; }

        // TODO: Add other property references here
        [PropertyType("ex:isFor#")]
        ICollection<IAccount> Accounts { get; set; }

        [PropertyType("ex:isFor#")]
        ICollection<IContact> Contacts { get; set; }

        [PropertyType("ex:subClassOf#")]
        ISales baseClass { get; set; }
    }
}
