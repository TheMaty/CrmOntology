using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace CRMOntology.RDFLayer.Entities.Case
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#entitlement")]
    public interface IEntitlement
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:entitlement#")]
        string Id { get; }

        // TODO: Add other property references here
        [PropertyType("ex:subClassOf#")]
        ICase baseClass { get; set; }
    }
}
