using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace CRMOntology.RDFLayer.Entities.Activity
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#activity")]
    public interface IActivity
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>        
        [Identifier("ex:activity#")]
        string Id { get; }

        // TODO: Add other property references here
    }
}
