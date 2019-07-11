using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace CRMOntology.RDFLayer.Entities.Party.Customer.Account.Type
{
    public enum corporation
    {
        _holding,
        _limited,
        _private
    }

    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#type")]
    public interface IType
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:type#")]
        string Id { get; }

        // TODO: Add other property references here
        [PropertyType("ex:corporation#")]
        string Corporation { get; set; }

        [PropertyType("ex:subClassOf#")]
        IAccount baseClass { get; set; }
    }
}
