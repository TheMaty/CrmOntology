using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace CRMOntology.RDFLayer.Entities.Demographics
{
    public enum gender
    {
        Male,
        Female,
        Not_Specified
    }

    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#gender")]
    public interface IGender
    {      
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:gender#")]
        string Id { get; }

        // TODO: Add other property references here

        [PropertyType("ex:gender#")]
        string Sex { get; set; }

        [PropertyType("ex:subClassOf#")]
        IDemographics baseClass { get; set; }
    }
}
