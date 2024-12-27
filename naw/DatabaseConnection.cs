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
    public partial class DatabaseConnection : Form
    {
        private MySqlConnection connection;
        public DatabaseConnection()
        {
            string connectionString = "Server=127.0.0.1;Database=Hopital;Uid=root;Pwd=root;";
            connection = new MySqlConnection(connectionString);
            InitializeComponent();
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        private void DatabaseConnection_Load(object sender, EventArgs e)
        {

        }
    }
}
