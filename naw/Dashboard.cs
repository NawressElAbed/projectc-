using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace naw
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            Display();
            Display2();
            Display3();
            Display4();
        }

        private void Display()
        {
            string connectionString = "Server=127.0.0.1;Database=Hopital;Uid=root;Pwd=root";
            using(MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM patients ";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        label1Count1.Text = "Total Patient : " + count.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

        private void Display2()
        {
            string connectionString = "Server=127.0.0.1;Database=Hopital;Uid=root;Pwd=root";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM doctors ";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        label2Count2.Text = "Total Docteur : " + count.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

        private void Display3()
        {
            string connectionString = "Server=127.0.0.1;Database=Hopital;Uid=root;Pwd=root";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM nurses ";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        label3Count3.Text = "Total Infirmie : " + count.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }
        private void Display4()
        {
            string connectionString = "Server=127.0.0.1;Database=Hopital;Uid=root;Pwd=root";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM appointments ";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        label4Count4.Text = "Total Rendez-vous : " + count.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

        private void label4Count4_Click(object sender, EventArgs e)
        {

        }
    }
}
