using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace CRMOntology.RDFLayer.Entities.Characteristics.Motivation.Consumer
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#consumer")]
    public interface IConsumer
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:consumer#")]
        string Id { get; }

        // TODO: Add other property references here

        [PropertyType("ex:subClassOf#")]
        IMotivation baseClass { get; set; }
    }
}
