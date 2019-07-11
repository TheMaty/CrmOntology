using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;
using CRMOntology.RDFLayer.Entities.Sales.Product;
using CRMOntology.RDFLayer.Entities.Demographics.Address.Postal;
using CRMOntology.RDFLayer.Entities.Demographics;

namespace CRMOntology.RDFLayer.Entities.Characteristics
{
    [Entity("http://www.comu.edu.tr/eatamuh/ontologies/2014/9/crm-ontology#lifestyle")]
    public interface ILifeStyle
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
        [Identifier("ex:lifestyle#")]
        string Id { get; }

        // TODO: Add other property references here

        [PropertyType("ex:choice#")]
        ICollection<IProduct> ChoiceProducts { get; set; }

        [PropertyType("ex:purchase#")]
        ICollection<IProduct> PurchaseProducts { get; set; }

        [PropertyType("ex:use#")]
        ICollection<IProduct> UseProducts { get; set; }

        [PropertyType("ex:ispartof#")]
        ICollection<IDemographics> Demographics { get; set; }

        [PropertyType("ex:live#")]
        IPostal PostalAddress { get; set; }

//        [Disjoint("ex:subClassOf#", "IAccount")]
        [PropertyType("ex:subClassOf#")]
        ICharacteristics baseClass { get; set; }
    }
}
