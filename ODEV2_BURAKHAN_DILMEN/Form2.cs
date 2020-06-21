using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ODEV2_BURAKHAN_DILMEN
{
    public partial class Form2 : Form
    {
        DataGridView dataGridView1 = new DataGridView();
        int guncel = 0;
        public Form2( int guncel,int rowindex )
        {
            InitializeComponent();
           
            this.guncel = guncel;

            string connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\C#\\ODEV2_BURAKHAN_DILMEN\\Veritabanı.mdb;";
            string sql = "SELECT * FROM Stok";
            OleDbConnection connection = new OleDbConnection(connetionString);
            OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, "Stock_table");
            connection.Close();
            this.dataGridView1.DataSource = ds;
            this.dataGridView1.DataMember = "Stock_table";

            if (this.guncel == 1)
            {
                try {
                    textBox1.Text = this.dataGridView1.SelectedRows[rowindex].Cells[0].Value.ToString();
                    textBox2.Text = this.dataGridView1.SelectedRows[rowindex].Cells[1].Value.ToString();
                    textBox3.Text = this.dataGridView1.SelectedRows[rowindex].Cells[2].Value.ToString();
                    textBox4.Text = this.dataGridView1.SelectedRows[rowindex].Cells[3].Value.ToString();
                }
                catch
                {
                    MessageBox.Show(" ");
                }
            }
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try {
                this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[0].Cells[0].Value = textBox1.Text;
                this.dataGridView1.Rows[0].Cells[1].Value = textBox2.Text;
                this.dataGridView1.Rows[0].Cells[2].Value = textBox3.Text;
                this.dataGridView1.Rows[0].Cells[3].Value = textBox4.Text;
            }
            catch
            {
                MessageBox.Show(" ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
