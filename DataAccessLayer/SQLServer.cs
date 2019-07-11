using CRMOntology.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CRMOntology.DataAccessLayer
{
    class SQLServer : IDatabase
    {
        private string _connectionString;
 
        public SQLServer(string ConnectionString)
        {
            this._connectionString = ConnectionString;
        }

        public DataSet GetAllPrimaryKeys()
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            try
            {
                string selectStatement = "  SELECT table_name,column_name " +
                                         "  FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE " +
                                         "  WHERE OBJECTPROPERTY(OBJECT_ID(constraint_name), 'IsPrimaryKey') = 1 ";
                using (SqlDataAdapter adapter = new SqlDataAdapter(selectStatement, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<string> GetPrimaryKeys(string TableName)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            try
            {
                string selectStatement = "  SELECT column_name " +
                                         "  FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE " +
                                         "  WHERE OBJECTPROPERTY(OBJECT_ID(constraint_name), 'IsPrimaryKey') = 1 AND table_name = '" + TableName + "'";
                using (SqlDataAdapter adapter = new SqlDataAdapter(selectStatement, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    List<string> primaryKeys = new List<string>();
                    foreach(DataTable dt in ds.Tables)
                    {
                        foreach (DataRow drow in dt.Rows)
                        {
                            primaryKeys.Add(drow[0].ToString());
                        }
                    }
                    return primaryKeys;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataSet GetCustomerReferencedTables()
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            try
            {
                string selectStatement =    " SELECT tPar.name as ParentObject, max(tPar.object_id) as ParentObjectId " +
                                            " FROM sys.foreign_key_columns as fk " +
                                            " INNER JOIN sys.tables as tRef on fk.referenced_object_id = tRef.object_id " +
                                            " INNER JOIN sys.tables as tPar on fk.parent_object_id = tPar.object_id " +
                                            " INNER JOIN sys.columns as cRef on fk.referenced_object_id = cRef.object_id and fk.referenced_column_id = cRef.column_id " +
                                            " INNER JOIN sys.columns as cPar on fk.parent_object_id = cPar.object_id and fk.parent_column_id = cPar.column_id " +
                                            " WHERE fk.referenced_object_id = (select object_id from sys.tables where name =  'AccountBase') or " +
                                            " fk.referenced_object_id= (select object_id from sys.tables where name =  'ContactBase') " +
                                            " group by tPar.name ";

                using (SqlDataAdapter adapter = new SqlDataAdapter(selectStatement, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<List<string>> GetForeignKeys(string TableName)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            try
            {
                string selectStatement = " SELECT tRef.name as TableWithForeignKey,  cRef.name as ForeignKeyColumn , tPar.name as TableWithParentKey,cPar.name as ParentKeyColumn " +
                                            " FROM sys.foreign_key_columns as fk " +
                                            " INNER JOIN sys.tables as tRef on fk.referenced_object_id = tRef.object_id " +
                                            " INNER JOIN sys.tables as tPar on fk.parent_object_id = tPar.object_id " +
                                            " INNER JOIN sys.columns as cRef on fk.referenced_object_id = cRef.object_id and fk.referenced_column_id = cRef.column_id " +
                                            " INNER JOIN sys.columns as cPar on fk.parent_object_id = cPar.object_id and fk.parent_column_id = cPar.column_id " +
                                            " WHERE fk.parent_object_id = (select object_id from sys.tables where name = '" + TableName + "') ";

                using (SqlDataAdapter adapter = new SqlDataAdapter(selectStatement, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    List<List<string>> returnList = new List<List<string>>();
                    List<string> foreignKeys;
                    foreach (DataTable dt in ds.Tables)
                    {
                        foreach (DataRow drow in dt.Rows)
                        {
                            foreignKeys = new List<string>();
                            foreignKeys.Add(drow["TableWithForeignKey"].ToString());
                            foreignKeys.Add(drow["ForeignKeyColumn"].ToString());
                            foreignKeys.Add(drow["TableWithParentKey"].ToString());
                            foreignKeys.Add(drow["ParentKeyColumn"].ToString());
                            returnList.Add(foreignKeys);
                        }
                    }
                    return returnList;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                conn.Close();
            }
        }

        public string GetInnerJoinStatement(string TableName, string Parent, string Foreign)
        {
            List<List<string>> strKeys = GetForeignKeys(TableName);
            string joinStatement = "";
            foreach (List<string> listStr in strKeys)
            {
                joinStatement += " INNER JOIN " +  listStr.ElementAt(0) + " ON " + listStr.ElementAt(0) + "." + listStr.ElementAt(1) + " = " + listStr.ElementAt(2) + "." + listStr.ElementAt(3) + " ";
            }

            return joinStatement;
        }

        public DataSet GetAllTables()
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            try
            {
                string selectStatement = "  SELECT name,object_id " +
                                         "  FROM SYS.OBJECTS " +
                                         "  WHERE TYPE_DESC='USER_TABLE' " +
                                         "  order by name";

                using (SqlDataAdapter adapter = new SqlDataAdapter(selectStatement, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataSet GetColumnsByTableId(string TableId)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            try
            {
                string selectStatement = "  SELECT c.Name as name,t.name as type,c.max_length as size " +
                                         "  FROM SYS.COLUMNS c" +
                                         " INNER JOIN " +
                                         " SYS.TYPES t " +
                                         "  on t.user_type_id = c.user_type_id " +
                                         "  WHERE c.object_id=" + TableId +
                                         "  order by c.object_id,c.column_id ";

                using (SqlDataAdapter adapter = new SqlDataAdapter(selectStatement, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                conn.Close();
            }
        }

        public DateTime GetLastTransferDate(string TransferMapName)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            try
            {
                string selectStatement = "  SELECT TOP 1 TransferDate " +
                                         "  FROM TransferHistoryBase" +                                         
                                         "  WHERE TransferMapName='" + TransferMapName + "'" +
                                         "  order by TransferDate desc ";

                using (SqlCommand command = new SqlCommand(selectStatement, conn))
                {
                    object obj = command.ExecuteScalar();
                    if (obj == null)
                        return new DateTime(1977,01,01);
                    else
                        return (DateTime)obj;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataSet ExecuteStatement(string SQLStatement)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            try
            {
                if (SQLStatement.Contains("select") || SQLStatement.Contains("SELECT"))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(SQLStatement, conn))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        return ds;
                    }
                }
                else
                {
                    using (SqlCommand command = new SqlCommand(SQLStatement, conn))
                    {
                        command.ExecuteNonQuery();
                        return null;
                    }
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                conn.Close();
            }
        }

        public string GetColumnType(string TableName, string ColumnName)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            try
            {
                string selectStatement = " SELECT DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS IC " +
                                         " WHERE TABLE_NAME = '" + TableName + "' and COLUMN_NAME = '" + ColumnName + "'";

                using (SqlCommand command = new SqlCommand(selectStatement, conn))
                {
                    object obj = command.ExecuteScalar();
                    if (obj == null)
                        return "";
                    else
                        return (string)obj;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                conn.Close();
            }
        }

        public Guid CreateTransferHistory(string MapName)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            try
            {
                Guid transferHistoryId = Guid.NewGuid();
                string insertStatement = "  INSERT INTO [dbo].[TransferHistoryBase] " +
                                         "  ([TransferHistoryId] ,[TransferMapName],[TransferDate]) " +
                                         " VALUES " +
                                         " ('" + transferHistoryId.ToString() + "'" +
                                         " , '" + MapName + "'" +
                                         " , '" + DateTime.Now.ToString("MM/dd/yyyy hh:mm") + "' )";

                using (SqlCommand command = new SqlCommand(insertStatement, conn))
                {
                    command.ExecuteNonQuery();
                    return transferHistoryId;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                conn.Close();
            }
        }

        public string CreateSelectStatement(List<ResourceMap> ResourceMaps, string TableName, DateTime LastTransferDate)
        {
            if (ResourceMaps.Count < 0)
                return string.Empty;

            string selectStatement = " SELECT";
            string innerJoin = "";
            string foreignTable = TableName;
            foreach (ResourceMap map in ResourceMaps)
            {
                if (map.From.Split('.')[0] != TableName) //Inner Join requires
                {
                    if (!innerJoin.Contains(TableName))
                    {
                        innerJoin += GetInnerJoinStatement(TableName, map.To.Split('.')[0], map.From.Split('.')[0]);
                        foreignTable = map.From.Split('.')[0];
                    }
                }

                selectStatement += "," + map.From;               
            }
            selectStatement += " FROM " + TableName + innerJoin + " WHERE ( " + foreignTable + ".ModifiedOn is NULL or " + foreignTable + ".ModifiedOn > '" + LastTransferDate.ToString("yyyy-MM-dd hh:mm:ss") + "' )";

            return selectStatement.Replace(" SELECT,"," SELECT ");
        }

        public string CreateSelectStatement(string TableName, List<KeyValuePair<string,string>> PrimaryKeysValue)
        {
            string selectStatement = " SELECT * FROM " + TableName + " WHERE 1=1 ";
            
            foreach (KeyValuePair<string, string> primarykey in PrimaryKeysValue)
            {
                selectStatement += " AND " + primarykey.Key + " = " + "'" + primarykey.Value + "'";
            }

            return selectStatement;
        }      

        public string CreateInsertStatement(List<ResourceMap> ResourceMaps, DataRow Row, string TransferKey)
        {
            if (ResourceMaps.Count < 0)
                return string.Empty;

            string insertStatement = " INSERT INTO " + ResourceMaps[0].To.Split('.')[0] + "(" ;

            foreach (ResourceMap map in ResourceMaps)
            {
                insertStatement += map.To.Split('.')[1] + ",";
            }

            insertStatement += " TransferHistoryId ) " + " VALUES " + " ( ";
            for(int i=0;i<Row.Table.Columns.Count;i++)
            {                
                switch (this.GetColumnType(ResourceMaps[0].To.Split('.')[0].ToString(),Row.Table.Columns[ResourceMaps[i].To.Split('.')[1]].ToString()))
                {
                    case "money":
                    case "decimal":
                    case "int": 
                        insertStatement +=  (Row[i] is System.DBNull?"NULL":Row[i].ToString()).Replace(",",".") + ','; 
                        break;
                    case "datetime":
                        insertStatement += (Row[i] is System.DBNull ? "NULL" : ("'" + DateTime.Parse(Row[i].ToString()).ToString("MM/dd/yyyy hh:mm")) + "'") + ',';
                        break;
                    default:
                        insertStatement += (Row[i] is System.DBNull?"NULL":("'" + Row[i].ToString().Replace("'","''") + "'")) + ',';
                        break;
                }
            }
            insertStatement += "'" + TransferKey + "' ) ";         
            

            return insertStatement;
        }

        public string CreateUpdateStatement(List<ResourceMap> ResourceMaps, DataRow Row, List<string> PrimaryKeys)
        {
            if (ResourceMaps.Count < 0)
                return string.Empty;

            string updateStatement = " UPDATE " + ResourceMaps[0].To.Split('.')[0] + " SET ";
            string wherePart = " WHERE ";

            for (int i = 0; i < Row.Table.Columns.Count; i++)
            { 
                string strTemp = "";
                
                switch (this.GetColumnType(ResourceMaps[0].To.Split('.')[0].ToString(),Row.Table.Columns[ResourceMaps[i].To.Split('.')[1]].ToString()))
                {
                    case "money":
                    case "decimal":
                    case "int": 
                        strTemp =  Row.Table.Columns[ResourceMaps[i].To.Split('.')[1]] + " = " + ( Row[ResourceMaps[i].To.Split('.')[1]] is System.DBNull?"NULL":Row[ResourceMaps[i].To.Split('.')[1]].ToString()).Replace(",",".") ; 
                        break;
                    case "datetime":
                        strTemp = Row.Table.Columns[ResourceMaps[i].To.Split('.')[1]] + " = " + (Row[ResourceMaps[i].To.Split('.')[1]] is System.DBNull ? "NULL" : ("'" + DateTime.Parse(Row[ResourceMaps[i].To.Split('.')[1]].ToString()).ToString("MM/dd/yyyy hh:mm")) + "'");
                        break;
                    default:
                        strTemp = Row.Table.Columns[ResourceMaps[i].To.Split('.')[1]] + " = " + (Row[ResourceMaps[i].To.Split('.')[1]] is System.DBNull ? "NULL" : ("'" + Row[ResourceMaps[i].To.Split('.')[1]].ToString().Replace("'", "''") + "'"));
                        break;
                }

                if (PrimaryKeys.Count( x=> x == ResourceMaps[i].To.Split('.')[1]) > 0 )
                    wherePart +=   strTemp + " AND " ;
                else
                    updateStatement += strTemp + " , " ;
            }

            return updateStatement.Remove(updateStatement.LastIndexOf(',') - 1) + " " + wherePart.Remove(wherePart.LastIndexOf("AND") - 1);
        }

        public bool RecordExists(List<ResourceMap> ResourceMaps, DataRow Row, List<string> PrimaryKeys)
        {
             if (ResourceMaps.Count < 0)
                return false;

             string selectStatement = " SELECT count(*) FROM " + ResourceMaps[0].To.Split('.')[0] + " WHERE ";

            foreach(string str in PrimaryKeys)
            {
                switch (this.GetColumnType(ResourceMaps[0].To.Split('.')[0], str))
                {
                    case "money":
                    case "decimal":
                    case "int":
                        selectStatement += Row.Table.Columns[str] + " = " + (Row[str] is System.DBNull ? "NULL" : Row[str].ToString()).Replace(",", ".");
                        break;
                    case "datetime":
                        selectStatement += Row.Table.Columns[str] + " = " + (Row[str] is System.DBNull ? "NULL" : ("'" + DateTime.Parse(Row[str].ToString()).ToString("MM/dd/yyyy hh:mm")) + "'");
                        break;
                    default:
                        selectStatement += Row.Table.Columns[str] + " = " + (Row[str] is System.DBNull ? "NULL" : ("'" + Row[str].ToString() + "'"));
                        break;
                }
                selectStatement += " AND ";
            }

            DataSet ds = this.ExecuteStatement(selectStatement.Remove(selectStatement.LastIndexOf(" AND ")));

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && int.Parse(ds.Tables[0].Rows[0][0].ToString()) > 0)
                return true;
            else
                return false;
        }

        public string CreateCustomerWhereStatement(CustomerType customerType, string targetTable, string Id)
        {
            string selectStatement =    " SELECT cPar.name as columnParentName " +
                                        " FROM sys.foreign_key_columns as fk " +
                                        " INNER JOIN sys.tables as tRef on fk.referenced_object_id = tRef.object_id " +
                                        " INNER JOIN sys.tables as tPar on fk.parent_object_id = tPar.object_id " +
                                        " INNER JOIN sys.columns as cRef on fk.referenced_object_id = cRef.object_id and fk.referenced_column_id = cRef.column_id " +
                                        " INNER JOIN sys.columns as cPar on fk.parent_object_id = cPar.object_id and fk.parent_column_id = cPar.column_id " ;
            switch (customerType)
            {
                case CustomerType.Account :
                        selectStatement += " WHERE fk.referenced_object_id = (select object_id from sys.tables where name =  'AccountBase')";
                    break;
                case CustomerType.Contact :
                        selectStatement += " WHERE fk.referenced_object_id = (select object_id from sys.tables where name =  'ContactBase')";
                    break;
            }

            selectStatement += " and tPar.name = '" + targetTable + "'";

            selectStatement += " UNION ALL ";
            selectStatement += " SELECT CASE WHEN 'AccountBase' LIKE '%" + targetTable + "%' THEN 'AccountId'  WHEN 'AccountBase' LIKE '%" + targetTable + "%' THEN 'ContactId' END as columnParentName";

            selectStatement += " UNION ALL ";
            selectStatement += " SELECT CASE WHEN 'ContactBase' LIKE '%" + targetTable + "%' THEN 'ParentCustomerId' END as columnParentName";

            selectStatement += " UNION ALL ";
            selectStatement += " SELECT CASE WHEN 'IncidentBase' LIKE '%" + targetTable + "%' THEN 'CustomerId' END as columnParentName";  

            DataSet ds = ExecuteStatement(selectStatement);

            string whereStatement = " WHERE 1=0 ";
            if (ds != null)
            {
                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow drow in dt.Rows)
                    {
                        if (!drow.IsNull("columnParentName"))
                            whereStatement +=  " OR " + targetTable + "." + drow["columnParentName"].ToString() + " = " + "'" + Id + "'";
                    }
                }
            }

            return whereStatement;
        }
    }
}
