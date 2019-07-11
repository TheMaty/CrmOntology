using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace CRMOntology.RDFLayer.Entities
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#connectionrolecategory")]
    public interface IConnectionRoleCategory
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:connectionrolecategory#")]
        string Id { get; }

        // TODO: Add other property references here
        [PropertyType("ex:isCategorized#")]
        ICollection<IConnectionRole> ConnectionRoles { get; set; }

    }
}
