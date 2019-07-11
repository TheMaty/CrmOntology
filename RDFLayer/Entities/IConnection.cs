using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;
using CRMOntology.RDFLayer.Entities.Party.Customer.Account;
using CRMOntology.RDFLayer.Entities.Party.Customer.Contact;

namespace CRMOntology.RDFLayer.Entities
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#connection")]
    public interface IConnection
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:connection#")]
        string Id { get; }

        // TODO: Add other property references here
        [PropertyType("ex:connectTo#")]
        ICollection<IAccount> Accounts { get; set; }

        [PropertyType("ex:connectTo#")]
        ICollection<IContact> Contacts { get; set; }
    }
}
