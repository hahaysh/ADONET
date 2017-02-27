using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADONET
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1. DataSource에 맞는 Provider구성
            SqlConnection conn = new SqlConnection("Data Source=localhost;User Id = zerg; Password =P@ssw0rd; Initial Catalog = hahaysh");

            //2. DataAdapater를 이용하여 Database와 DB연결개체와 연결
            SqlDataAdapter da = new SqlDataAdapter();

            //3. Datasource호출을 위한 쿼리 구성
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT top 100 * FROM [Front].[LogCodes]";

            //4. DataAdapter를 통한 Connected Ojbect연결
            da.SelectCommand = cmd;

            //5. 결과를 담아둘 Disconnected Ojbect구성
            DataSet ds = new DataSet();

            conn.Open(); //DB연결
            da.Fill(ds); //DataSet에 결과 담기
            conn.Close(); //DB닫기

            //결과물 처리
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}




