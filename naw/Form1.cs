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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                if (txtUsername.Text == "admin" && txtPassword.Text == "sc2139940")
                {
                    Main mn = new Main();
                    mn.Show();
                }
                else if (txtUsername.Text != "sanaw" || txtPassword.Text != "2139940")
                {
                    MessageBox.Show("Invalid username or password ");
                }
            }
        }
    }
}
