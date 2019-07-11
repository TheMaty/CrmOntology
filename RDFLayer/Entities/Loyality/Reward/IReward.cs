using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace CRMOntology.RDFLayer.Entities.Loyality.Reward
{
    public enum avantgarde
    { 
        _1000Points,
        _750Points,
        _500Points
    }

    public enum classic
    {
        _50Points,
        _100Points,
        _250Points
    }

    public enum vip
    {
        _5000Points,
        _7500Points,
        _10000Points
    }

    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#reward")]
    public interface IReward
    {       
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:reward#")]
        string Id { get; }

        // TODO: Add other property references here

        [PropertyType("ex:avantgarde#")]
        string Avantgarde { get; set; }

        [PropertyType("ex:classic#")]
        string Classic { get; set; }
       
        [PropertyType("ex:vip#")]
        string VIP { get; set; }

        [PropertyType("ex:subClassOf#")]
        ILoyality baseClass { get; set; }
    }
}
