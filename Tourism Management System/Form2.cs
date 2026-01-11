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
    public partial class Form2 : Form
    {
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);

        Form1 ob2;

        public Form2()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ob2 = new Form1();
            ob2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "Name not be left blank!");
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
                errorProvider1.SetError(textBox2, "Username should Unique and not be left blank!!!");
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
                errorProvider1.SetError(textBox3, "Mobile Number Range[0-9] and not be left blank!!!");
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
                errorProvider1.SetError(textBox4, "Please Enter your address!!!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox4, "");
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                e.Cancel = true;
                textBox5.Focus();
                errorProvider1.SetError(textBox4, "ID should Unique and not be left blank!!!!!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox5, "");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-LG6P4QHF;Initial Catalog=Project;Persist Security Info=True;User ID=sa;Password=pokemoncom@123");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Signup(ID, Name, Username, Mobile_Number, Address) VALUES(@ID, @Name, @Username, @Mobile_Number, @Address)", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox5.Text));
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Username", textBox2.Text);
            cmd.Parameters.AddWithValue("@Mobile_Number", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@Address", textBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            MessageBox.Show("Successfully Inserted");
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }
    }
}
