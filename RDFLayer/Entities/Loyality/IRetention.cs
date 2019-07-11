using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;
using CRMOntology.RDFLayer.Entities.Marketing;
using CRMOntology.RDFLayer.Entities.Sales;
using CRMOntology.RDFLayer.Entities.Party.Customer;

namespace CRMOntology.RDFLayer.Entities.Loyality
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#retention")]
    public interface IRetention
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:retention#")]
        string Id { get; }

        // TODO: Add other property references here

        [PropertyType("ex:requires#")]
        ICollection<IMarketing> Marketings { get; set; }

        [PropertyType("ex:requires#")]
        ICollection<IOpportunity> Opportunities { get; set; }

        [PropertyType("ex:subClassOf#")]
        ICustomer baseClass { get; set; }
    }
}
