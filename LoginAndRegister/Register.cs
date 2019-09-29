using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.Timers;


namespace ZonalProject
{
    public partial class Register : Form
    {

        //salary sets
        public int Manager = 75000;
        public int Engineer = 40000;
        public int TeamLeader = 75000;
        public int EngineerScheduler = 25000;
        public int SeniorDevelopment = 55000;
        public int Programmer = 30000;
        public int Anaylst = 17000;
     
        //part of decryption see class
        public static string decryptedPassword = "";

        //create the animation timer
        System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();

        public Register()
        {
            InitializeComponent();
        }

        //fade in function
        void fadeIn(object sender, EventArgs e)
        {
            //if the opactiy is full the carry on
            if (Opacity >= 1)
            {
                //stop timer
                t1.Stop();
            }
            else
            {
                //increase the opacity
                Opacity += 0.05;
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {
            //set opacity to 0
            Opacity = 0;
            //intervarl is 15ms
            t1.Interval = 15;
            //tick based on the fade in function
            t1.Tick += new EventHandler(fadeIn);
            //start timer
            t1.Start();

            // TODO: This line of code loads data into the 'rolesTableData.Roles' table. You can move, or remove it, as needed.
            this.rolesTableAdapter.Fill(this.rolesTableData.Roles);
            // TODO: This line of code loads data into the 'departmentTableData.Departments' table. You can move, or remove it, as needed.
            this.departmentsTableAdapter.Fill(this.departmentTableData.Departments);

        }

        private void RegisterButton_Click_1(object sender, EventArgs e)
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
            checkUserName.Parameters.AddWithValue("@Username", this.UsernameBox.Text);
            // same checks for the user id the only diffrence is its the email
            checkEmail.Parameters.AddWithValue("@Email", this.EmailBox.Text);
            var result = checkUserName.ExecuteScalar();
            var emailResult = checkEmail.ExecuteScalar();

            //checks to see if any textboxes are empty if so then it carrys on
            if (FirstNameBox.Text == "" || LastNameBox.Text == "" || DOBpicker.Text == "" || AddressBox.Text == "" || JobTitleBox.Text == "" || EmailBox.Text == "" || UsernameBox.Text == "" || PasswordBox.Text == "")
            {
                // if a empty a message box shows to ask to enter all fields
                MessageBox.Show("Please enter all fields!");
                //simple return function as we dont want the rest of the code to continue
                return;
            }

            // if both useername and email are not empty and are equal to values in the database it does the following commands
            if (result != null || emailResult != null)
            {


                if (result != null && emailResult != null)
                {
                    UsernameBox.BackColor = Color.LightCoral;
                    EmailBox.BackColor = Color.LightCoral;

                    MessageBox.Show("This Username & Email already exist!");
                }
                else if (result != null)
                {
                    EmailBox.BackColor = Color.LightGreen;
                    UsernameBox.BackColor = Color.LightCoral;
                    MessageBox.Show("This Username already exist!");
                }
                else if (emailResult != null)
                {
                    EmailBox.BackColor = Color.LightCoral;
                    UsernameBox.BackColor = Color.LightGreen;
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
                    //creates a new random number
                    Random rnd = new Random();
                    int ID = rnd.Next(2000, 4000);
                    int Employeeid = ID;

                    //creates two commands one for inserting values into a database and another to check if an id exists
                    SqlCommand EmployeeCheck = new SqlCommand("SELECT * from Employees where EmployeeID='"+Employeeid+"'", con);
                    SqlCommand cmd = new SqlCommand("insert into Employees (EmployeeID, FirstName, LastName, DOB, Address, Salary, Department, JobTitle, Role, Email, UserID, Password) " + " values(@EmployeeID, @FirstName, @LastName, @DOB, @Address, @Salary, @Department, @JobTitle, @Role, @Email, @UserID, @Password)", con);

                    //creates a new adapter so we can check if the id exists or not
                    SqlDataAdapter da = new SqlDataAdapter(EmployeeCheck);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = ds.Tables[0].Rows.Count;
                    //if the id exists continue 
                    if (i > 0)
                    {

                        MessageBox.Show(i.ToString());
                    
                        //create a new id
                        int newID = rnd.Next(2000, 10000);
                        cmd.Parameters.AddWithValue("@EmployeeID", newID);
                        cmd.Parameters.AddWithValue("@FirstName", FirstNameBox.Text);
                        cmd.Parameters.AddWithValue("@LastName", LastNameBox.Text);
                        cmd.Parameters.AddWithValue("@DOB", DOBpicker.Text);
                        cmd.Parameters.AddWithValue("@Address", AddressBox.Text);
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
                        cmd.Parameters.AddWithValue("@UserID", UsernameBox.Text);
                        decryptedPassword = PasswordBox.Text;
                        //adds the password as normal but adds it as an encrypted value
                        cmd.Parameters.AddWithValue("@Password", PasswordLogin.encryptPassword(PasswordBox.Text.Trim()));
                        //passing id     
                        cmd.ExecuteNonQuery();

                        //shows a succesful message 
                        MessageBox.Show("Succesfully Registerd!");

                        //closes the form and opens the login screen
                        this.Close();
                        Form1 x = new Form1();
                        x.Show();
                        
                    }
                    else
                    {

                        cmd.Parameters.AddWithValue("@EmployeeID", Employeeid);
                        cmd.Parameters.AddWithValue("@FirstName", FirstNameBox.Text);
                        cmd.Parameters.AddWithValue("@LastName", LastNameBox.Text);
                        cmd.Parameters.AddWithValue("@DOB", DOBpicker.Text);
                        cmd.Parameters.AddWithValue("@Address", AddressBox.Text);
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
                        cmd.Parameters.AddWithValue("@UserID", UsernameBox.Text);
                        decryptedPassword = PasswordBox.Text;
                        //adds the password as normal but adds it as an encrypted value
                        cmd.Parameters.AddWithValue("@Password", PasswordLogin.encryptPassword(PasswordBox.Text.Trim()));
                        cmd.ExecuteNonQuery();
                        //closes connection
                        con.Close();

                        //shows a succesful message 
                        MessageBox.Show("Succesfully Registerd!");

                        //closes the form and opens the login screen
                        this.Close();
                        Form1 x = new Form1();
                        x.Show();

                    }                                  
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 x = new Form1();
            x.Show();

        }

        private void PanelLeft_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
