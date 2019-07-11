using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;
using CRMOntology.RDFLayer.Entities.Party.Customer.Account;
using CRMOntology.RDFLayer.Entities.Party.Customer.Contact;

namespace CRMOntology.RDFLayer.Entities
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#annotation")]
    public interface IAnnotation
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:annotation#")]
        string Id { get; }

        // TODO: Add other property references here
        [PropertyType("ex:hasAttachment#")]
        ICollection<IAttachment> Attachments { get; set; }

        [PropertyType("ex:leaveNote#")]
        ICollection<IAccount> Accounts { get; set; }

        [PropertyType("ex:leaveNote#")]
        ICollection<IContact> Contacts { get; set; }
    }
}
