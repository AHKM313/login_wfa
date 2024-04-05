using System;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;
using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;


namespace login_wfa
{

    public partial class Form1 : KryptonForm
    {

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


            //SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\mbani\\OneDrive\\Documents\\db.mdf;Integrated Security=True;Connect Timeout=30;");

            //SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from ss_Table where username ='" + username_input.Text + "'and password ='" + password_input.Text + "'", con);

            //DataTable dt = new DataTable();

            //sda.Fill(dt);

            //if (dt.Rows[0][0].ToString() == "1")
            //{
            //    MessageBox.Show("Login was successful");
            //}
            //else
            //{
            //    MessageBox.Show("Login was unsuccessful");
            //}


            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }



            try
            {

                using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\mbani\\OneDrive\\Documents\\db.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();

                    // Create a parameterized query
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
