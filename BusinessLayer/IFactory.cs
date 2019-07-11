using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CRMOntology.BusinessLayer
{
    public interface IFactory
    {
        string Type { get; }
        string toXML { get; }
        XElement toElement { get; }
    }
}
