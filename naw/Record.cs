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
    public partial class Record : Form
    {
        public Record()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int mid = int.Parse(textBox1.Text);
            string patientname = textBox2.Text;
            string doctorname = textBox3.Text;
            string nurse = textBox4.Text;
            string diagnosis = textBox5.Text;
            string prescription = textBox6.Text;
            string treatment = textBox7.Text;

            // Reorder variable names to match the query parameter order
            string query = "insert into records(mid, patientname, doctorname, nurse, diagnosis, prescription, treatment) values(@MID, @PatientName, @DoctorName, @Nurse, @Diagnosis, @Prescription, @Treatment)";
            using (MySqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MID", mid);
                    cmd.Parameters.AddWithValue("@PatientName", patientname);
                    cmd.Parameters.AddWithValue("@DoctorName", doctorname);
                    cmd.Parameters.AddWithValue("@Nurse", nurse);
                    cmd.Parameters.AddWithValue("@Diagnosis", diagnosis);
                    cmd.Parameters.AddWithValue("@Prescription", prescription);
                    cmd.Parameters.AddWithValue("@Treatment", treatment);
                    // Swap age and address parameter assignments to match query order
                    // Gender parameter remains last

                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Record Inserted Successfully");
            RecordData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            int mid = int.Parse(textBox1.Text);
            string patientname = textBox2.Text;
            string doctorname = textBox3.Text;
            string nurse = textBox4.Text;
            string diagnosis = textBox5.Text;
            string prescription = textBox6.Text;
            string treatment = textBox7.Text;

            string query = "update records set patientname=@PatientName,doctorname=@DoctorName,nurse=@Nurse,diagnosis=@Diagnosis,prescription=@Prescription,treatment=@Treatment   where mid=@MID";
            using (MySqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MID", mid);
                    cmd.Parameters.AddWithValue("@PatientName", patientname);
                    cmd.Parameters.AddWithValue("@DoctorName", doctorname);
                    cmd.Parameters.AddWithValue("@Nurse", nurse);
                    cmd.Parameters.AddWithValue("@Diagnosis", diagnosis);
                    cmd.Parameters.AddWithValue("@Prescription", prescription);
                    cmd.Parameters.AddWithValue("@Treatment", treatment);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Record Update Successfully");
            RecordData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int mid = int.Parse(textBox1.Text);


            string query = "delete from records where mid=@mid";
            using (MySqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MID", mid);
                    cmd.ExecuteNonQuery();

                }
            }
            MessageBox.Show("Record Deleted Successfully");
            RecordData();
        }

        private void Record_Load(object sender, EventArgs e)
        {
            RecordData();
        }

        private void RecordData()
        {
            string query = "select * from records";
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
