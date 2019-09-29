using System;
using System.Net.Mail;
using System.Windows.Forms;

namespace ZonalProject
{
    public partial class Verification : Form
    {
        public Verification()
        {
            InitializeComponent();
        }

        //stores the verification code
        int confirmVERIF = VerifCode.Verif;
        //stores the written email 
        string resendEMAIL = VerifCode.EmailReSend;

        private void Submit_Click(object sender, EventArgs e)
        {
            //takes the verfication code textbox and turns it from a string to int
            int verifText = Convert.ToInt32(VerifText.Text);
            //checks to make sure the verification code is equal to the one stored in the class if so, continue 
            if (verifText == confirmVERIF)
            {
                //closes the form and opens the reset password panel
                this.Close();
                ResetPassword x = new ResetPassword();
                x.Show();
            }
            else
            {
                //if the verif code is not matched with the class variable it will ask you to try again
                MessageBox.Show("Please Try Again!");
            }

        }

        private void resend_Click(object sender, EventArgs e)
        {
            //trys the code 
            try
            {
                //exact same as the reset passwords panel but it sends the email to the stored email so you dont have to retype emails.
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("in-v3.mailjet.com");
                mail.From = new MailAddress("PasswordVerification@employeehelp.com");
                mail.To.Add(resendEMAIL);
                mail.Subject = "Test Mail";
                mail.Body = "Verification code : " + confirmVERIF;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("e4f03c077eb1314b3fcdd94eb12f2624", "d5cecc78b91bd78eb3771b45681c06db");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("Sent");

                
            }
            catch (Exception ex) //catches errors
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //closes the form and opens login page
            this.Close();
            Form1 x = new Form1();
            x.Show();
        }

        private void Verification_Load(object sender, EventArgs e)
        {

        }

    }
}
