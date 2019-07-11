using CRMOntology.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CRMOntology.DataAccessLayer
{
    public enum DatabaseType 
    {
        SqlServer,
        Oracle
    }

    public interface IDatabase
    {
        DataSet GetAllTables();
        DataSet GetColumnsByTableId(string TableId);
        DataSet GetAllPrimaryKeys();
        DataSet GetCustomerReferencedTables();
        List<string> GetPrimaryKeys(string TableName);
        DateTime GetLastTransferDate(string TransferMapName);
        DataSet ExecuteStatement(string SQLStatement);
        string GetColumnType(string TableName,string ColumnName);
        Guid CreateTransferHistory(string MapName);
        string CreateSelectStatement(List<ResourceMap> ResourceMaps,string TableName, DateTime LastTransferDate);
        string CreateSelectStatement(string TableName, List<KeyValuePair<string, string>> PrimaryKeysValue);
        string CreateInsertStatement(List<ResourceMap> ResourceMaps, DataRow Row, string TransferKey);
        string CreateUpdateStatement(List<ResourceMap> ResourceMaps, DataRow Row, List<string> PrimaryKeys);
        bool RecordExists(List<ResourceMap> ResourceMaps, DataRow Row, List<string> PrimaryKeys);
        string CreateCustomerWhereStatement(CustomerType customerType, string targetTable, string Id);
    }

    public class DataAccess
    {
        public static IDatabase DatabaseHandler(CRMOntology.DataAccessLayer.DatabaseType type, string ConnectionString)
        {
            switch (type)
            {
                case CRMOntology.DataAccessLayer.DatabaseType.SqlServer:
                    SQLServer _sqlServer = new SQLServer(ConnectionString);
                    return _sqlServer;
                default: return null;
            }

        }
    }
}
