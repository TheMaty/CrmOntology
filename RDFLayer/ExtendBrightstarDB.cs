using CRMOntology.RDFLayer.Entities.Party.Customer.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMOntology.RDFLayer
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class DisjointAttribute : BrightstarDB.EntityFramework.RelativeOrAbsoluteIdentifierAttribute
    {
        public string relativeOrAbsoluteUri;
        public string interfaceName;

        public DisjointAttribute(string RelativeOrAbsoluteUri, string InterfaceName)
            : base(RelativeOrAbsoluteUri)
        {
            relativeOrAbsoluteUri = RelativeOrAbsoluteUri;
            interfaceName = InterfaceName;
        }
    }
}

#region commented out 
//namespace CRMOntology.RDFLayer.Entities.Characteristics
//{
//    public partial class LifeStyle  
//    {
//        [CRMOntology.RDFLayer.DisjointAttribute("ex:subClassOf#", "IAccount")]
//        public CRMOntology.RDFLayer.Entities.Characteristics.ICharacteristics baseClass
//        {
//            get { return GetRelatedObject<CRMOntology.RDFLayer.Entities.Characteristics.ICharacteristics>("baseClass"); }
//            set {
//                if (value != null)
//                {
//                    DisjointAttribute disjointAttribute = (DisjointAttribute)Attribute.GetCustomAttribute(value.GetType(), typeof(DisjointAttribute));

//                    if (disjointAttribute != null)
//                    {
//                        if (value.baseClass.GetType().Name == disjointAttribute.interfaceName)
//                            throw new Exception("it is not allowed to set Account since property of the attribute is marked as Disjoint");
//                    }
//                    SetRelatedObject<CRMOntology.RDFLayer.Entities.Characteristics.ICharacteristics>(disjointAttribute.relativeOrAbsoluteUri.Replace("ex:","").Replace("#",""), value); 
//                }             
//            }
//        }
//    }    
//}

//namespace CRMOntology.RDFLayer.Entities.Characteristics.Motivation.Behavioral
//{
//    public partial class Behavioral 
//    {
//        [CRMOntology.RDFLayer.DisjointAttribute("ex:physicological#", "IAccount")]
//        public CRMOntology.RDFLayer.Entities.Characteristics.Motivation.Behavioral.physicological Physicological
//        {
//            get { return GetRelatedProperty<CRMOntology.RDFLayer.Entities.Characteristics.Motivation.Behavioral.physicological>("Physicological"); }
//            set
//            {
//                DisjointAttribute disjointAttribute = (DisjointAttribute)Attribute.GetCustomAttribute(value.GetType(), typeof(DisjointAttribute));

//                if (disjointAttribute != null)
//                {
//                    if ( baseClass.baseClass.baseClass.GetType().Name == disjointAttribute.interfaceName)
//                        throw new Exception("it is not allowed to set Account since property of the attribute is marked as Disjoint");
//                }
//                SetRelatedProperty(disjointAttribute.relativeOrAbsoluteUri.Replace("ex:", "").Replace("#", ""), value);
//            }
//        }
//    }
//}

//namespace CRMOntology.RDFLayer.Entities.Characteristics.Perception.Self
//{
//    public partial class Self
//    {
//        [CRMOntology.RDFLayer.DisjointAttribute("ex:subClassOf#", "IAccount")]
//        public CRMOntology.RDFLayer.Entities.Characteristics.Perception.IPerception baseClass
//        {
//            get { return GetRelatedObject<CRMOntology.RDFLayer.Entities.Characteristics.Perception.IPerception>("baseClass"); }
//            set
//            {
//                if (value != null)
//                {
//                    DisjointAttribute disjointAttribute = (DisjointAttribute)Attribute.GetCustomAttribute(value.GetType(), typeof(DisjointAttribute));

//                    if (disjointAttribute != null)
//                    {
//                        if (value.baseClass.baseClass.GetType().Name == disjointAttribute.interfaceName)
//                            throw new Exception("it is not allowed to set Account since property of the attribute is marked as Disjoint");
//                    }
//                    SetRelatedObject<CRMOntology.RDFLayer.Entities.Characteristics.Perception.IPerception>(disjointAttribute.relativeOrAbsoluteUri.Replace("ex:", "").Replace("#", ""), value);
//                }
//            }
//        }
//    }
//}

//namespace CRMOntology.RDFLayer.Entities.Demographics.MartialStatus
//{
//    public partial class MaritialStatus
//    {
//        [CRMOntology.RDFLayer.DisjointAttribute("ex:subClassOf#", "IAccount")]
//        public CRMOntology.RDFLayer.Entities.Demographics.IDemographics baseClass
//        {
//            get { return GetRelatedObject<CRMOntology.RDFLayer.Entities.Demographics.IDemographics>("baseClass"); }
//            set
//            {
//                if (value != null)
//                {
//                    DisjointAttribute disjointAttribute = (DisjointAttribute)Attribute.GetCustomAttribute(value.GetType(), typeof(DisjointAttribute));

//                    if (disjointAttribute != null)
//                    {
//                        if (value.baseClass.GetType().Name == disjointAttribute.interfaceName)
//                            throw new Exception("it is not allowed to set Account since property of the attribute is marked as Disjoint");
//                    }
//                    SetRelatedObject<CRMOntology.RDFLayer.Entities.Demographics.IDemographics>(disjointAttribute.relativeOrAbsoluteUri.Replace("ex:", "").Replace("#", ""), value);
//                }
//            }
//        }
//    }
//}
#endregion