using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace CRMOntology.RDFLayer.Entities
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#attachment")]
    public interface IAttachment
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:attachment#")]
        string Id { get; }

        // TODO: Add other property references here
        [PropertyType("ex:isEnclosed#")]
        ICollection<IAnnotation> Annotations { get; set; }
    }
}
