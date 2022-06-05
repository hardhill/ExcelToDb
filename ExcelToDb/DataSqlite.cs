using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ExcelToDb
{
    internal class DataSqlite
    {
        private SQLiteConnection con;
        private SQLiteCommand cmd;
        private SQLiteDataAdapter adapter;

        public DataSqlite(string databasename)
        {
            if (!File.Exists(databasename))
            {
                SQLiteConnection.CreateFile(databasename);
                
            }
            con = new SQLiteConnection(string.Format("Data Source={0};Compress=True;", databasename));



        }
        public DataTable GetDataTable(string tablename)
        {
            DataTable DT = new DataTable();
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = string.Format("SELECT * FROM {0}", tablename);
            adapter = new SQLiteDataAdapter(cmd);
            adapter.AcceptChangesDuringFill = false;
            adapter.Fill(DT);
            con.Close();
            DT.TableName = tablename;
            foreach (DataRow row in DT.Rows)
            {
                row.AcceptChanges();
            }
            return DT;
        }
        public void SaveDataTable(DataTable DT)
        {
            try
            {
                con.Close();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = string.Format("DELETE FROM {0}", DT.TableName);
                cmd.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            foreach (DataRow row in DT.Rows)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"INSERT INTO {DT.TableName}(");
                for(var i=0;i< DT.Columns.Count;i++)
                {
                    sb.Append(DT.Columns[i].ColumnName);
                    if(i!= DT.Columns.Count - 1)
                    {
                        sb.Append(", ");
                    }
                }
                sb.Append(") VALUES (");
                for (var i = 0; i < DT.Columns.Count; i++)
                {
                    sb.Append(GetStrinValueByType(row[DT.Columns[i].ColumnName].ToString(), DT.Columns[i].DataType));
                    if (i != DT.Columns.Count - 1)
                    {
                        sb.Append(", ");
                    }
                }
                sb.Append(')');
                cmd.CommandText = sb.ToString();
                cmd.ExecuteNonQuery();
            }
            
        }

        private string GetStrinValueByType(string value,Type typeColumn)
        {
            
            var comma = "'";
            switch (typeColumn.Name)
            {
                case "Int16":
                case "Int32":
                case "Boolean":
                case "Double":
                    comma = "";
                    value = value.Replace(',', '.');
                    break;
                default:
                    comma = "'";
                    break;
            }
            return comma + value + comma;
        }

        internal void InitDb(string schemaFile)
        {
            if (!File.Exists(schemaFile) || con == null)
            {
                return;
            }
            // обработать файл схемы
            string json = File.ReadAllText(schemaFile);
            SchemaDb schema = JsonConvert.DeserializeObject<SchemaDb>(json);
            con.Open();
            cmd = con.CreateCommand();
            // формируем запрос на создание таблицы
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CREATE TABLE IF NOT EXISTS {schema.table} (");
            for(var i=0;i<schema.fields.Length;i++)
            {
                sb.AppendLine($"{schema.fields[i].name} {GetFieldType(schema.fields[i].type)}");
                if(i != schema.fields.Length - 1)
                {
                    sb.Append(", ");
                }
            }
            sb.AppendLine(")");

            cmd.CommandText = sb.ToString();
            cmd.ExecuteNonQuery();
        }

        private string GetFieldType(string type)
        {
            switch (type)
            {
                case "Int32":
                case "Int16":
                case "Boolean":
                    return "INTEGER";
                case "Double":
                    return "REAL";
                default:
                    return "TEXT";
            }
        }
    }
}
