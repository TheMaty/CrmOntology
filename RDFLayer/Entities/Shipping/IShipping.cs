using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;
using CRMOntology.RDFLayer.Entities.Party.Customer;

namespace CRMOntology.RDFLayer.Entities.Shipping
{
    public enum freightterm
    {
        FOB,
        No_Charge
    }

    public enum method
    {
        Airbone,
        DHL,
        FedEx,
        Full_Load,
        Postal_Mail,
        UPS,
        Will_Call,
        Not_Specified
    }

    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#shipping")]
    public interface IShipping
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:shipping#")]
        string Id { get; }

        // TODO: Add other property references here

        [PropertyType("ex:freightterm#")]
        string FreightTerm { get; set; }

        [PropertyType("ex:method#")]
        string Method { get; set; }

        [PropertyType("ex:subClassOf#")]
        ICustomer baseClass { get; set; }
    }
}
