using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace CRMOntology.RDFLayer.Entities.Demographics.Address.Postal.Country
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#country")]
    public interface ICountry
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:country#")]
        string Id { get; }

        // TODO: Add other property references here
        [PropertyType("ex:in#")]
        string Name { get; set; }

        [PropertyType("ex:subClassOf#")]
        IPostal baseClass { get; set; }
    }
}
