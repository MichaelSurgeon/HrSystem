using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.Timers;

namespace ZonalProject
{
    public partial class Form1 : Form
    {

        private bool mouseDown;
        private Point lastLocation;

        System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Opacity = 0;
            t1.Interval = 15;
            t1.Tick += new EventHandler(fadeIn);
            t1.Start();
        }

        void fadeIn(object sender, EventArgs e)
        {
            if (Opacity >= 1)
            {
                t1.Stop();
            }
            else
            {
                Opacity += 0.05;
            }
        }

        private void Login_Click_1(object sender, EventArgs e)
        {
            

            //Opened his connection 
            var connectionString = ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            
            string userid = Username.Text;
            string password = Password.Text;
            //selects the username and password and makes sure they are case sensitive based on what the password was through registration 
            string checkLogin = "select UserID,Password from Employees where UserID=@Username COLLATE Latin1_General_CS_AS and Password=@Password COLLATE Latin1_General_CS_AS";
            SqlCommand Tcmd = new SqlCommand(checkLogin, con);
            Tcmd.Parameters.AddWithValue("@Username", Username.Text);
            //checks the password but uses the encrypted function so the real password is never reavled 
            Tcmd.Parameters.AddWithValue("@Password", PasswordLogin.encryptPassword(Password.Text));
            SqlDataAdapter da = new SqlDataAdapter(Tcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            //checks to see if the password and username match and are infact a part of the database
            if (dt.Rows.Count > 0)
            {
                this.Hide();
                WelcomePage y = new WelcomePage();
                y.Show();

            }
            else if (userid == "admin" && password == "admin")
            {
                this.Hide();
                AdminDashboard a = new AdminDashboard();
                a.Show();

                return;
            }
            else
            {
                MessageBox.Show("Incorrect password please try again!");

                return;
            }

            string queryString = "select EmployeeID from Employees where UserID=@UserID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                command.Parameters.AddWithValue("@UserID", Username.Text);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    reader.Read();
                    CurrentUser.currentID = reader.GetInt32(0);
                    // Call Close when done reading.
                    reader.Close();
                }
            }

            string getUserName = "select FirstName from Employees where UserID=@UserID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand getName = new SqlCommand(getUserName, connection))
            {
                getName.Parameters.AddWithValue("@UserID", Username.Text);

                connection.Open();
                using (SqlDataReader reader = getName.ExecuteReader())
                {

                    reader.Read();
                    CurrentUser.Name = reader.GetString(0);
                    // Call Close when done reading.
                    reader.Close();
                }
            }


            con.Close();

        }

        private void PanelTop_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void PanelTop_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void PanelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void RegisterUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register y = new Register();
            y.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            ForgotPassword x = new ForgotPassword();
            x.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Password.PasswordChar = '\0';
            }
            else
            {
                Password.PasswordChar = '•';
            }
        }
    }
}
