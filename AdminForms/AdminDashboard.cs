using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using ZonalProject.Properties;
using System.Timers;

namespace ZonalProject
{
    public partial class AdminDashboard : Form
    {
        //Variables used 
        private bool mouseDown;
        private Point lastLocation;
        public static string decryptedPassword = "";


        // Salary varibles
        public int Manager = 100000;
        public int Engineer = 40000;
        public int TeamLeader = 75000;
        public int EngineerScheduler = 25000;
        public int SeniorDevelopment = 55000;
        public int Programmer = 30000;
        public int Anaylst = 17000;




        //task id creation
        static Random taskRnd = new Random();
        static int taskID = taskRnd.Next(1, 1000);
        int TaskID = taskID;

        //for the holiday leave approval system
        private bool approved = false;
        private bool disApproved = false;

        //creates the fading timer
        System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();


        public AdminDashboard()
        {
            InitializeComponent();
        }

        void fadeIn(object sender, EventArgs e)
        {
            //if the opacity is full then complete
            if (Opacity >= 1)
            {
                //stop timer
                t1.Stop();
            }
            else
            {
                //increase opacity if the statment is not true
                Opacity += 0.05;
            }
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

            //set the opacity of the form to 0
            Opacity = 0;
            //set the interval of the timer
            t1.Interval = 15;
            //tick the timer
            t1.Tick += new EventHandler(fadeIn);
            //start the timer
            t1.Start();


            //filling data grids etc

            // TODO: This line of code loads data into the 'registerdUsersDataSet1.HolidayLeave' table. You can move, or remove it, as needed.
            this.holidayLeaveTableAdapter3.Fill(this.registerdUsersDataSet1.HolidayLeave);
            // TODO: This line of code loads data into the 'holidayLeaveApproval.HolidayLeave' table. You can move, or remove it, as needed.
            this.holidayLeaveTableAdapter2.Fill(this.holidayLeaveApproval.HolidayLeave);
            // TODO: This line of code loads data into the 'holidayDataDash.HolidayLeave' table. You can move, or remove it, as needed.
            this.holidayLeaveTableAdapter1.Fill(this.holidayDataDash.HolidayLeave);
            // TODO: This line of code loads data into the 'dashTasks.TaskSchedule' table. You can move, or remove it, as needed.
            this.taskScheduleTableAdapter1.Fill(this.dashTasks.TaskSchedule);
            // TODO: This line of code loads data into the 'departmentTableData1.Departments' table. You can move, or remove it, as needed.
            this.departmentsTableAdapter.Fill(this.departmentTableData1.Departments);
            // TODO: This line of code loads data into the 'employeesTableData.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.employeesTableData.Employees);
            // TODO: This line of code loads data into the 'holidayTableData.HolidayLeave' table. You can move, or remove it, as needed.
            this.holidayLeaveTableAdapter.Fill(this.holidayTableData.HolidayLeave);
            // TODO: This line of code loads data into the 'taskTableData.TaskSchedule' table. You can move, or remove it, as needed.
            this.taskScheduleTableAdapter.Fill(this.taskTableData.TaskSchedule);
            // TODO: This line of code loads data into the 'rolesTableData.Roles' table. You can move, or remove it, as needed.
            this.rolesTableAdapter.Fill(this.rolesTableData.Roles);

            //gets the connection
            var connectionString = ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            //Opens connection to the database
            con.Open();
            //creates a new sql command
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //Sets the sql query
            cmd.CommandText = "select * from Roles";
            //executes the query
            cmd.ExecuteNonQuery();
            //creates a new datatable
            DataTable dt = new DataTable();
            //creates a new adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //fills the adapater with the data from the cmd
            da.Fill(dt);
            //closes connection
            con.Close();

            //refreshes datagridview
            // TODO : RolesData.Refresh();

            //opens connection
            con.Open();
            //Creates a new command
            SqlCommand Taskscmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //creates the query
            cmd.CommandText = "select * from TaskSchedule";
            //Excutes the created query
            cmd.ExecuteNonQuery();
            //creates datatable
            DataTable TasksData = new DataTable();
            //creates adapter
            SqlDataAdapter TasksAdapter = new SqlDataAdapter(cmd);
            //fills adapter
            da.Fill(TasksData);
            DashTaskDataGrid.DataSource = TasksData;
            con.Close();

            //all the below code selects the correct data for each datagrid view and applys it to the datatable and then to the dgv

            con.Open();
            SqlCommand ListOfUsers = con.CreateCommand();
            ListOfUsers.CommandType = CommandType.Text;
            ListOfUsers.CommandText = "select * from Employees";
            ListOfUsers.ExecuteNonQuery();
            DataTable employeeTask = new DataTable();
            SqlDataAdapter usersAdapt = new SqlDataAdapter(ListOfUsers);
            usersAdapt.Fill(employeeTask);
            dataGridView1.DataSource = employeeTask;
            con.Close();

            dataGridView1.Refresh();

            con.Open();
            SqlCommand HolidayData = con.CreateCommand();
            HolidayData.CommandType = CommandType.Text;
            HolidayData.CommandText = "select * from HolidayLeave";
            HolidayData.ExecuteNonQuery();
            DataTable HolidayDataTable = new DataTable();
            SqlDataAdapter HolidayDataAdapter = new SqlDataAdapter(HolidayData);
            HolidayDataAdapter.Fill(HolidayDataTable);
            DashHolidayData.DataSource = HolidayDataTable;
            con.Close();

            // refreshes the datagridview
            DashHolidayData.Refresh();

            con.Open();
            SqlCommand Taskcmd = con.CreateCommand();
            Taskcmd.CommandType = CommandType.Text;
            Taskcmd.CommandText = "select * from TaskSchedule";
            Taskcmd.ExecuteNonQuery();
            DataTable dataTask = new DataTable();
            SqlDataAdapter tasksAdapt = new SqlDataAdapter(Taskcmd);
            tasksAdapt.Fill(dataTask);
            DashTaskDataGrid.DataSource = dataTask;
            con.Close();

            // refreshes the datagridview
            DashTaskDataGrid.Refresh();



            //setting the panels to visible if neccasary 
            Dashboard.Visible = true;
            AddPanel.Visible = false;
            tasksPanel.Visible = false;
            ListOfUsersPanel.Visible = false;
            holidayListPanel.Visible = false;

        }


        private void RegisterButton_Click(object sender, EventArgs e)
        {
            //sets connection
            var connectionString = ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);


            //opens connection
            con.Open();
            //Creates a command/sql query to select the userid from the database
            SqlCommand checkUserName = new SqlCommand("Select * from Employees where UserID=@Username", con);
            SqlCommand checkEmail = new SqlCommand("Select * from Employees where Email=@Email", con);
            //Trys to add the current data in the UserID text box to the database
            checkUserName.Parameters.AddWithValue("@Username", this.Username.Text);
            // same checks for the user id the only diffrence is its the email
            checkEmail.Parameters.AddWithValue("@Email", this.EmailBox.Text);
            var result = checkUserName.ExecuteScalar();
            var emailResult = checkEmail.ExecuteScalar();

            //checks to see if any textboxes are empty if so then it carrys on
            if (FirstNameBox.Text == "" || LastNameBox.Text == "" || DOBpicker.Text == "" || JobTitleBox.Text == "" || EmailBox.Text == "" || Username.Text == "" || Password.Text == "")
            {
                // if a empty a message box shows to ask to enter all fields
                MessageBox.Show("Please enter all fields!");
                //simple return function as we dont want the rest of the code to continue
                return;
            }

            // if both useername and email are not empty and are equal to values in the database it does the following commands
            if (result != null || emailResult != null)
            {

                //if the user name and email is null then set them to red
                if (result != null && emailResult != null)
                {
                    Username.BackColor = Color.LightCoral;
                    EmailBox.BackColor = Color.LightCoral;

                    MessageBox.Show("This Username & Email already exist!");
                }
                //if the username is null set the email to green but the username to red
                else if (result != null)
                {
                    EmailBox.BackColor = Color.LightGreen;
                    Username.BackColor = Color.LightCoral;
                    MessageBox.Show("This Username already exist!");
                }
                //if the email is null set the email to red and the username to green
                else if (emailResult != null)
                {
                    EmailBox.BackColor = Color.LightCoral;
                    Username.BackColor = Color.LightGreen;
                    MessageBox.Show("This Email already exist!");

                }

                //close connection to database
                con.Close();
            }
            //if no duplicates are found it will move on to adding the data to the database
            else
            {
                // creates a new connection 
                {
             
                    //creates the new command to insert values into the database but uses values for neater code
                    Random rnd = new Random();
                    int ID = rnd.Next(2000, 4000);
                    int Employeeid = ID;

                    //SAME AS REGISTER PAGE
                    SqlCommand EmployeeCheck = new SqlCommand("SELECT * from Employees where EmployeeID='" + Employeeid + "'", con);
                    SqlCommand cmd = new SqlCommand("insert into Employees (EmployeeID, FirstName, LastName, DOB, Address, Salary, Department, JobTitle, Role, Email, UserID, Password) " + " values(@EmployeeID, @FirstName, @LastName, @DOB, @Address, @Salary, @Department, @JobTitle, @Role, @Email, @UserID, @Password)", con);

                    SqlDataAdapter da = new SqlDataAdapter(EmployeeCheck);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = ds.Tables[0].Rows.Count;
                    if (i > 0)
                    {

                        MessageBox.Show(i.ToString());

                        //create a new id
                        int newID = rnd.Next(2000, 10000);
                        cmd.Parameters.AddWithValue("@EmployeeID", newID);
                        cmd.Parameters.AddWithValue("@FirstName", FirstNameBox.Text);
                        cmd.Parameters.AddWithValue("@LastName", LastNameBox.Text);
                        cmd.Parameters.AddWithValue("@DOB", DOBpicker.Text);
                        cmd.Parameters.AddWithValue("@Address", Address.Text);
                        //sets the salary value to the variable based on which role is selected
                        // CLEAN UP ALL IFS STATEMENTS
                        if (RoleBox.GetItemText(RoleBox.SelectedItem) == "Manager")
                        {
                            cmd.Parameters.AddWithValue("@Salary", Manager);
                        }
                        else if (RoleBox.GetItemText(RoleBox.SelectedItem) == "Engineer")
                        {
                            cmd.Parameters.AddWithValue("@Salary", Engineer);
                        }
                        else if (RoleBox.GetItemText(RoleBox.SelectedItem) == "Team Leader")
                        {
                            cmd.Parameters.AddWithValue("@Salary", TeamLeader);
                        }
                        else if (RoleBox.GetItemText(RoleBox.SelectedItem) == "Engineer Scheduler")
                        {
                            cmd.Parameters.AddWithValue("@Salary", EngineerScheduler);
                        }
                        else if (RoleBox.GetItemText(RoleBox.SelectedItem) == "Senior Developer")
                        {
                            cmd.Parameters.AddWithValue("@Salary", SeniorDevelopment);
                        }
                        else if (RoleBox.GetItemText(RoleBox.SelectedItem) == "Programmer")
                        {
                            cmd.Parameters.AddWithValue("@Salary", Programmer);
                        }
                        else if (RoleBox.GetItemText(RoleBox.SelectedItem) == "Anaylst")
                        {
                            cmd.Parameters.AddWithValue("@Salary", Anaylst);
                        }
                        cmd.Parameters.AddWithValue("@Department", DepartmentBox.GetItemText(DepartmentBox.SelectedItem));
                        cmd.Parameters.AddWithValue("@JobTitle", JobTitleBox.Text);
                        cmd.Parameters.AddWithValue("@Role", RoleBox.GetItemText(RoleBox.SelectedItem));
                        cmd.Parameters.AddWithValue("@Email", EmailBox.Text);
                        cmd.Parameters.AddWithValue("@UserID", Username.Text);
                        decryptedPassword = Password.Text;
                        //adds the password as normal but adds it as an encrypted value
                        cmd.Parameters.AddWithValue("@Password", PasswordLogin.encryptPassword(Password.Text.Trim()));
                        //passing id     
                        cmd.ExecuteNonQuery();

                        //shows a succesful message 
                        MessageBox.Show("Succesfully Registerd!");

                        FirstNameBox.Clear();
                        LastNameBox.Clear();
                        JobTitleBox.Clear();
                        EmailBox.Clear();
                        Username.Clear();
                        Password.Clear();
                        Address.Clear();
                        DOBpicker.ResetText();
                        RoleBox.ResetText();
                        DepartmentBox.ResetText();


                    }
                    else
                    {

                        cmd.Parameters.AddWithValue("@EmployeeID", Employeeid);
                        cmd.Parameters.AddWithValue("@FirstName", FirstNameBox.Text);
                        cmd.Parameters.AddWithValue("@LastName", LastNameBox.Text);
                        cmd.Parameters.AddWithValue("@DOB", DOBpicker.Text);
                        cmd.Parameters.AddWithValue("@Address", Address.Text);
                        //sets the salary value to the variable based on which role is selected
                        // CLEAN UP ALL IFS STATEMENTS
                        if (RoleBox.GetItemText(RoleBox.SelectedItem) == "Manager")
                        {
                            cmd.Parameters.AddWithValue("@Salary", Manager);
                        }
                        else if (RoleBox.GetItemText(RoleBox.SelectedItem) == "Engineer")
                        {
                            cmd.Parameters.AddWithValue("@Salary", Engineer);
                        }
                        else if (RoleBox.GetItemText(RoleBox.SelectedItem) == "Team Leader")
                        {
                            cmd.Parameters.AddWithValue("@Salary", TeamLeader);
                        }
                        else if (RoleBox.GetItemText(RoleBox.SelectedItem) == "Engineer Scheduler")
                        {
                            cmd.Parameters.AddWithValue("@Salary", EngineerScheduler);
                        }
                        else if (RoleBox.GetItemText(RoleBox.SelectedItem) == "Senior Developer")
                        {
                            cmd.Parameters.AddWithValue("@Salary", SeniorDevelopment);
                        }
                        else if (RoleBox.GetItemText(RoleBox.SelectedItem) == "Programmer")
                        {
                            cmd.Parameters.AddWithValue("@Salary", Programmer);
                        }
                        else if (RoleBox.GetItemText(RoleBox.SelectedItem) == "Anaylst")
                        {
                            cmd.Parameters.AddWithValue("@Salary", Anaylst);
                        }
                        cmd.Parameters.AddWithValue("@Department", DepartmentBox.GetItemText(DepartmentBox.SelectedItem));
                        cmd.Parameters.AddWithValue("@JobTitle", JobTitleBox.Text);
                        cmd.Parameters.AddWithValue("@Role", RoleBox.GetItemText(RoleBox.SelectedItem));
                        cmd.Parameters.AddWithValue("@Email", EmailBox.Text);
                        cmd.Parameters.AddWithValue("@UserID", Username.Text);
                        decryptedPassword = Password.Text;
                        //adds the password as normal but adds it as an encrypted value
                        cmd.Parameters.AddWithValue("@Password", PasswordLogin.encryptPassword(Password.Text.Trim()));
                        cmd.ExecuteNonQuery();
                        //closes connection
                        con.Close();

                        //shows a succesful message 
                        MessageBox.Show("Succesfully Registerd!");

                        FirstNameBox.Clear();
                        LastNameBox.Clear();
                        JobTitleBox.Clear();
                        EmailBox.Clear();
                        Username.Clear();
                        Password.Clear();
                        Address.Clear();
                        DOBpicker.ResetText();
                        RoleBox.ResetText();
                        DepartmentBox.ResetText();


                    }
                }
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //creating the delete command
            SqlCommand delcmd = new SqlCommand();

            //checking to see if a row is selected
            if (dataGridView4.Rows.Count > 0)
            {
                //fixed an error here istead of searching datagrideview1.Rows.Count I searched through the selectedrows this stopped the execption error.
                if (dataGridView4.SelectedRows.Count > 0 && dataGridView4.SelectedRows[0].Index != dataGridView4.Rows.Count - 0)
                {
                    //creating and establishing the connection
                    var connectionString = ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    //deletes the selected row data from the database and the datagridview
                    delcmd.CommandText = "DELETE FROM Employees WHERE EmployeeID=" + dataGridView4.SelectedRows[0].Cells[0].Value.ToString() + "";
                    //setting the command connection to be the correct connection
                    delcmd.Connection = con;
                    //excutes the sql
                    delcmd.ExecuteNonQuery();
                    //close the connection do the database
                    con.Close();
                    //deletes the row from the datagridview
                    dataGridView4.Rows.RemoveAt(dataGridView4.SelectedRows[0].Index);
                }
                else
                {
                    //if no row is selected then spit out this error message
                    MessageBox.Show("Please select a row");
                }
            }
        }

        private void DeleteTask_Click(object sender, EventArgs e)
        {
            //creating the delete command
            SqlCommand delcmd = new SqlCommand();

            //checking to see if a row is selected
            if (tasksDataGrid.Rows.Count > 0)
            {
                //fixed an error here istead of searching datagrideview1.Rows.Count I searched through the selectedrows this stopped the execption error.
                if (tasksDataGrid.SelectedRows.Count > 0 && tasksDataGrid.SelectedRows[0].Index != tasksDataGrid.Rows.Count - 1)
                {
                    //creating and establishing the connection
                    var connectionString = ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    //deletes the selected row data from the database and the datagridview
                    delcmd.CommandText = "DELETE FROM TaskSchedule WHERE TaskID=" + tasksDataGrid.SelectedRows[0].Cells[0].Value.ToString() + "";
                    delcmd.Connection = con;
                    delcmd.ExecuteNonQuery();
                    //close the connection do the database
                    con.Close();
                    //deletes the row from the datagridview
                    tasksDataGrid.Rows.RemoveAt(tasksDataGrid.SelectedRows[0].Index);
                }
                else
                {
                    //if no row is selected then spit out this error message
                    MessageBox.Show("Please select a row");
                }
            }
        }

        private void SearchUser_Click(object sender, EventArgs e)
        {
            //opens the connection 
            var connectionString = ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            //checks to see if the search box is populated if not then show all employees
            if (AdminSearch.Text == "")
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
                dataGridView4.DataSource = dta;
                con.Close();
                //refreshing the dgv
                dataGridView4.Refresh();
            }
            else
            {
                //opens connection
                con.Open();
                //selected everything from the dgv where the first name is equal to whats in the txtbox
                SqlDataAdapter search = new SqlDataAdapter("select * from Employees where FirstName like '" + AdminSearch.Text + "%'", con);
                DataTable dt = new DataTable();
                search.Fill(dt);
                dataGridView4.DataSource = dt;
                con.Close();

                AdminSearch.Clear();
            }

        }

        private void addTask_Click(object sender, EventArgs e)
        {
            //checks to see if the textboxes are populated
            if (Subject.Text == "" || StartDate.Text == "" || DueDate.Text == "" || TaskDescription.Text == "")
            {
                //error message
                MessageBox.Show("Please Enter The fields");
                //returns 
                return;
            }

            //creating and establishing the connection
            var connectionString = ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);



            SqlCommand checkTaskID = new SqlCommand("Select * from TaskSchedule where TaskID=@ID", con);
            //check task id
            checkTaskID.Parameters.AddWithValue("ID", TaskID);
            con.Open();
            var idCheck = checkTaskID.ExecuteScalar();

            if (idCheck != null)
            {
                //back up id incase it is matched against the database ID
                Random rnd = new Random();
                int newID = rnd.Next(1, 1000);

                SqlCommand add = con.CreateCommand();
                add.CommandType = CommandType.Text;
                //inserting the new task into the dgv and database table
                add.CommandText = "insert into TaskSchedule values ('" + newID + "','" + Subject.Text + "','" + StartDate.Text + "','" + DueDate.Text + "','" + TaskDescription.Text + "')";
                add.ExecuteNonQuery();


                MessageBox.Show("Succesfully Added");

                SqlCommand Tcmd = con.CreateCommand();
                Tcmd.CommandType = CommandType.Text;
                Tcmd.CommandText = "select * from TaskSchedule";
                Tcmd.ExecuteNonQuery();
                DataTable dta = new DataTable();
                SqlDataAdapter adapt = new SqlDataAdapter(Tcmd);
                adapt.Fill(dta);
                tasksDataGrid.DataSource = dta;
                con.Close();

                tasksDataGrid.Refresh();

            }
            else if (idCheck == null)
            {

                //TO DO: Task updates 
                //add task
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into TaskSchedule values ('" + TaskID + "','" + Subject.Text + "','" + StartDate.Text + "','" + DueDate.Text + "','" + TaskDescription.Text + "')";
                cmd.ExecuteNonQuery();


                MessageBox.Show("Succesfully Added");

                SqlCommand Tcmd = con.CreateCommand();
                Tcmd.CommandType = CommandType.Text;
                Tcmd.CommandText = "select * from TaskSchedule";
                Tcmd.ExecuteNonQuery();
                DataTable dta = new DataTable();
                SqlDataAdapter adapt = new SqlDataAdapter(Tcmd);
                adapt.Fill(dta);
                tasksDataGrid.DataSource = dta;
                con.Close();

                tasksDataGrid.Refresh();

            }

        }

        private void Dash_Click(object sender, EventArgs e)
        {
            //[CONNECTION STRINGS]
            var connectionString = ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            //Update all relevant dgvs 
            con.Open();
            SqlCommand HolidayData = con.CreateCommand();
            HolidayData.CommandType = CommandType.Text;
            HolidayData.CommandText = "select * from HolidayLeave";
            HolidayData.ExecuteNonQuery();
            DataTable HolidayDataTable = new DataTable();
            SqlDataAdapter HolidayDataAdapter = new SqlDataAdapter(HolidayData);
            HolidayDataAdapter.Fill(HolidayDataTable);
            DashHolidayData.DataSource = HolidayDataTable;
            con.Close();

            DashHolidayData.Refresh();

            con.Open();
            SqlCommand Taskcmd = con.CreateCommand();
            Taskcmd.CommandType = CommandType.Text;
            Taskcmd.CommandText = "select * from TaskSchedule";
            Taskcmd.ExecuteNonQuery();
            DataTable dataTask = new DataTable();
            SqlDataAdapter tasksAdapt = new SqlDataAdapter(Taskcmd);
            tasksAdapt.Fill(dataTask);
            DashTaskDataGrid.DataSource = dataTask;
            con.Close();

            DashTaskDataGrid.Refresh();

            con.Open();
            SqlCommand ListOfUsers = con.CreateCommand();
            ListOfUsers.CommandType = CommandType.Text;
            ListOfUsers.CommandText = "select * from Employees";
            ListOfUsers.ExecuteNonQuery();
            DataTable employeeTask = new DataTable();
            SqlDataAdapter usersAdapt = new SqlDataAdapter(ListOfUsers);
            usersAdapt.Fill(employeeTask);
            dataGridView1.DataSource = employeeTask;
            con.Close();

            dataGridView1.Refresh();


            Dashboard.Visible = true;
            AddPanel.Visible = false;
            tasksPanel.Visible = false;
            ListOfUsersPanel.Visible = false;
            holidayListPanel.Visible = false;
        }

        private void addEmployee_Click(object sender, EventArgs e)
        {
            AddPanel.Visible = true;
            Dashboard.Visible = false;
            tasksPanel.Visible = false;
            ListOfUsersPanel.Visible = false;
            holidayListPanel.Visible = false;
        }

        private void tasks_Click(object sender, EventArgs e)
        {

            tasksPanel.Visible = true;
            AddPanel.Visible = false;
            Dashboard.Visible = false;
            ListOfUsersPanel.Visible = false;
            holidayListPanel.Visible = false;

            var connectionString = ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            SqlCommand Taskcmd = con.CreateCommand();
            Taskcmd.CommandType = CommandType.Text;
            Taskcmd.CommandText = "select * from TaskSchedule";
            Taskcmd.ExecuteNonQuery();
            DataTable dataTask = new DataTable();
            SqlDataAdapter tasksAdapt = new SqlDataAdapter(Taskcmd);
            tasksAdapt.Fill(dataTask);
            tasksDataGrid.DataSource = dataTask;
            con.Close();

            tasksDataGrid.Refresh();

        }

        private void listOfuser_Click(object sender, EventArgs e)
        {

            var connectionString = ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            //TOOO: clean up all button presses and create a specific class to update all datagrid views for functionality
            con.Open();
            SqlCommand Tcmd = con.CreateCommand();
            Tcmd.CommandType = CommandType.Text;
            Tcmd.CommandText = "select * from Employees";
            Tcmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter(Tcmd);
            adapt.Fill(dta);
            dataGridView4.DataSource = dta;
            con.Close();

            dataGridView4.Refresh();

            ListOfUsersPanel.Visible = true;
            Dashboard.Visible = false;
            AddPanel.Visible = false;
            tasksPanel.Visible = false;
            holidayListPanel.Visible = false;

        }

        private void HolidayList_Click(object sender, EventArgs e)
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
            holidayListPanel.Visible = true;
            Dashboard.Visible = false;
            AddPanel.Visible = false;
            tasksPanel.Visible = false;
            ListOfUsersPanel.Visible = false;

            //creating a loop for all the rows in the dgv for holiday leave
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                //getting the value of cell 5 which would be the approved status either approved or disapproved
                string val = dataGridView2.Rows[i].Cells[5].Value.ToString();
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

        private void button7_Click(object sender, EventArgs e)
        {
            //Dissaprove button click

            //set approved = true if the button is pressed 
            approved = true;

            //[CONNECTION STRINGS]
            var connectionString = ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            //set currentID = the current selected row
            string currentID = dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[0].Value.ToString();

            //set now approved to = "Approved" so we can populate the field required
            string nowApproved = "Approved";
            //creates a new CMD Command
            SqlCommand cmd = new SqlCommand();
            //CMD text 
            cmd.CommandText = "Update HolidayLeave Set Approved=@Approved where EmployeeID='" + currentID + "'";
            con.Open();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Approved", nowApproved);
            cmd.ExecuteNonQuery();
            con.Close();

            //SAME AS DISSAPROVED
            if (dataGridView2.SelectedRows.Count > 0 && dataGridView2.SelectedRows[0].Index != dataGridView2.Rows.Count - 0)
            {         
                foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                {
                    dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[5].Value = nowApproved;

                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }

                    if (approved == true)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        Properties.Settings.Default.DGVColourGreen = row.DefaultCellStyle.BackColor;
                        Settings.Default.Save();

                        approved = false;
                    }
                    else
                    {
                        return;
                    }

                }
            }
            else
            {
                if (dataGridView2.Rows.Count >= 1)
                {
                    MessageBox.Show("Please Select A Row");
                }
            }
        }
    

        private void button8_Click(object sender, EventArgs e)
        {
            //Dissaprove button click
            //set the disapproved button to true if the button is pressed
            disApproved = true;

            //[CONNECTION STRINGS]
            var connectionString = ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            //set the currentID equal to the select row of the user
            string currentID = dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[0].Value.ToString();

            //set notApproved string = to The word Disapproved so we can populate the field
            string notApproved = "Disapproved";
            //Create a new sql command
            SqlCommand cmd = new SqlCommand();
            //setting the command to update the holidayleave table where the employee is equal to the users ID
            cmd.CommandText = "Update HolidayLeave Set Approved=@Approved where EmployeeID='" + currentID + "'";
            //open the connection to the database
            con.Open();
            // set the command connection to the connection to the database
            cmd.Connection = con;
            //add disapproved to the field within the database 
            cmd.Parameters.AddWithValue("@Approved", notApproved);
            //excute the command
            cmd.ExecuteNonQuery();
            //close the connection
            con.Close();

            //if a row is selected continue into the loop
            if (dataGridView2.SelectedRows.Count > 0 && dataGridView2.SelectedRows[0].Index != dataGridView2.Rows.Count - 0)
            {
                /*this allows me to search though each individual row within the selcted row 
                for example if i select the first row thats thew onky row within SelectedRows*/
                foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                {
                    //set the appropriate value in this case disapproved to the correct field so no refresh is required
                    dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[5].Value = notApproved;

                    //if the button has been clicked and all critera is met the continue into the if statment
                    if (disApproved == true)
                    {
                        //set the approprite colour to the row
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                        //save the colour
                        Properties.Settings.Default.DGVColourRed = row.DefaultCellStyle.BackColor;
                        Settings.Default.Save();
                        
                        //then set disapproved = to false
                        disApproved = false;
                    }
                    else
                    {
                        //if the loop is broken for some reason just return
                        return;
                    }
                    
                }
            }
            else 
            {
                //if no row is selected continue into the loop
                if (dataGridView2.Rows.Count >= 1)
                {
                    //error message
                    MessageBox.Show("Please Select A Row");
                }
            }

        }

        private void DeleteRequest_Click(object sender, EventArgs e)
        {
            //creating the delete command
            SqlCommand delcmd = new SqlCommand();

            //checking to see if a row is selected
            if (dataGridView2.Rows.Count > 0)
            {
                //fixed an error here istead of searching datagrideview1.Rows.Count I searched through the selectedrows this stopped the execption error.
                if (dataGridView2.SelectedRows.Count > 0 && dataGridView2.SelectedRows[0].Index != dataGridView2.Rows.Count - 0)
                {
                    //creating and establishing the connection
                    var connectionString = ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    //deletes the selected row data from the database and the datagridview
                    delcmd.CommandText = "DELETE FROM HolidayLeave WHERE EmployeeID=" + dataGridView2.SelectedRows[0].Cells[0].Value.ToString() + "";
                    delcmd.Connection = con;
                    delcmd.ExecuteNonQuery();
                    //close the connection do the database
                    con.Close();
                    //deletes the row from the datagridview
                    dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index);
                }
                else
                {
                    //if no row is selected then spit out this error message
                    MessageBox.Show("Please select a row");
                }
            }
        }

        private void PanelTop_MouseDown(object sender, MouseEventArgs e)
        {
            //if the mouse is pressed down then set the mouseDown variable to true      
            mouseDown = true;
            //set the last location equal to the mouse event e locationt
            lastLocation = e.Location;
        }

        private void PanelTop_MouseUp(object sender, MouseEventArgs e)
        {
            //if the mouse button is lifted then set the mousedown position to false
            mouseDown = false;
        }

        private void PanelTop_MouseMove(object sender, MouseEventArgs e)
        {
            //basic movement of the program script 
            if (mouseDown)
            {
                //if the mouse is down then get the location of the mouse position
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                //update the location if the mouse is moved
                this.Update();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //exit application if exit label is pressed
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            //minimise the program if the minimise label is pressed
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //sign out button
            this.Hide();
            Form1 x = new Form1();
            x.Show();
        }
    }
}