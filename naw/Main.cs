using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace naw
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Patient pt = new Patient();
            pt.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Doctors dr = new Doctors();
            dr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Nurse nr = new Nurse();
            nr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Appointment at = new Appointment();
            at.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Record rd = new Record();
            rd.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bill bi = new Bill();
            bi.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Dashboard dd = new Dashboard();
            dd.Show();
        }
    }
}
