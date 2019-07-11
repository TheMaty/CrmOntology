using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;
using CRMOntology.RDFLayer.Entities.Party.Customer.Account;
using CRMOntology.RDFLayer.Entities.Party.Customer.Contact;

namespace CRMOntology.RDFLayer.Entities.Party
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#systemuser")]
    public interface ISystemUser
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:systemuser#")]
        string Id { get; }

        // TODO: Add other property references here
        [PropertyType("ex:isMemberOf#")]
        ICollection<ITeam> Teams { get; set; }

        [PropertyType("ex:isOwnerOf#")]
        ICollection<IAccount> Accounts { get; set; }

        [PropertyType("ex:isOwnerOf#")]
        ICollection<IContact> Contacts { get; set; }

        [PropertyType("ex:workIn#")]
        ICollection<IBusinessUnit> BusinessUnits { get; set; }

        [PropertyType("ex:subClassOf#")]
        IParty baseClass { get; set; }
    }
}
