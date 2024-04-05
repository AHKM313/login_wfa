using System;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Runtime.Remoting.Contexts;
using System.Xml.Linq;


namespace login_wfa
{

    public partial class Form1 : KryptonForm
    {
        // Define the database file name
        private const string DatabaseFileName = "Database1.mdf";

        private string GetConnectionString()
        {
            string dataDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string dbPath = System.IO.Path.Combine(dataDirectory, DatabaseFileName);
            return $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True;";
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (username_input.Text.Length == 0)
            {
                username_input.StateCommon.Border.Color1 = Color.Gray;
                
            }
            else
            if (username_input.Text.Length > 0)
            {
                  username_input.StateCommon.Border.Color1 = Color.Green;

            }

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string username = username_input.Text;
            string password = password_input.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                username_input.StateCommon.Border.Color1 = Color.Red;
            }
            if ( string.IsNullOrWhiteSpace(password))
            {
                password_input.StateCommon.Border.Color1 = Color.Red;
            }


            try
            {
                string str_con = GetConnectionString();
                using (SqlConnection con = new SqlConnection(str_con))
                {
                    con.Open();

                    string query = "SELECT COUNT(*) FROM accounts_tb WHERE username = @Username AND password = @Password";
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        int userCount = Convert.ToInt32(command.ExecuteScalar());

                        if (userCount == 1)
                        {
                            MessageBox.Show("Login was successful");
                        }
                        else
                        {
                            MessageBox.Show("Login was unsuccessful");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }


        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void username_input_TextChanged(object sender, EventArgs e)
        {
            if (password_input.Text.Length > 0)
            {
                password_input.StateCommon.Border.Color1 = Color.Green;
            }else if (password_input.Text.Length == 0)
            {
                password_input.StateCommon.Border.Color1 = Color.Gray;
            }
        }
    }
    
}
