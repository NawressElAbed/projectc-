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
    public partial class Patient : Form
    {
        public Patient()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int patientid = int.Parse(textBox1.Text);
            string patientname = textBox5.Text;
            int age = int.TryParse(textBox2.Text, out int result) ? result : 0;
            string gender = textBox3.Text;
            string address = textBox4.Text;

            // Reorder variable names to match the query parameter order
            string query = "insert into patients(patientid, patientname, age, gender, address) values(@PatientID, @PatientName, @Age, @Gender, @Address)";
            using (MySqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientID", patientid);
                    cmd.Parameters.AddWithValue("@PatientName", patientname);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    // Swap age and address parameter assignments to match query order
                    
                    cmd.Parameters.AddWithValue("@Address", address);
                     // Gender parameter remains last

                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Record Inserted Successfully");
            PatientData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int patientid = int.Parse(textBox1.Text);
            string patientname = textBox5.Text;
            int age = int.TryParse(textBox2.Text, out int result) ? result : 0;
            string gender = textBox3.Text;
            string address = textBox4.Text;

            string query = "update patients set patientname=@PatientName,age=@Age,gender=@Gender,address=@Address where patientid=@PatientID";
            using (MySqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientID", patientid);
                    cmd.Parameters.AddWithValue("@PatientName", patientname);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Record Update Successfully");
            PatientData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int patientid = int.Parse(textBox1.Text);


            string query = "delete from patients where patientid=@patientid";
            using (MySqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientID", patientid);
                    cmd.ExecuteNonQuery();

                }
            }
            MessageBox.Show("Record Deleted Successfully");
            PatientData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Patient_Load(object sender, EventArgs e)
        {

            PatientData();
            
        }

        private void PatientData()
        {
            string query = "select * from patients";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
