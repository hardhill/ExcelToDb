using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ExcelToDb
{
    public partial class Form1 : Form
    {
        private Clipboard2Db clipBoardDb;
        public Form1()
        {
            InitializeComponent();
            clipBoardDb = new Clipboard2Db();
        }

        private void bInsert_Click(object sender, EventArgs e)
        {
            txtBuffer.Text = "";

            if (!Clipboard.ContainsData(DataFormats.UnicodeText))
            {
                return;
            }
            var utext = Clipboard.GetData(DataFormats.UnicodeText).ToString();
            txtBuffer.AppendText(utext);
            clipBoardDb.SetDataText(utext,"schema.json");
            dataGridView1.DataSource = clipBoardDb.GetDataSet();
            dataGridView1.DataMember = clipBoardDb.GetDataSet().Tables[0].TableName;
                        
        }

        private void bSaveDb_Click(object sender, EventArgs e)
        {
            var sliteDb = new DataSqlite("example.sqlite");
            sliteDb.InitDb("schema.json");
            sliteDb.SaveDataTable((dataGridView1.DataSource as DataSet).Tables[0]);
        }
    }
}
