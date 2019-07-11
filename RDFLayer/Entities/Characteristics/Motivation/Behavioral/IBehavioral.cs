using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace CRMOntology.RDFLayer.Entities.Characteristics.Motivation.Behavioral
{
    public enum esteem
    {
        appreciated,
        confident,
        important,
        respect_of_others,
        self_respect
    }

    public enum physicological
    {
        excersise,
        food,
        sleep,
        water
    }

    public enum safety
    {
        normalcy,
        security,
        shelter
    }

    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#behavioral")]
    public interface IBehavioral
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:behavioral#")]
        string Id { get; }

        // TODO: Add other property references here

        [PropertyType("ex:esteem#")]
        string Esteem { get; set; }

        //[Disjoint("ex:physicological#", "IAccount")]
        [PropertyType("ex:physicological#")]
        string Physicological { get; set; }

        [PropertyType("ex:safety#")]
        string Safety { get; set; }

        [PropertyType("ex:subClassOf#")]
        IMotivation baseClass { get; set; }
    }
}
