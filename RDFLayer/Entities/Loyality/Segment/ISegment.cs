using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace CRMOntology.RDFLayer.Entities.Loyality.Segment
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#segment")]
    public interface ISegment
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:segment#")]
        string Id { get; }

        // TODO: Add other property references here

        [PropertyType("ex:subClassOf#")]
        ILoyality baseClass { get; set; }
    }
}
