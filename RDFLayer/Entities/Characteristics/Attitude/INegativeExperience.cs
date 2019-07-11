using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;
using CRMOntology.RDFLayer.Entities.Sales.Product;

namespace CRMOntology.RDFLayer.Entities.Characteristics.Attitude
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#negative_experience")]
    public interface INegativeExperience
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:negative_experience#")]
        string Id { get; }

        // TODO: Add other property references here
        [PropertyType("ex:negative_experience#")]
        ICollection<IProduct> Products { get; set; }
        
        [PropertyType("ex:subClassOf#")]
        IAttitude baseClass { get; set; }
    }
}
