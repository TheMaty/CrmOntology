using CRMOntology.RDFLayer.Entities.Accurate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CRMOntology.BusinessLayer
{
    public enum BusinessConstraint 
    { 
        BusinessRequired,
        BusinessRecommend,
        NoConstraint
    }
    public enum CustomerType
    {
        Account = 1,
        Contact = 2,
        Lead = 4
    }
    public class Accurate : OWLItem
    {
        public override string Type
        {
            get
            {
                return "Accurate";
            }
        }

        string Low;
        string Medium;
        string High;
        string BusinessRequired;
        string BusinessRecommend;
        string NoConstraint;

        public override string toXML
        {
            get
            {
                string _strXML = "";
                _strXML += "<OWLItem type= \"" + Type + "\" low=\"" + Low + "\" medium=\"" + Medium + "\" high=\"" + High + "\"";
                _strXML += " businessrequired=\"" + BusinessRequired + "\" businessrecommend=\"" + BusinessRecommend + "\" noconstraint=\"" + NoConstraint + "\">";
                foreach (AccurateMap map in AccurateMaps)
                {
                    _strXML += "<Map key=\"" + map.Key + "\" value=\"" + map.Value + "\"/>";
                }
                _strXML += "</OWLItem>";
                return _strXML;
            }
        }

        public override XElement toElement
        {
            get
            {
                XElement _newElement = new XElement("OWLItem", new XAttribute("type", Type), new XAttribute("low", Low), new XAttribute("medium", Medium), new XAttribute("high", High), new XAttribute("businessrequired", BusinessRequired), new XAttribute("businessrecommend", BusinessRecommend), new XAttribute("noconstraint", NoConstraint));                
                foreach (AccurateMap map in AccurateMaps)
                {
                    _newElement.Add(new XElement("Map", new XAttribute("key", map.Key), new XAttribute("value", map.Value)));
                }
                return _newElement;
            }
        }

        List<AccurateMap> AccurateMaps;

        public Accurate (XElement Item)
        {
            Low = Item.Attribute(XName.Get("low")).Value;
            Medium = Item.Attribute(XName.Get("medium")).Value;
            High = Item.Attribute(XName.Get("high")).Value;
            BusinessRequired = Item.Attribute(XName.Get("businessrequired")).Value;
            BusinessRecommend = Item.Attribute(XName.Get("businessrecommend")).Value;
            NoConstraint = Item.Attribute(XName.Get("noconstraint")).Value;

            AccurateMaps = new List<AccurateMap>();

            foreach (XElement _xelement in Item.Descendants(XName.Get("Map")))
            {
                AccurateMaps.Add(new AccurateMap(_xelement));
            }

        }

        public FullfillLevel getFullfill(string strConnectionString, CustomerType customerType, string id)
        {
            Int32 totalValue = 0;
            //prepare defined tables in Mappings
            var tables = AccurateMaps.GroupBy(a => a.Key.Split('.')[0]);
            foreach(var table in tables)
            {               
                string _selectStatement = " SELECT " + AccurateMaps.Where(a => a.Key.Split('.')[0] == table.Key).Select(s => s.Key).Aggregate((current, next) => current + ", " + next);
                _selectStatement += " FROM " + table.Key;
                _selectStatement += new BusinessLayer.DataDescription(strConnectionString).CreateCustomerWhereStatement(customerType, table.Key, id);

                DataSet ds = new BusinessLayer.DataDescription(strConnectionString).ExecuteStatement(_selectStatement);

                if(ds != null)
                {
                    foreach (DataTable dt in ds.Tables)
                    {
                        foreach (DataRow drow in dt.Rows)
                        {
                            foreach (AccurateMap map in table)
                            {
                                if (map.Key.Split('.').Count() < 2)
                                    continue;

                                if (!drow.IsNull(map.Key.Split('.')[1]))
                                {
                                    switch ((BusinessConstraint)Enum.Parse(typeof(BusinessConstraint), map.Value, true))
                                    {
                                        case BusinessConstraint.BusinessRecommend:
                                            totalValue += int.Parse(BusinessRecommend);
                                            break;
                                        case BusinessConstraint.BusinessRequired:
                                            totalValue += int.Parse(BusinessRequired);
                                            break;
                                        case BusinessConstraint.NoConstraint:
                                            totalValue += int.Parse(NoConstraint);
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }         
            }

            if (int.Parse(Low) >= totalValue)
                return FullfillLevel.low;
            else if (int.Parse(Medium) >= totalValue)
                return FullfillLevel.medium;
            else return FullfillLevel.high;

        }
        
    }
}
