using System;
using System.Text;
using System.Collections.Specialized;
using System.Data;
using System.Collections.Generic;
using System.Xml.Linq;
using CRMOntology.DataAccessLayer;

namespace CRMOntology.BusinessLayer
{
    class DataTransfer
    {
        public DataTransfer()
        {

        }

        public void StartTransfer(XElement DatabaseElement)
        {

            ResourceDescription ResourceDesc = new ResourceDescription(DatabaseElement);
            DataDescription StagingDesc =  new BusinessLayer.DataDescription(ResourceDesc.StagingDatabase.ConnectionString);
            DataDescription SourceDesc =  new BusinessLayer.DataDescription(ResourceDesc.SourceDatabase.ConnectionString);

            DateTime lastTransferDate = StagingDesc.GetLastTransferDate(ResourceDesc.DatabaseMapName);
            Guid transferHistoryId = StagingDesc.CreateTransferHistory(ResourceDesc.DatabaseMapName);

            foreach (ResourceTable table in ResourceDesc.ResourceTables)
            {
                string statementSource = SourceDesc.CreateSelectStatement(table.ResourceMaps,table.Name, lastTransferDate);
                DataSet dsData = SourceDesc.ExecuteStatement(statementSource);

                if (dsData.Tables.Count > 0)
                {
                    foreach (DataRow drow in dsData.Tables[0].Rows)
                    {
                        List<string> stagingPrimaryKeys = StagingDesc.GetPrimaryKeys(table.Name);
                        //if record exists
                        bool exists = StagingDesc.RecordExists(table.ResourceMaps, drow, stagingPrimaryKeys);

                        if (exists)
                        {
                            //update
                            StagingDesc.ExecuteStatement(StagingDesc.CreateUpdateStatement(table.ResourceMaps, drow, stagingPrimaryKeys));
                        }
                        else
                        {
                            //insert
                            StagingDesc.ExecuteStatement(StagingDesc.CreateInsertStatement(table.ResourceMaps, drow, transferHistoryId.ToString()));
                        }
                    }
                }
            }
        }     

    }
}
