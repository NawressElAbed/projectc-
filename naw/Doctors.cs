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
    public partial class Doctors : Form
    {
        public Doctors()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int doctorid = int.Parse(textBox1.Text);
            string doctorname = textBox5.Text;
            string speciality = textBox2.Text;
            string phone = textBox3.Text;
            string department = textBox4.Text;

            // Reorder variable names to match the query parameter order
            string query = "insert into doctors(doctorid, doctorname, speciality, phone, department) values(@DoctorID, @DoctorName, @Speciality, @Phone, @Department)";
            using (MySqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DoctorID", doctorid);
                    cmd.Parameters.AddWithValue("@DoctorName", doctorname);
                    cmd.Parameters.AddWithValue("@Speciality", speciality);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    // Swap age and address parameter assignments to match query order

                    cmd.Parameters.AddWithValue("@Department", department);
                    // Gender parameter remains last

                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Record Inserted Successfully");
            DoctorData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int doctorid = int.Parse(textBox1.Text);
            string doctorname = textBox5.Text;
            string speciality = textBox2.Text;
            string phone = textBox3.Text;
            string department = textBox4.Text;

            string query = "update doctors set doctorname=@DoctorName,speciality=@Speciality,phone=@Phone,department=@Department where doctorid=@DoctorID";
            using (MySqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DoctorID", doctorid);
                    cmd.Parameters.AddWithValue("@DoctorName", doctorname);
                    cmd.Parameters.AddWithValue("@Speciality", speciality);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    // Swap age and address parameter assignments to match query order

                    cmd.Parameters.AddWithValue("@Department", department);
                    // Gender parameter remains last

                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Record Update Successfully");
            DoctorData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int doctorid = int.Parse(textBox1.Text);


            string query = "delete from doctors where doctorid=@doctorid";
            using (MySqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DoctorID", doctorid);
                    cmd.ExecuteNonQuery();

                }
            }
            MessageBox.Show("Record Deleted Successfully");
            DoctorData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Doctor_Load(object sender, EventArgs e)
        {

            DoctorData();

        }
        private void DoctorData()
        {
            string query = "select * from doctors";
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
