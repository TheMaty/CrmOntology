using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;
using CRMOntology.RDFLayer.Entities.Demographics;

namespace CRMOntology.RDFLayer.Entities.Demographics.MartialStatus
{
    public enum martialstatus
    {
        Divorced,
        Married,
        Single,
        Widowed
    }

    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#martialstatus")]
    public interface IMaritialStatus
    {        
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:martialstatus#")]
        string Id { get; }

        // TODO: Add other property references here
        [Identifier("ex:marriagestatus#")]
        string MarriageStatus { get; }

        //[Disjoint("ex:subClassOf#", "IAccount")]
        [PropertyType("ex:subClassOf#")]
        IDemographics baseClass { get; set; }
    }
}
