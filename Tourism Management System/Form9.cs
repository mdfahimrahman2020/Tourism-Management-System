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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp13
{
    public partial class Form9 : Form
    {
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);

        Form1 ob14;
        public Form9()
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
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ob14 = new Form1();
            ob14.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BindData();
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-LG6P4QHF;Initial Catalog=Project;Persist Security Info=True;User ID=sa;Password=pokemoncom@123");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM package WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            textBox1.Text = "";
            
        }

        private void Form9_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void Form9_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void Form9_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
    
}
