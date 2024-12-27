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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace naw
{
    public partial class Bill : Form
    {
        public Bill()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int bid = int.Parse(textBox1.Text);
            string patientname = textBox2.Text;
            string amount = textBox3.Text;
            string status = textBox4.Text;

            // Reorder variable names to match the query parameter order
            string query = "insert into bills(bid, patientname, amount, status) values(@BID, @PatientName, @Amount, @Status)";
            using (MySqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BID", bid);
                    cmd.Parameters.AddWithValue("@PatientName", patientname);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@Status", status);
                    // Swap age and address parameter assignments to match query order
                    // Gender parameter remains last

                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Record Inserted Successfully");
            BillData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int bid = int.Parse(textBox1.Text);
            string patientname = textBox2.Text;
            string amount = textBox3.Text;
            string status = textBox4.Text;

            string query = "update bills set patientname=@PatientName,amount=@Amount,status=@Status where bid=@BID";
            using (MySqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BID", bid);
                    cmd.Parameters.AddWithValue("@PatientName", patientname);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Record Update Successfully");
            BillData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int bid = int.Parse(textBox1.Text);


            string query = "delete from bills where bid=@bid";
            using (MySqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BID", bid);
                    cmd.ExecuteNonQuery();

                }
            }
            MessageBox.Show("Record Deleted Successfully");
            BillData();
        }

        private void Bill_Load(object sender, EventArgs e)
        {
            BillData();
        }
        private void BillData()
        {
            string query = "select * from bills";
            using (MySqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }

                }
            }
        }
    }
}
