﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace CRMOntology.RDFLayer.Entities.Party.Customer.Account.Type
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#governments")]
    public interface IGovernments
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:governments#")]
        string Id { get; }

        // TODO: Add other property references here

        [PropertyType("ex:subClassOf#")]
        IType baseClass { get; set; }
    }
}