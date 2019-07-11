using CRMOntology.DataAccessLayer;
using CRMOntology.RDFLayer;
using CRMOntology.RDFLayer.Entities;
using CRMOntology.RDFLayer.Entities.Party;
using CRMOntology.RDFLayer.Entities.Party.Customer.Account;
using CRMOntology.RDFLayer.Entities.Party.Customer.Contact;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CRMOntology.BusinessLayer
{
    public class Utilities
    {
        public static OWLMapBase Convert(Guid OWLId, Guid DBId, string TableName, Guid TransferHistoryId)
        {
            OWLMapBase mp = new OWLMapBase();
            mp.CreatedOn = DateTime.Now;
            mp.FromTableName = TableName;
            mp.FromTablePKId = DBId;
            mp.OWLMapId = Guid.NewGuid();
            mp.ToOWLId = OWLId;
            mp.TransferHistoryId = TransferHistoryId;
            return mp;
        }
    }
}
