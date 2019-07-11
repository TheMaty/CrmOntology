using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace CRMOntology.RDFLayer.Entities.Characteristics.Attitude
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#attitude")]
    public interface IAttitude
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:attitude#")]
        string Id { get; }

        // TODO: Add other property references here
        
        [PropertyType("ex:subClassOf#")]
        ICharacteristics baseClass { get; set; }
    }
}
