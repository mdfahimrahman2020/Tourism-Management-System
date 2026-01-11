using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp13
{
    public partial class Form6 : Form
    {
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);

        Form3 ob9;
        Form4 ob10;
        Form1 ob1;
        public Form6()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ob9 = new Form3();
            ob9.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ob10 = new Form4();
            ob10.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logged Out!");
            this.Hide();
            ob1 = new Form1();
            ob1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("User Feedback Message!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("System Settings!");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form6_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void Form6_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void Form6_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }
    }
}
