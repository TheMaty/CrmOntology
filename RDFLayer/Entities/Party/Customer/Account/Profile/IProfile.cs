using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace CRMOntology.RDFLayer.Entities.Party.Customer.Account.Profile
{
    public enum industry
    {
        accounting,
        agriculture,
        retail,
        technology,
        other
    }

    public enum ownership
    {
        _other,
        _private,
        _public,
        _subsdiary
    }


    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#profile")]
    public interface IProfile
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:profile#")]
        string Id { get; }

        // TODO: Add other property references here

        [PropertyType("ex:industry#")]
        string Industry { get; set; }

        [PropertyType("ex:ownership#")]
        string Ownership { get; set; }

        [PropertyType("ex:sic#")]
        string code { get; set; }

        [PropertyType("ex:subClassOf#")]
        IAccount baseClass { get; set; }
    }
}