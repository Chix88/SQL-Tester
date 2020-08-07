using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_Tester
{
    public partial class frmTester : Form
    {
        OleDbConnection conn = new OleDbConnection();
        private OleDbCommand command = new OleDbCommand();
        private OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
        private DataTable dt;

        public frmTester()
        {
            InitializeComponent();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\DB\Books.accdb;Persist Security Info=False;
            ";
        }

        private void FrmTester_Load(object sender, EventArgs e)
        {
            


        }

        private void BtnExcute_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Clear();
            conn.Open();
            dataAdapter.SelectCommand = new OleDbCommand(txtCommand.Text,conn);

            dataAdapter.Fill(dt);
            grdRecord.DataSource = dt;
            
            dataAdapter.Dispose();
            conn.Close();

        }
    }
}
