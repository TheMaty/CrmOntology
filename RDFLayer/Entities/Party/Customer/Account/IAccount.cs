using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;
using CRMOntology.RDFLayer.Entities.Activity;
using CRMOntology.RDFLayer.Entities.Case;
using CRMOntology.RDFLayer.Entities.Demographics.Address;
using CRMOntology.RDFLayer.Entities.Party.Customer.Contact;

namespace CRMOntology.RDFLayer.Entities.Party.Customer.Account
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#account")]
    public interface IAccount
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:account#")]
        string Id { get; }

        // TODO: Add other property references here
        [PropertyType("ex:name#")]
        string Name { get; set; }

        [PropertyType("ex:hasAnnotation#")]
        ICollection<IAnnotation> Annotations { get; set; }

        [PropertyType("ex:hasAppointment#")]
        ICollection<IAppointment> Appointments { get; set; }

        [PropertyType("ex:hasEMail#")]
        ICollection<IEmail> EMails { get; set; }

        [PropertyType("ex:hasFax#")]
        ICollection<IFax> Faxes { get; set; }

        [PropertyType("ex:hasIssue#")]
        ICollection<IIncident> Incidents { get; set; }

        [PropertyType("ex:hasLetter#")]
        ICollection<ILetter> Letters { get; set; }

        [PropertyType("ex:hasPhoneCall#")]
        ICollection<IPhone> Phones { get; set; }

        [PropertyType("ex:hasTask#")]
        ICollection<ITask> Tasks { get; set; }

        [PropertyType("ex:isOwnedBy#")]
        ICollection<ISystemUser> SystemUsers { get; set; }

        [PropertyType("ex:isParentCustomerOf#")]
        ICollection<IAccount> Accounts { get; set; }

        [PropertyType("ex:isParentCustomerOf#")]
        ICollection<IContact> Contacts { get; set; }

        [PropertyType("ex:stayIn#")]
        ICollection<IAddress> Addresses { get; set; }

        [PropertyType("ex:subClassOf#")]
        ICustomer baseClass { get; set; }
    }
}
