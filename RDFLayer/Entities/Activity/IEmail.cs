using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;
using CRMOntology.RDFLayer.Entities.Party.Customer.Account;
using CRMOntology.RDFLayer.Entities.Party.Customer.Contact;

namespace CRMOntology.RDFLayer.Entities.Activity
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#email")]
    public interface IEmail
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:email#")]
        string Id { get; }

        // TODO: Add other property references here
        [PropertyType("ex:sentTo#")]
        ICollection<IAccount> Accounts { get; set; }

        [PropertyType("ex:sentTo#")]
        ICollection<IContact> Contacts { get; set; }

        [PropertyType("ex:subClassOf#")]
        IActivity baseClass { get; set; }
    }
}
