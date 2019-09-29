using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace ZonalProject
{
    public partial class WelcomePage : Form
    {
        //creates the fade timer
        System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();

        public WelcomePage()
        {
            InitializeComponent();
        }

        private void WelcomePage_Load(object sender, EventArgs e)
        {
            //sets the opactiy to 0 of the form
            Opacity = 0;
            //creates the time interval or how long the timer should be
            t1.Interval = 45;
            //ticks the timer 
            t1.Tick += new EventHandler(fadeIn);
            //starts the timer
            t1.Start();

        }

        void fadeIn(object sender, EventArgs e)
        {
            //sets the welcome label to the logged on user
            WelcomeLabel.Text = "Welcome Back, " + CurrentUser.Name + "!";

            //checks to see if the opacity is full if so complete
            if (Opacity >= 1)
            {
                //stop the timer
                t1.Stop();

                //close the welcome form
                this.Close();
                //open the employee panel
                EmployeePanel x = new EmployeePanel();
                x.Show();
            }
            else
            {
                Opacity += 0.05;
            }

           
        }
 
    }
}
