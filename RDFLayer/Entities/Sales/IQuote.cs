using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace CRMOntology.RDFLayer.Entities.Sales
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#quote")]
    public interface IQuote
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:quote#")]
        string Id { get; }

        // TODO: Add other property references here
        [PropertyType("ex:subClassOf#")]
        ISales baseClass { get; set; }
    }
}
