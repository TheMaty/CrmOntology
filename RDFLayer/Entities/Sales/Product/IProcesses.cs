using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace CRMOntology.RDFLayer.Entities.Sales.Product
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#processes")]
    public interface IProcesses
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:processes#")]
        string Id { get; }

        // TODO: Add other property references here
        [PropertyType("ex:subClassOf#")]
        IProduct baseClass { get; set; }
    }
}
