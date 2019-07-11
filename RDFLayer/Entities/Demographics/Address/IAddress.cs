using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;
using CRMOntology.RDFLayer.Entities.Demographics;
using CRMOntology.RDFLayer.Entities.Party.Customer;

namespace CRMOntology.RDFLayer.Entities.Demographics.Address
{
    public enum addresstype
    {
        Home,
        Work,
        Not_Specified
    }

    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#address")]
    public interface IAddress
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:address#")]
        string Id { get; }

        // TODO: Add other property references here
        
        [PropertyType("ex:addresstype#")]
        string AddressType { get; set; }

        [PropertyType("ex:islocationof#")]
        ICollection<ICustomer> Customers { get; set; } 

        [PropertyType("ex:subClassOf#")]
        IDemographics baseClass { get; set; }
    }
}
