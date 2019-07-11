using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;
using CRMOntology.RDFLayer.Entities.Party.Customer;

namespace CRMOntology.RDFLayer.Entities.Demographics
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#demographics")]
    public interface IDemographics
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:demographics#")]
        string Id { get; }

        // TODO: Add other property references here

        [PropertyType("ex:anniversary#")]
        DateTime Anniversary { get; set; }

        [PropertyType("ex:birthdate#")]
        DateTime BirthDate { get; set; }

        [PropertyType("ex:establishdate#")]
        DateTime EstablishDate { get; set; }

        [PropertyType("ex:income#")]
        decimal Income { get; set; }

        [PropertyType("ex:subClassOf#")]
        ICustomer baseClass { get; set; }
    }
}
