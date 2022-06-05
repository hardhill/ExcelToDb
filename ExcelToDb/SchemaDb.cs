namespace ExcelToDb
{
    internal class SchemaDb
    {
        public string table { get; set; }
        public Field[] fields { get; set; }
    }

    public class Field
    {
        public string name { get; set; }
        public string type { get; set; }
    }
}