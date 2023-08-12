using Microsoft.Data.SqlClient;
using System.Data;
using System.Security.Cryptography.Xml;

namespace KitApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string constring = @"Server=Naib\SQLEXPRESS;Database=KITABLARDB;Trusted_Connection=true;Encrypt=false;";

        SqlConnection con = new SqlConnection(constring);

        int IndexRow;
        int cell;
        private void Form1_Load(object sender, EventArgs e)
        {
            con.Open();
            ShowData();
        }
        public  void ShowData()
        {
            string Show = @"SELECT * FROM KITABLAR;";
            SqlCommand sqlcommand = new SqlCommand(Show, con);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlcommand);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void SearchData()
        {
            string Find = @"SELECT * FROM KITABLAR WHERE KITAB_AD=@kitabadi;";
             
            SqlCommand sqlcommand = new SqlCommand(Find, con);
            sqlcommand.Parameters.AddWithValue("@kitabadi", textBox1.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlcommand);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                string cmd = $@"DELETE FROM KITABLAR WHERE KITAB_ID={cell};";
                SqlCommand sqlcommand = new SqlCommand(cmd, con);
                sqlcommand.ExecuteNonQuery();

                string cmd2 = @"INSERT INTO KITABLAR(KITAB_AD,KITAB_YAZAR,KITAB_SEHIFE,KITAB_QIYMET,KITAB_TARIX,KITAB_CAP_EVI)
                                VALUES(@kitabadi,@kitabyazar,@kitabsehife,@kitabqiymet,@kitabtarix,@kitabcapevi);";
                SqlCommand sqlcommand2 = new SqlCommand(cmd2, con);
                sqlcommand2.Parameters.AddWithValue("@kitabadi", textBox2.Text);
                sqlcommand2.Parameters.AddWithValue("@kitabyazar", textBox3.Text);
                sqlcommand2.Parameters.AddWithValue("@kitabsehife", textBox4.Text);
                sqlcommand2.Parameters.AddWithValue("@kitabqiymet", textBox5.Text);
                sqlcommand2.Parameters.AddWithValue("@kitabtarix", textBox6.Text);
                sqlcommand2.Parameters.AddWithValue("@kitabcapevi", textBox7.Text);
                sqlcommand2.ExecuteNonQuery();
                MessageBox.Show("Book succesfull update");

            }
            catch (Exception error)
            {
                MessageBox.Show("Error");
                MessageBox.Show(error.Message);
                MessageBox.Show(error.StackTrace);
            }
            ShowData();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = @"INSERT INTO KITABLAR(KITAB_AD,KITAB_YAZAR,KITAB_SEHIFE,KITAB_QIYMET,KITAB_TARIX,KITAB_CAP_EVI)
                                VALUES(@kitabadi,@kitabyazar,@kitabsehife,@kitabqiymet,@kitabtarix,@kitabcapevi);";
                SqlCommand sqlcommand = new SqlCommand(cmd, con);
                sqlcommand.Parameters.AddWithValue("@kitabadi", textBox2.Text);
                sqlcommand.Parameters.AddWithValue("@kitabyazar", textBox3.Text);
                sqlcommand.Parameters.AddWithValue("@kitabsehife", textBox4.Text);
                sqlcommand.Parameters.AddWithValue("@kitabqiymet", textBox5.Text);
                sqlcommand.Parameters.AddWithValue("@kitabtarix", textBox6.Text);
                sqlcommand.Parameters.AddWithValue("@kitabcapevi", textBox7.Text);
                sqlcommand.ExecuteNonQuery();
                MessageBox.Show("Book succesfull add");

            }
            catch (Exception error)
            {
                MessageBox.Show("Error");
                MessageBox.Show(error.Message);
                MessageBox.Show(error.StackTrace);
            }
            ShowData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IndexRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[IndexRow];
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            textBox4.Text = row.Cells[3].Value.ToString();
            textBox5.Text = row.Cells[4].Value.ToString();
            textBox6.Text = row.Cells[5].Value.ToString();
            textBox7.Text = row.Cells[6].Value.ToString();
            cell = Convert.ToInt32(row.Cells[0].Value);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                string cmd = $@"DELETE FROM KITABLAR WHERE KITAB_ID={cell};";
                SqlCommand sqlcommand = new SqlCommand(cmd, con);
                sqlcommand.ExecuteNonQuery();
                MessageBox.Show("Book succesfull deleted");

            }
            catch (Exception error)
            {
                MessageBox.Show("Error");
                MessageBox.Show(error.Message);
                MessageBox.Show(error.StackTrace);
            }
            ShowData();
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            SearchData();
        }
    }
}