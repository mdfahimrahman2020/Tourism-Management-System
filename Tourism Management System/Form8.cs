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
    public partial class Form8 : Form
    {
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);

        Form3 ob8;
        Form1 ob1;
        public Form8()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ob8 = new Form3();
            ob8.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logged Out!");
            this.Hide();
            ob1 = new Form1();
            ob1.Show();
        }

        private void Form8_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void Form8_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void Form8_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }
    }
}
