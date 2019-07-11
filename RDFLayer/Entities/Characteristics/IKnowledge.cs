using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;
using CRMOntology.RDFLayer.Entities.Sales.Product;

namespace CRMOntology.RDFLayer.Entities.Characteristics
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#knowledge")]
    public interface IKnowledge
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:knowledge#")]
        string Id { get; }

        // TODO: Add other property references here
        [PropertyType("ex:aim#")]
        ICollection<IProduct> AimProducts { get; set; }

        [PropertyType("ex:need#")]
        ICollection<IProduct> NeedProducts { get; set; }

        [PropertyType("ex:want#")]
        ICollection<IProduct> WantProducts { get; set; }

        [PropertyType("ex:subClassOf#")]
        ICharacteristics baseClass { get; set; }
    }
}
