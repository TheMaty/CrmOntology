using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace CRMOntology.RDFLayer.Entities.Characteristics.Perception
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#perception")]
    public interface IPerception
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:perception#")]
        string Id { get; }

        // TODO: Add other property references here

        [PropertyType("ex:benefit#")]
        bool benefit { get; set; }

        [PropertyType("ex:price#")]
        bool price { get; set; }

        [PropertyType("ex:subClassOf#")]
        ICharacteristics baseClass { get; set; }
    }
}
