using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace CRMOntology.RDFLayer.Entities.Demographics.Address
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#electronic")]
    public interface IElectronic
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:electronic#")]
        string Id { get; }

        // TODO: Add other property references here

        [PropertyType("ex:emailaddress#")]
        string EMailAddress { get; set; }

        [PropertyType("ex:subClassOf#")]
        IAddress baseClass { get; set; }
    }
}
