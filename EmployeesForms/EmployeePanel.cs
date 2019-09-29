using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing;

namespace ZonalProject
{
    public partial class EmployeePanel : Form
    {
        private bool mouseDown;
        private Point lastLocation;

        static Random holidayIDRand = new Random();
        static int holidayID = holidayIDRand.Next(1, 1000);
        int HolidayID = holidayID;

        public EmployeePanel()
        {
            InitializeComponent();
        }

        private void EmployeePanel_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'registerdUsersDataSet3.HolidayLeave' table. You can move, or remove it, as needed.
            this.holidayLeaveTableAdapter1.Fill(this.registerdUsersDataSet3.HolidayLeave);
            // TODO: This line of code loads data into the 'registerdUsersDataSet2.HolidayLeave' table. You can move, or remove it, as needed.
            this.holidayLeaveTableAdapter.Fill(this.registerdUsersDataSet2.HolidayLeave);
            NameLabel.Text = "Welcome, " + CurrentUser.Name + "!";

            // TODO: This line of code loads data into the 'rolesTableData.Roles' table. You can move, or remove it, as needed.
            this.rolesTableAdapter.Fill(this.rolesTableData.Roles);
            // TODO: This line of code loads data into the 'employeesTableData.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.employeesTableData.Employees);
            // TODO: This line of code loads data into the 'taskTableData.TaskSchedule' table. You can move, or remove it, as needed.
            this.taskScheduleTableAdapter.Fill(this.taskTableData.TaskSchedule);

            var connectionString = ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);


            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TaskSchedule";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            TasksGrid.DataSource = dt;

            TasksGrid.Refresh();

            con.Close();

            Dashboard.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            holidayPanel.Visible = false;

        }

        private void SearchUser_Click(object sender, EventArgs e)
        {
            //opens the connection 
            var connectionString = ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            //checks to see if the search box is populated if not then show all employees
            if (textBox3.Text == "")
            {
                //opens connection
                con.Open();
                //creating the sql command
                SqlCommand Tcmd = con.CreateCommand();
                //setting the command type
                Tcmd.CommandType = CommandType.Text;
                //selecting all employees
                Tcmd.CommandText = "select * from Employees";
                //executing the sql
                Tcmd.ExecuteNonQuery();
                //creating the new datatable to fill
                DataTable dta = new DataTable();
                SqlDataAdapter adapt = new SqlDataAdapter(Tcmd);
                //filling the adapter with the correct data from the dt
                adapt.Fill(dta);
                //filling the dgv with the data
                ListOfUsers.DataSource = dta;
                con.Close();
                //refreshing the dgv
                ListOfUsers.Refresh();
            }
            else
            {
                //opens connection
                con.Open();
                //selected everything from the dgv where the first name is equal to whats in the txtbox
                SqlDataAdapter search = new SqlDataAdapter("select * from Employees where FirstName like '" + textBox3.Text + "%'", con);
                DataTable dt = new DataTable();
                search.Fill(dt);
                ListOfUsers.DataSource = dt;
                con.Close();

                textBox3.Clear();
            }
        }

        private void PanelTop_MouseDown(object sender, MouseEventArgs e)
        {
            //if the mouse is held down set mouseDown = true and then set the last location equal to the new one
            mouseDown = true;
            lastLocation = e.Location;
        }


        private void PanelTop_MouseUp(object sender, MouseEventArgs e)
        { 
            //if the mouse is brought up set the bool to false
            mouseDown = false;
        }

        private void PanelTop_MouseMove(object sender, MouseEventArgs e)
        {
            //if mouse down is true then continue
            if (mouseDown)
            {
                //set the location of the for equal to the new x and y location of the last locatioh
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                //update the location of the form
                this.Update();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //if the X is pressed exit the application
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //[CONNECTION STRINGS]
            var connectionString = ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            //Go through all the data in TaskSchedule table and display
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TaskSchedule";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            TasksGrid.DataSource = dt;

            TasksGrid.Refresh();

            con.Close();

            Dashboard.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            holidayPanel.Visible = false;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //[CONNECTION STRINGS]
            var connectionString = ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            //when the button is pressed go through all data from the Employees table and then display
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Employees";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            ListOfUsers.DataSource = dt;

            ListOfUsers.Refresh();

            con.Close();

            panel2.Visible = true;
            Dashboard.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            holidayPanel.Visible = false;

        }


        private void button7_Click(object sender, EventArgs e)
        {            
            //if any fields are not populated then send an error message and return
            if (leaveFirstname.Text == "" || LeaveLastName.Text == "" || DateOfLeaving.Text == "" || DateOfReturn.Text == "")
            {
                MessageBox.Show("Please Enter All Fields!");

                return;
            }

            //[CONNECTION STRINGS]
            var connectionString = ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            //Create a command to check the employee id, username and then check if it they have applied for holiday leave already 
            SqlCommand check_User_Name = new SqlCommand("SELECT EmployeeID FROM HolidayLeave WHERE EmployeeID = '" + CurrentUser.currentID + "'", con);
            int? UserExist = check_User_Name.ExecuteScalar() as int?;
            //create a string in order to show if the application is pending then display relevant colour
            string Null = "Pending";

            //if the id exists spit out error and return
            if (UserExist > 0)
            {
                MessageBox.Show("You have already applied for leave");

                return;
            }
            //if the id dosent exist then continue
            else
            {
                //create a cmd inserting all the data in the fields into the holidayleave table
                cmd.CommandText = "insert into HolidayLeave values ('" + CurrentUser.currentID + "','" + leaveFirstname.Text + "','" + LeaveLastName.Text + "','" + DateOfLeaving.Text + "','" + DateOfReturn.Text + "','" +Null+ "')";
                cmd.ExecuteNonQuery();
                //submite and then clear the text boxes
                MessageBox.Show("Submited for approval!");
                leaveFirstname.Clear();
                LeaveLastName.Clear();
            }
            //close connection
            con.Close();

        }

        private void HolidayLeaveList_Click(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            //TOOO: clean up all button presses and create a specific class to update all datagrid views for functionality
            con.Open();
            SqlCommand Tcmd = con.CreateCommand();
            Tcmd.CommandType = CommandType.Text;
            Tcmd.CommandText = "select * from HolidayLeave";
            Tcmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter(Tcmd);
            adapt.Fill(dta);
            dataGridView2.DataSource = dta;
            con.Close();

            dataGridView2.Refresh();

            //set the panels active based on the button that is pressed
            holidayPanel.Visible = true;
            panel2.Visible = false;
            Dashboard.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
           


            //creating a loop for all the rows in the dgv for holiday leave
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                //getting the value of cell 5 which would be the approved status either approved or disapproved
                string val = dataGridView2.Rows[i].Cells[4].Value.ToString();
                //if the value is a approved then set that row to the saved green
                if (val == "Approved")
                {
                    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Properties.Settings.Default.DGVColourGreen;
                }
                //if the value is a disapproved then set that row to the saved red
                else if (val == "Disapproved")
                {
                    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Properties.Settings.Default.DGVColourRed;
                }
                //if the value is a pending then set that row to the color coral
                else if (val == "Pending")
                {
                    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Coral;
                }
            }
        }

        private void Approve_Click(object sender, EventArgs e)
        {
   
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //[CONNECTION STRINGS]
            var connectionString = ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            //filling a dataset with relevant information and then displaying it
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TaskSchedule";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            EmployeeTasks.DataSource = dt;

            EmployeeTasks.Refresh();

            con.Close();

            panel3.Visible = true;
            panel2.Visible = false;
            Dashboard.Visible = false;
            panel4.Visible = false;
            holidayPanel.Visible = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel3.Visible = false;
            panel2.Visible = false;
            Dashboard.Visible = false;
            holidayPanel.Visible = false;
        }


        //sign out closing buttons and showing the main screen 
        private void SignOut_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Form1 x = new Form1();
            x.Show();
        }

        private void DashSignOut_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 x = new Form1();
            x.Show();
        }

        private void TaskSignOut_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 x = new Form1();
            x.Show();
        }

        private void TaskSignOut_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Form1 x = new Form1();
            x.Show();
        }

        private void LeaveSignOut_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 x = new Form1();
            x.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 x = new Form1();
            x.Show();
        }

    }
}
