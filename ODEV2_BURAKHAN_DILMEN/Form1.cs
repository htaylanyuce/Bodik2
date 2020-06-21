using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
 

namespace ODEV2_BURAKHAN_DILMEN
{
     
    public partial class Form1 : Form
    {
        int seviye = 0;
        int mayinSayisi = 0;
        int width = 40;
        int height = 40;
        int totalPuan = 0;
        List<Button> butonlarListesi = new List<Button>();

   
        public Form1()
        {
            InitializeComponent();
            label4.Text = 0 + "";
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
    
            radioButton1.Checked = true;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            tabPage1.Text = "UYGULAMA1";
            tabPage2.Text = "UYGULAMA2";

            string connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\C#\\ODEV2_BURAKHAN_DILMEN\\Veritabanı.mdb;";
            string sql = "SELECT * FROM Stok";
            OleDbConnection connection = new OleDbConnection(connetionString);
            OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, "Stock_table");
            connection.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Stock_table";


        }        

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel2_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();


        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Min = 0;
            int Max = 100;
            totalPuan = 0;
            label4.Text = "0";
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;

            flowLayoutPanel1.Controls.Clear();      
            if (radioButton1.Checked == true)
            {
                seviye = 0;
                mayinSayisi = 10;
                 
            }
            else if (radioButton2.Checked == true)
            {
                seviye = 1;
                mayinSayisi = 25;
                
            }
            else if (radioButton3.Checked == true)
            {
                seviye = 2;
                mayinSayisi = 40;
                
            }
                       
            int[] mayinlar = new int[mayinSayisi];

            Random randNum = new Random();
            for (int i = 0; i < mayinSayisi; i++)
            {                 
                mayinlar[i] = randNum.Next(Min, Max);
            }

            for (int i = 0; i < 100; i++)
            {
                Button button = new Button();
                button.Size = new Size(width, height);
                button.BackColor = Color.Blue;
                button.Click += new EventHandler(button_Click);        
               
                for(int k=0; k< mayinlar.Length; k++)
                {
                    if(i == mayinlar[k])
                    {
                        button.Tag = "1";
                        //button.Text = "mayin";
                        button.Name = "mayin";
                        
                    }
                    else
                    {
                        button.Tag = "0";
                    }
                    
                }
                flowLayoutPanel1.Controls.Add(button);

                butonlarListesi.Add(button);
            }
            
        }
        void button_Click(object sender, EventArgs e)
        {
                
            Button button = sender as Button;
           

            try {
                if (button.Name.Equals("mayin"))
                {
                    end();                     
                }
                else
                {
                    Random randNum = new Random();
                     

                    int puan = randNum.Next(1, mayinSayisi);
                    label4.Text = totalPuan + "";
                    button.BackColor = Color.Green;
                    button.Text = puan + "";
                    totalPuan += puan;
                    button.Enabled = false;
                    label4.Text = totalPuan + "";
                }
            }
            catch (NullReferenceException ex)
            {
                
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "";
            label2.Text = 10 +"";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "";
            label2.Text = 25 + "";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "";
            label2.Text = 40 + "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void end()
        {
            foreach (Button bt in butonlarListesi)
            {
                if (bt.Name.Equals("mayin"))
                { 
                    bt.Image = System.Drawing.Image.FromFile("D:\\C#\\ODEV2_BURAKHAN_DILMEN\\mayin.jfif");
                    
                }
                else
                {
                    bt.BackColor = Color.Green;
                }
                bt.Enabled = false;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
            }
            butonlarListesi.Clear();
            MessageBox.Show("Yandiniz\nToplam Puan: " + totalPuan);


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            int columnindex = dataGridView1.CurrentCell.ColumnIndex;
            
            string girisFiyati = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
            int fiyat = Int32.Parse(girisFiyati);
            string karOrani = dataGridView1.Rows[rowindex].Cells[2].Value.ToString();
            int karO = Int32.Parse(karOrani);
                 
            label5.Text = "SEÇİLEN ÜRÜNÜN SATIŞ FİYATI: " + (fiyat * (1+ (karO * 1.0 /100)) * 1.18) ;
            

           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try {
                int rowindex = dataGridView1.CurrentCell.RowIndex;

                dataGridView1.Rows.RemoveAt(rowindex);
            }
            catch
            {
                MessageBox.Show("Database boş");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form2 frm2 = new Form2(0,0 );
            frm2.Show();
           
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            int columnindex = dataGridView1.CurrentCell.ColumnIndex;
            Form2 frm2 = new Form2(1,rowindex );
            frm2.Show();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
