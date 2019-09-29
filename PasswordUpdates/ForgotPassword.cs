using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Windows.Forms;
using System.Configuration;


namespace ZonalProject
{
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }
     

        //creates random number
        static Random rnd = new Random();
        static int verif = rnd.Next(2000, 4000);
        //sets the verification code to equal the random number
        public int verifCode = verif;

        

        public void button2_Click(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            //gets the verification code and puts it in a public variable in a class called verif code
            VerifCode.Verif = verifCode;
            //gets the current email and then saves it incase the verif code needs to be resent
            VerifCode.EmailReSend = EmailText.Text;

            //creates a new datatable
            DataTable dt = new DataTable();
            //creates adapter
            SqlDataAdapter adapt = new SqlDataAdapter();
            //creates command
            SqlCommand Tcmd = new SqlCommand();
            //sets the connection
            Tcmd.Connection = con;
            //the sql query this part is pretty much just getting the email from the textbox
            Tcmd.CommandText = "select * from Employees Where Email='" + EmailText.Text + "'";
            adapt.SelectCommand = Tcmd;
            // filling the datatable
            adapt.Fill(dt);

            //if the email does not match the database email then continue
            if (dt.Rows.Count == 0)
            {
                // show theres an invalid email
                MessageBox.Show("Invalid Email");
                //return so the email dosent send
                return;
            }
            else
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    //sets the server for the email
                    SmtpClient SmtpServer = new SmtpClient("in-v3.mailjet.com");
                    //the email that goes to the user 
                    mail.From = new MailAddress("PasswordVerification@employeehelp.com");
                    //sets the email to the email in the texbox if valid
                    mail.To.Add(EmailText.Text);
                    //Sets the subject of the email
                    mail.Subject = "Password Reset";
                    // sends the verification code to the email
                    mail.Body = "Verification code : " + verif;

                    //sets the port of the server
                    SmtpServer.Port = 587;
                    //uses the credentials needed for the smtp to run (username, password)
                    SmtpServer.Credentials = new System.Net.NetworkCredential("e4f03c077eb1314b3fcdd94eb12f2624", "d5cecc78b91bd78eb3771b45681c06db");
                    SmtpServer.EnableSsl = true;
                    //sends the email
                    SmtpServer.Send(mail);
                    //shows that the email has been sent
                    MessageBox.Show("Sent");


                }
                catch (Exception ex) //catch an error if one occurs
                {
                    //send to screen
                    MessageBox.Show(ex.ToString());
                }

                //hide this form
                this.Hide();
                //open the verification form
                Verification x = new Verification();
                x.Show();
            }

          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 x = new Form1();
            x.Show();


        }

        private void ForgotPassword_Load(object sender, EventArgs e)
        {

        }
    }
}
