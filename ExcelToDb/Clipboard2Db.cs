using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;


namespace ExcelToDb
{
    internal class Clipboard2Db
    {
        private List<string> listData { get; set; } = new List<string>();
        private DataSet ds;
        public Clipboard2Db()
        {

        }
        public void SetDataText(string dataText,string schemaFile)
        {
            if (dataText.Equals("") || !File.Exists(schemaFile))
            {
                return;
            }
            listData.Clear();
            listData.AddRange(dataText.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));
            // обработать файл схемы
            string json = File.ReadAllText(schemaFile);
            SchemaDb schema = JsonConvert.DeserializeObject<SchemaDb>(json);
            // создание Table
            DataTable dt = new DataTable(schema.table);
            foreach (var field in schema.fields)
            {
                DataColumn col = new DataColumn();
                col.ColumnName = field.name;
                col.DataType = Type.GetType("System."+field.type);
                dt.Columns.Add(col);
            }
            // заполнение таблицы
            foreach(var line in listData)
            {
                string[] dataStringRow = line.Split('\t');
                DataRow newRow = dt.NewRow();
                var counter = 0;
                foreach (DataColumn col in dt.Columns)
                {
                    try
                    {
                        newRow[counter] = ValueByType(dataStringRow[counter], col.DataType);
                    }catch(Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    counter++;
                }
                dt.Rows.Add(newRow);
            }
            

            ds = new DataSet(schema.table);
            ds.Tables.Add(dt);
            ds.AcceptChanges();
            

        }
        public DataSet GetDataSet()
        {
            return ds;
        }
        private object ValueByType(string v, Type dataType)
        {
            object result = DBNull.Value;
            switch (dataType.Name)
            {
                case "Int32":
                    result = Convert.ToInt32(v);
                    break;
                case "Int16":
                    result= Convert.ToInt16(v);
                    break;
                case "String":
                    result = Convert.ToString(v);
                    break ;
                case "Boolean":
                    result = Convert.ToBoolean(v);
                    break;
                case "Double":
                    result = ConvertToDouble(v);
                    break;
                case "DateTime":
                    result = Convert.ToDateTime(v);
                    break;
                default:

                    break;
            }
            return result;
        }

        private double ConvertToDouble(string Value)
        {
            if (Value == null)
            {
                return 0;
            }
            else
            {
                Value = Value.Replace('.', ',');
                double OutVal;
                double.TryParse(Value, out OutVal);

                if (double.IsNaN(OutVal) || double.IsInfinity(OutVal))
                {
                    return 0;
                }
                return OutVal;
            }
        }
    }
}