using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;
using CRMOntology.RDFLayer.Entities.Sales.Product;

namespace CRMOntology.RDFLayer.Entities.Characteristics.Motivation.Consumer
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#drive")]
    public interface IDrive
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:drive#")]
        string Id { get; }

        // TODO: Add other property references here
        [PropertyType("ex:to#")]
        ICollection<IProduct> Products { get; set; }

        [PropertyType("ex:subClassOf#")]
        IConsumer baseClass { get; set; }
    }
}
