using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace CRMOntology.RDFLayer.Entities.Preference
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#sendmail")]
    public interface ISendMail
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:sendmail#")]
        string Id { get; }

        // TODO: Add other property references here
        [PropertyType("ex:sendmail#")]
        bool canSendMail { get; set; }

        [PropertyType("ex:subClassOf#")]
        IPreference baseClass { get; set; }
    }
}
