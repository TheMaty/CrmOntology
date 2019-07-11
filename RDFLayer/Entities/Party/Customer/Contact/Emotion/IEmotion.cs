using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace CRMOntology.RDFLayer.Entities.Party.Customer.Contact.Emotions
{
    public enum valueadded
    {
        caredfor,
        confident,
        energized,
        excited,
        incontrol,
        pleassed,
        safed,
        stimulate,
        trusting,
        value
    }

    public enum valuedestroy
    {
        confused,
        disappointed,
        dissatisfied,
        frustrated,
        hurried,
        irritated,
        neglected,
        stressed,
        unhappy
    }

    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#emotion")]
    public interface IEmotion
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:emotion#")]
        string Id { get; }

        // TODO: Add other property references here
        
        [PropertyType("ex:valueadded#")]
        string ValueAdded { get; set; }

        [PropertyType("ex:valuedestroy#")]
        string ValueDestroy { get; set; }

        
        [PropertyType("ex:subClassOf#")]
        IContact baseClass { get; set; }
    }
}
