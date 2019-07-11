using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace CRMOntology.RDFLayer.Entities.Party
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#businessunit")]
    public interface IBusinessUnit
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:businessunit#")]
        string Id { get; }

        // TODO: Add other property references here      
        [PropertyType("ex:host#")]
        ICollection<ISystemUser> SystemUsers { get; set; }

        [PropertyType("ex:subClassOf#")]
        IParty baseClass { get; set; }
    }
}
