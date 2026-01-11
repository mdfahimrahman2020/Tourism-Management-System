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

    public partial class Form1 : Form
    {
        private bool _dragging=false;
        private Point _start_point= new Point(0, 0);

        Form9 ob1;
        Form2 ob4;
        public Form1()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ob1 = new Form9();
            ob1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are in Home page");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ob4 = new Form2();
            ob4.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string username = textBox1.Text;
            string password = textBox2.Text;


            if ((username == "admin") && (password == "pass"))
            {
                this.Hide();
                Form6 A = new Form6();
                A.Show();
            }

            else if ((username == "") && (password == ""))
            {
                MessageBox.Show("Fill up the form", "Error");
            }

            else if ((username == "Maha1") && (password == "12345678"))
            {
                MessageBox.Show("Successfully loged in");
                //after successful it will redirect  to next page .  
                this.Hide();
                Form7 Manager = new Form7();
                Manager.Show();
            }

            else if ((username == "Maha2") && (password == "12345678"))
            {
                MessageBox.Show("Successfully loged in");
                //after successful it will redirect  to next page .  
                this.Hide();
                Form8 Staff = new Form8();
                Staff.Show();
            }
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }
    }
}
