using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace CRMOntology.RDFLayer.Entities.Sales
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#order")]
    public interface IOrder
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:order#")]
        string Id { get; }

        // TODO: Add other property references here
        [PropertyType("ex:subClassOf#")]
        ISales baseClass { get; set; }
    }
}
