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
    public partial class Appointment : Form
    {
        public Appointment()
        {
            InitializeComponent();
        }

        private void Appointment_Load(object sender, EventArgs e)
        {
            AppointmentData();
        }

        private void AppointmentData()
        {
            string query = "select * from appointments";
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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int aid = int.Parse(textBox1.Text);
            string patientname = textBox2.Text;
            string doctorname = textBox3.Text;
            string date_created = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string status = textBox4.Text;

            // Reorder variable names to match the query parameter order
            string query = "insert into appointments(aid, patientname, doctorname, date_created, status) values(@AID, @PatientName, @DoctorName, @Date_Created, @Status)";
            using (MySqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AID", aid);
                    cmd.Parameters.AddWithValue("@PatientName", patientname);
                    cmd.Parameters.AddWithValue("@DoctorName", doctorname);
                    cmd.Parameters.AddWithValue("@Date_Created", date_created);
                    cmd.Parameters.AddWithValue("@Status", status);
                    // Swap age and address parameter assignments to match query order
                    // Gender parameter remains last

                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Record Inserted Successfully");
            AppointmentData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int aid = int.Parse(textBox1.Text);
            string patientname = textBox2.Text;
            string doctorname = textBox3.Text;
            string date_created = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string status = textBox4.Text;

            string query = "update appointments set patientname=@PatientName,doctorname=@DoctorName,date_created=@Date_Created,status=@Status where aid=@AID";
            using (MySqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AID", aid);
                    cmd.Parameters.AddWithValue("@PatientName", patientname);
                    cmd.Parameters.AddWithValue("@DoctorName", doctorname);
                    cmd.Parameters.AddWithValue("@Date_Created", date_created);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Record Update Successfully");
            AppointmentData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            int aid = int.Parse(textBox1.Text);


            string query = "delete from appointments where aid=@aid";
            using (MySqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AID", aid);
                    cmd.ExecuteNonQuery();

                }
            }
            MessageBox.Show("Record Deleted Successfully");
            AppointmentData();
        }
    }
}
