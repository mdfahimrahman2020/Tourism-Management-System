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

namespace WinFormsApp13
{
    public partial class Form3 : Form
    {
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);

        public Form3()
        {
            InitializeComponent();
        }

        void BindData()
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-LG6P4QHF;Initial Catalog=Project;Persist Security Info=True;User ID=sa;Password=pokemoncom@123");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Package", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-LG6P4QHF;Initial Catalog=Project;Persist Security Info=True;User ID=sa;Password=pokemoncom@123");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Package(ID, Pack_Name, Leaving_From, Destination, Schedule, Amount) VALUES(@ID, @Pack_Name, @Leaving_From, @Destination, @Schedule, @Amount)", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@Pack_Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Amount", textBox2.Text);
            cmd.Parameters.AddWithValue("@Leaving_From", choose.Text);
            cmd.Parameters.AddWithValue("@Destination", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Schedule", DateTime.Parse(dateTimePicker1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            BindData();
            MessageBox.Show("Successfully Inserted");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-LG6P4QHF;Initial Catalog=Project;Persist Security Info=True;User ID=sa;Password=pokemoncom@123");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update Package SET Pack_Name=@Pack_Name, Leaving_From=@Leaving_From, Destination=@Destination, Schedule=@Schedule, Amount=@Amount WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@Pack_Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Amount", textBox2.Text);
            cmd.Parameters.AddWithValue("@Leaving_From", choose.Text);
            cmd.Parameters.AddWithValue("@Destination", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Schedule", DateTime.Parse(dateTimePicker1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            BindData();
            MessageBox.Show("Successfully Updated");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BindData();
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-LG6P4QHF;Initial Catalog=Project;Persist Security Info=True;User ID=sa;Password=pokemoncom@123");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Package WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox3.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-LG6P4QHF;Initial Catalog=Project;Persist Security Info=True;User ID=sa;Password=pokemoncom@123");
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE Package WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            BindData();
            MessageBox.Show("Successfully Deleted");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                e.Cancel = true;
                textBox3.Focus();
                errorProvider1.SetError(textBox3, "ID should Unique and not be left blank!!!!!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox3, "");
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "Enter your Pack_Name !");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox1, ""); 
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                e.Cancel = true;
                textBox2.Focus();
                errorProvider1.SetError(textBox2, "Enter your Pack_Name !");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox2, "");
            }

        }

        private void Form3_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void Form3_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
