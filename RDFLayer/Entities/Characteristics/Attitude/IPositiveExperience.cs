using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;
using CRMOntology.RDFLayer.Entities.Sales.Product;

namespace CRMOntology.RDFLayer.Entities.Characteristics.Attitude
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#positive_experience")]
    public interface IPositiveExperience
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:positive_experience#")]
        string Id { get; }

        // TODO: Add other property references here
        [PropertyType("ex:positive_experience#")]
        ICollection<IProduct> Products { get; set; }

        [PropertyType("ex:subClassOf#")]
        IAttitude baseClass { get; set; }
    }
}
