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
    public partial class Form5 : Form
    {
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);

        Form7 ob13;
        public Form5()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void BindData()
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-LG6P4QHF;Initial Catalog=Project;Persist Security Info=True;User ID=sa;Password=pokemoncom@123");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Staff", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-LG6P4QHF;Initial Catalog=Project;Persist Security Info=True;User ID=sa;Password=pokemoncom@123");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Staff(ID, Name, Username, Mobile_Num, Address) VALUES(@ID, @Name, @Username, @Mobile_Num, @Address)", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox5.Text));
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Username", textBox2.Text);
            cmd.Parameters.AddWithValue("@Mobile_Num", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@Address", textBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            BindData();
            MessageBox.Show("Successfully Inserted");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BindData();
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-LG6P4QHF;Initial Catalog=Project;Persist Security Info=True;User ID=sa;Password=pokemoncom@123");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update Staff SET Name=@Name, Username=@Username, Mobile_Num=@Mobile_Num, Address=@Address WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox5.Text));
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Username", textBox2.Text);
            cmd.Parameters.AddWithValue("@Mobile_Num", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@Address", textBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            BindData();
            MessageBox.Show("Successfully Updated");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BindData();
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-LG6P4QHF;Initial Catalog=Project;Persist Security Info=True;User ID=sa;Password=pokemoncom@123");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Staff WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox5.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-LG6P4QHF;Initial Catalog=Project;Persist Security Info=True;User ID=sa;Password=pokemoncom@123");
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE Staff WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox5.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            BindData();
            MessageBox.Show("Successfully Deleted");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                e.Cancel = true;
                textBox5.Focus();
                errorProvider1.SetError(textBox5, "ID should Unique and not be left blank!!!!!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox5, "");
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "Enter your Name !");
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
                errorProvider1.SetError(textBox2, "Enter your Username !");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox2, "");
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                e.Cancel = true;
                textBox3.Focus();
                errorProvider1.SetError(textBox3, "Enter your Mobile Numberk!!!!!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox3, "");
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                e.Cancel = true;
                textBox4.Focus();
                errorProvider1.SetError(textBox4, "Password not be left blank!!!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox4, "");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ob13 = new Form7();
            ob13.Show();

        }

        private void Form5_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void Form5_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void Form5_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }
    }
}
