using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;
using CRMOntology.RDFLayer.Entities.Party.Customer.Contact.Emotions;

namespace CRMOntology.RDFLayer.Entities.Characteristics.Perception.Self
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#self")]
    public interface ISelf
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:self#")]
        string Id { get; }

        // TODO: Add other property references here
        [PropertyType("ex:emotion#")]
        ICollection<IEmotion> Emotions { get; set; }

        //[Disjoint("ex:subClassOf#", "IAccount")]
        [PropertyType("ex:subClassOf#")]
        IPerception baseClass { get; set; }
    }
}
