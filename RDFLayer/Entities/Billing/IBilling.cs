using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;
using CRMOntology.RDFLayer.Entities.Party.Customer;

namespace CRMOntology.RDFLayer.Entities.Billing
{
    public enum currency
    {
        NotSpecified,
        TL,
        Euro,
        USD
    }

    public enum paymentterm
    {
        NotSpecified,
        _percent_10_and_Net_30,
        Net30,
        Net45,
        Net60
    }
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#billing")]
    public interface IBilling
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:billing#")]
        string Id { get; }

        // TODO: Add other property references here
        [PropertyType("ex:currency#")]
        string Currency { get; set; }

        [PropertyType("ex:paymentterm#")]
        string PaymentTerm { get; set; }

        [PropertyType("ex:subClassOf#")]
        ICustomer baseClass { get; set; }
    }
}
