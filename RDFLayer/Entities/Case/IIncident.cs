using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;
using CRMOntology.RDFLayer.Entities.Party.Customer.Contact;
using CRMOntology.RDFLayer.Entities.Party.Customer.Account;

namespace CRMOntology.RDFLayer.Entities.Case
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#incident")]
    public interface IIncident
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:incident#")]
        string Id { get; }

        // TODO: Add other property references here
        [PropertyType("ex:complaintOf#")]
        ICollection<IAccount> Accounts { get; set; }

        [PropertyType("ex:complaintOf#")]
        ICollection<IContact> Contacts { get; set; }

        [PropertyType("ex:subClassOf#")]
        ICase baseClass { get; set; }
    }
}
