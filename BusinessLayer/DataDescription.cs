using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CRMOntology.BusinessLayer
{
    public class DataDescription
    {
        string _connectionString;

        public DataDescription(string ConnectionString)
        {
            this._connectionString = ConnectionString;
        }

        public DataSet GetTables()
        {
            try
            {
                return DataAccessLayer.DataAccess.DatabaseHandler(DataAccessLayer.DatabaseType.SqlServer, this._connectionString).GetAllTables();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public DataSet GetCustomerReferencedTables()
        {
            try
            {
                return DataAccessLayer.DataAccess.DatabaseHandler(DataAccessLayer.DatabaseType.SqlServer, this._connectionString).GetCustomerReferencedTables();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public string CreateCustomerWhereStatement(CustomerType customerType, string targetTable, string Id)
        {
            try
            {
                return DataAccessLayer.DataAccess.DatabaseHandler(DataAccessLayer.DatabaseType.SqlServer, this._connectionString).CreateCustomerWhereStatement(customerType, targetTable, Id);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public DataSet GetAllPrimaryKeys()
        {
            try
            {
                return DataAccessLayer.DataAccess.DatabaseHandler(DataAccessLayer.DatabaseType.SqlServer, this._connectionString).GetAllPrimaryKeys();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public List<string> GetPrimaryKeys(string TableName)
        {
            try
            {
                return DataAccessLayer.DataAccess.DatabaseHandler(DataAccessLayer.DatabaseType.SqlServer, this._connectionString).GetPrimaryKeys(TableName);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public DataSet GetColumnsByTableId(string TableId)
        {
            try
            {
                return DataAccessLayer.DataAccess.DatabaseHandler(DataAccessLayer.DatabaseType.SqlServer, this._connectionString).GetColumnsByTableId(TableId);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public DateTime GetLastTransferDate(string TransferMapName)
        {
            try
            {
                return DataAccessLayer.DataAccess.DatabaseHandler(DataAccessLayer.DatabaseType.SqlServer, this._connectionString).GetLastTransferDate(TransferMapName);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public DataSet ExecuteStatement(string SQLStatement)
        {
            try
            {
                return DataAccessLayer.DataAccess.DatabaseHandler(DataAccessLayer.DatabaseType.SqlServer, this._connectionString).ExecuteStatement(SQLStatement);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public string GetColumnType(string TableName, string ColumnName)
        {
            try
            {
                return DataAccessLayer.DataAccess.DatabaseHandler(DataAccessLayer.DatabaseType.SqlServer, this._connectionString).GetColumnType(TableName,ColumnName);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public Guid CreateTransferHistory(string MapName)
        {
            try
            {
                return DataAccessLayer.DataAccess.DatabaseHandler(DataAccessLayer.DatabaseType.SqlServer, this._connectionString).CreateTransferHistory(MapName);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public string CreateSelectStatement(string TableName, List<KeyValuePair<string,string>> PrimaryKeysValue)
        {
            try
            {
                return DataAccessLayer.DataAccess.DatabaseHandler(DataAccessLayer.DatabaseType.SqlServer, this._connectionString).CreateSelectStatement(TableName, PrimaryKeysValue);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public string CreateSelectStatement(List<ResourceMap> ResourceMaps,string TableName, DateTime LastTransferDate)
        {
            try
            {
                return DataAccessLayer.DataAccess.DatabaseHandler(DataAccessLayer.DatabaseType.SqlServer, this._connectionString).CreateSelectStatement(ResourceMaps,TableName,LastTransferDate);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        
        public string CreateInsertStatement(List<ResourceMap> ResourceMaps, DataRow Row, string TransferKey)
        {
            try
            {
                return DataAccessLayer.DataAccess.DatabaseHandler(DataAccessLayer.DatabaseType.SqlServer, this._connectionString).CreateInsertStatement(ResourceMaps,Row,TransferKey);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public string CreateUpdateStatement(List<ResourceMap> ResourceMaps, DataRow Row, List<string> PrimaryKeys)
        {
            try
            {
                return DataAccessLayer.DataAccess.DatabaseHandler(DataAccessLayer.DatabaseType.SqlServer, this._connectionString).CreateUpdateStatement(ResourceMaps, Row, PrimaryKeys);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public bool RecordExists(List<ResourceMap> ResourceMaps, DataRow Row, List<string> PrimaryKeys)
        {
            try
            {
                return DataAccessLayer.DataAccess.DatabaseHandler(DataAccessLayer.DatabaseType.SqlServer, this._connectionString).RecordExists(ResourceMaps,Row,PrimaryKeys);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
