using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace ZonalProject
{
    public partial class ResetPassword : Form
    {
        //sets connection

        public ResetPassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            //creates a new datatable
            DataTable dt = new DataTable();
            //creates new adapter
            SqlDataAdapter adapt = new SqlDataAdapter();
            //creates a new command
            SqlCommand Tcmd = new SqlCommand();
            //sets the command connection equal to the database connection 
            Tcmd.Connection = con;
            //write the query in this case being selecting the email from the employees table
            Tcmd.CommandText = "select * from Employees Where Email='" + Email.Text + "'";
            //sets the data adapter to equal the sql query
            adapt.SelectCommand = Tcmd;
            //fills the datatable
            adapt.Fill(dt);
            
            //checks if the textboxes are empty if so continue if statment
            if (Email.Text == "" || NewPass.Text == "" || ConfirmPass.Text == "")
            {
                //ask to fill in all fields
                MessageBox.Show("Please enter all fields");
            }

            //if the email does not match on of the database
            if (dt.Rows.Count == 0)
            {
                //displays to the user the email is invalid
                MessageBox.Show("Invalid Email");

            }
            
            //checks to see if the email is equal to the email resend if not  send error
            else if (Email.Text != VerifCode.EmailReSend)
            {
                //if not show an error message and return so no further code is carried out
                MessageBox.Show("Please enter the correct email");
                MessageBox.Show(VerifCode.EmailReSend);
                return;
            }

            //checks to see if the new passwords is equal to the confirm passwords textboxes if so carry on
            else if (NewPass.Text == ConfirmPass.Text)
            {
                //opens connection
                con.Open();
                //sets the query in this case updating the password where the current email is located
                Tcmd.CommandText = "update Employees set Password='" + PasswordLogin.encryptPassword(NewPass.Text.Trim()) + "' where Email='" + Email.Text + "'";
                //shows the user a succesful reset has taken place
                MessageBox.Show("Reset");
                //resets the datatable so the passwords is updated
                dt.Reset();
                //fills the datatable with the new password
                adapt.Fill(dt);
                Tcmd.ExecuteNonQuery();

                //closes the form and goes back to login screen
                this.Close();
                Form1 x = new Form1();
                x.Show();

            }
            else
            {
                //if the new passwords and confirm password dosent match then show this
                MessageBox.Show("Passwords dont match!");
            }

            //closes connection to database
            con.Close();

         
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //closes form and opens login screen
            this.Close();
            Form1 x = new Form1();
            x.Show();
        }

        private void ResetPassword_Load(object sender, EventArgs e)
        {

        }
    }
}
