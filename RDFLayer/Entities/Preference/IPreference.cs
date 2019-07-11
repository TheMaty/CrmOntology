using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;
using CRMOntology.RDFLayer.Entities.Party.Customer;

namespace CRMOntology.RDFLayer.Entities.Preference
{
    public enum preferredmethodcode
    {
        Any,
        Email,
        Phone,
        Fax,
        Mail
    }

    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#preference")]
    public interface IPreference
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:preference#")]
        string Id { get; }

        // TODO: Add other property references here

        [PropertyType("ex:preferredmethod#")]
        string PreferredMethodCode { get; set; }

        [PropertyType("ex:subClassOf#")]
        ICustomer baseClass { get; set; }
    }
}
