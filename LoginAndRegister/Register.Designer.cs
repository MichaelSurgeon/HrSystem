namespace ZonalProject
{
    partial class Register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.rolesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rolesTableData = new ZonalProject.DataSets.RolesTableData();
            this.departmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.departmentTableData = new ZonalProject.DataSets.DepartmentTableData();
            this.departmentsTableAdapter = new ZonalProject.DataSets.DepartmentTableDataTableAdapters.DepartmentsTableAdapter();
            this.rolesTableAdapter = new ZonalProject.DataSets.RolesTableDataTableAdapters.RolesTableAdapter();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PanelTop = new System.Windows.Forms.Panel();
            this.PanelLeft = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PanelRight = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.DOBpicker = new System.Windows.Forms.DateTimePicker();
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.JobTitleBox = new System.Windows.Forms.TextBox();
            this.EmailBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.RoleBox = new System.Windows.Forms.ComboBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.DepartmentBox = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.AddressBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LastNameBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.FirstNameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rolesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolesTableData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentTableData)).BeginInit();
            this.PanelTop.SuspendLayout();
            this.PanelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PanelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // rolesBindingSource
            // 
            this.rolesBindingSource.DataMember = "Roles";
            this.rolesBindingSource.DataSource = this.rolesTableData;
            // 
            // rolesTableData
            // 
            this.rolesTableData.DataSetName = "RolesTableData";
            this.rolesTableData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // departmentsBindingSource
            // 
            this.departmentsBindingSource.DataMember = "Departments";
            this.departmentsBindingSource.DataSource = this.departmentTableData;
            // 
            // departmentTableData
            // 
            this.departmentTableData.DataSetName = "DepartmentTableData";
            this.departmentTableData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // departmentsTableAdapter
            // 
            this.departmentsTableAdapter.ClearBeforeFill = true;
            // 
            // rolesTableAdapter
            // 
            this.rolesTableAdapter.ClearBeforeFill = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(764, -15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 34);
            this.label5.TabIndex = 0;
            this.label5.Text = "\r\n-\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(783, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "X";
            // 
            // PanelTop
            // 
            this.PanelTop.BackColor = System.Drawing.Color.Coral;
            this.PanelTop.Controls.Add(this.label5);
            this.PanelTop.Controls.Add(this.label1);
            this.PanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTop.Location = new System.Drawing.Point(0, 0);
            this.PanelTop.Name = "PanelTop";
            this.PanelTop.Size = new System.Drawing.Size(803, 22);
            this.PanelTop.TabIndex = 0;
            // 
            // PanelLeft
            // 
            this.PanelLeft.BackColor = System.Drawing.Color.Coral;
            this.PanelLeft.Controls.Add(this.pictureBox1);
            this.PanelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelLeft.Location = new System.Drawing.Point(0, 22);
            this.PanelLeft.Name = "PanelLeft";
            this.PanelLeft.Size = new System.Drawing.Size(210, 488);
            this.PanelLeft.TabIndex = 0;
            this.PanelLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelLeft_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 310);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // PanelRight
            // 
            this.PanelRight.Controls.Add(this.button1);
            this.PanelRight.Controls.Add(this.panel10);
            this.PanelRight.Controls.Add(this.PasswordBox);
            this.PanelRight.Controls.Add(this.label13);
            this.PanelRight.Controls.Add(this.panel9);
            this.PanelRight.Controls.Add(this.DOBpicker);
            this.PanelRight.Controls.Add(this.UsernameBox);
            this.PanelRight.Controls.Add(this.label12);
            this.PanelRight.Controls.Add(this.panel8);
            this.PanelRight.Controls.Add(this.panel7);
            this.PanelRight.Controls.Add(this.label6);
            this.PanelRight.Controls.Add(this.JobTitleBox);
            this.PanelRight.Controls.Add(this.EmailBox);
            this.PanelRight.Controls.Add(this.label11);
            this.PanelRight.Controls.Add(this.label10);
            this.PanelRight.Controls.Add(this.RoleBox);
            this.PanelRight.Controls.Add(this.panel6);
            this.PanelRight.Controls.Add(this.DepartmentBox);
            this.PanelRight.Controls.Add(this.panel5);
            this.PanelRight.Controls.Add(this.label9);
            this.PanelRight.Controls.Add(this.label8);
            this.PanelRight.Controls.Add(this.panel4);
            this.PanelRight.Controls.Add(this.AddressBox);
            this.PanelRight.Controls.Add(this.label7);
            this.PanelRight.Controls.Add(this.RegisterButton);
            this.PanelRight.Controls.Add(this.panel2);
            this.PanelRight.Controls.Add(this.LastNameBox);
            this.PanelRight.Controls.Add(this.panel1);
            this.PanelRight.Controls.Add(this.label4);
            this.PanelRight.Controls.Add(this.FirstNameBox);
            this.PanelRight.Controls.Add(this.label3);
            this.PanelRight.Controls.Add(this.label2);
            this.PanelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanelRight.Location = new System.Drawing.Point(216, 22);
            this.PanelRight.Name = "PanelRight";
            this.PanelRight.Size = new System.Drawing.Size(587, 488);
            this.PanelRight.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Coral;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(287, 432);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(243, 32);
            this.button1.TabIndex = 120;
            this.button1.Text = "Go Back!";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Coral;
            this.panel10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel10.Location = new System.Drawing.Point(290, 399);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(240, 1);
            this.panel10.TabIndex = 25;
            // 
            // PasswordBox
            // 
            this.PasswordBox.BackColor = System.Drawing.SystemColors.Control;
            this.PasswordBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordBox.Location = new System.Drawing.Point(290, 377);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '•';
            this.PasswordBox.Size = new System.Drawing.Size(240, 15);
            this.PasswordBox.TabIndex = 100;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Coral;
            this.label13.Location = new System.Drawing.Point(286, 352);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 24);
            this.label13.TabIndex = 23;
            this.label13.Text = "Password";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Coral;
            this.panel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel9.Location = new System.Drawing.Point(21, 399);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(240, 1);
            this.panel9.TabIndex = 16;
            // 
            // DOBpicker
            // 
            this.DOBpicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DOBpicker.Location = new System.Drawing.Point(20, 245);
            this.DOBpicker.MaxDate = new System.DateTime(2002, 12, 31, 0, 0, 0, 0);
            this.DOBpicker.Name = "DOBpicker";
            this.DOBpicker.Size = new System.Drawing.Size(240, 20);
            this.DOBpicker.TabIndex = 5;
            this.DOBpicker.Value = new System.DateTime(2002, 12, 31, 0, 0, 0, 0);
            // 
            // UsernameBox
            // 
            this.UsernameBox.BackColor = System.Drawing.SystemColors.Control;
            this.UsernameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UsernameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameBox.Location = new System.Drawing.Point(21, 377);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(239, 15);
            this.UsernameBox.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Coral;
            this.label12.Location = new System.Drawing.Point(17, 352);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 24);
            this.label12.TabIndex = 14;
            this.label12.Text = "Username";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Coral;
            this.panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel8.Location = new System.Drawing.Point(290, 333);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(240, 1);
            this.panel8.TabIndex = 16;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Coral;
            this.panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel7.Location = new System.Drawing.Point(290, 265);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(240, 1);
            this.panel7.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Coral;
            this.label6.Location = new System.Drawing.Point(17, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 24);
            this.label6.TabIndex = 17;
            this.label6.Text = "Date Of Birth";
            // 
            // JobTitleBox
            // 
            this.JobTitleBox.BackColor = System.Drawing.SystemColors.Control;
            this.JobTitleBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.JobTitleBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JobTitleBox.Location = new System.Drawing.Point(290, 311);
            this.JobTitleBox.Name = "JobTitleBox";
            this.JobTitleBox.Size = new System.Drawing.Size(240, 15);
            this.JobTitleBox.TabIndex = 8;
            // 
            // EmailBox
            // 
            this.EmailBox.BackColor = System.Drawing.SystemColors.Control;
            this.EmailBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EmailBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailBox.Location = new System.Drawing.Point(290, 243);
            this.EmailBox.Name = "EmailBox";
            this.EmailBox.Size = new System.Drawing.Size(240, 15);
            this.EmailBox.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Coral;
            this.label11.Location = new System.Drawing.Point(286, 286);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 24);
            this.label11.TabIndex = 14;
            this.label11.Text = "Job Title";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Coral;
            this.label10.Location = new System.Drawing.Point(286, 218);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 24);
            this.label10.TabIndex = 19;
            this.label10.Text = "Email";
            // 
            // RoleBox
            // 
            this.RoleBox.BackColor = System.Drawing.Color.White;
            this.RoleBox.DataSource = this.rolesBindingSource;
            this.RoleBox.DisplayMember = "Role Name";
            this.RoleBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RoleBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoleBox.ForeColor = System.Drawing.Color.Black;
            this.RoleBox.FormattingEnabled = true;
            this.RoleBox.Location = new System.Drawing.Point(290, 175);
            this.RoleBox.Name = "RoleBox";
            this.RoleBox.Size = new System.Drawing.Size(240, 21);
            this.RoleBox.TabIndex = 4;
            this.RoleBox.ValueMember = "Role Name";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.IndianRed;
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel6.Location = new System.Drawing.Point(290, 198);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(240, 1);
            this.panel6.TabIndex = 9;
            // 
            // DepartmentBox
            // 
            this.DepartmentBox.BackColor = System.Drawing.Color.White;
            this.DepartmentBox.DataSource = this.departmentsBindingSource;
            this.DepartmentBox.DisplayMember = "Department Name";
            this.DepartmentBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DepartmentBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepartmentBox.ForeColor = System.Drawing.Color.Black;
            this.DepartmentBox.FormattingEnabled = true;
            this.DepartmentBox.Location = new System.Drawing.Point(20, 176);
            this.DepartmentBox.Name = "DepartmentBox";
            this.DepartmentBox.Size = new System.Drawing.Size(240, 21);
            this.DepartmentBox.TabIndex = 3;
            this.DepartmentBox.ValueMember = "Department Name";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.IndianRed;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel5.Location = new System.Drawing.Point(20, 199);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(240, 1);
            this.panel5.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Coral;
            this.label9.Location = new System.Drawing.Point(286, 151);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 24);
            this.label9.TabIndex = 7;
            this.label9.Text = "Role";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Coral;
            this.label8.Location = new System.Drawing.Point(16, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 24);
            this.label8.TabIndex = 14;
            this.label8.Text = "Department";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Coral;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel4.Location = new System.Drawing.Point(20, 333);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 1);
            this.panel4.TabIndex = 13;
            // 
            // AddressBox
            // 
            this.AddressBox.BackColor = System.Drawing.SystemColors.Control;
            this.AddressBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AddressBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddressBox.Location = new System.Drawing.Point(20, 311);
            this.AddressBox.Name = "AddressBox";
            this.AddressBox.Size = new System.Drawing.Size(240, 15);
            this.AddressBox.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Coral;
            this.label7.Location = new System.Drawing.Point(16, 286);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 24);
            this.label7.TabIndex = 11;
            this.label7.Text = "Address";
            // 
            // RegisterButton
            // 
            this.RegisterButton.BackColor = System.Drawing.Color.Coral;
            this.RegisterButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RegisterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegisterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterButton.ForeColor = System.Drawing.SystemColors.Control;
            this.RegisterButton.Location = new System.Drawing.Point(21, 432);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(243, 32);
            this.RegisterButton.TabIndex = 110;
            this.RegisterButton.Text = "Register!";
            this.RegisterButton.UseVisualStyleBackColor = false;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Coral;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.Location = new System.Drawing.Point(290, 130);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 1);
            this.panel2.TabIndex = 6;
            // 
            // LastNameBox
            // 
            this.LastNameBox.BackColor = System.Drawing.SystemColors.Control;
            this.LastNameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LastNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastNameBox.Location = new System.Drawing.Point(290, 108);
            this.LastNameBox.Name = "LastNameBox";
            this.LastNameBox.Size = new System.Drawing.Size(240, 15);
            this.LastNameBox.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Coral;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Location = new System.Drawing.Point(20, 131);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 1);
            this.panel1.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Coral;
            this.label4.Location = new System.Drawing.Point(286, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "Last Name";
            // 
            // FirstNameBox
            // 
            this.FirstNameBox.BackColor = System.Drawing.SystemColors.Control;
            this.FirstNameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FirstNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstNameBox.Location = new System.Drawing.Point(20, 109);
            this.FirstNameBox.Name = "FirstNameBox";
            this.FirstNameBox.Size = new System.Drawing.Size(240, 15);
            this.FirstNameBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Coral;
            this.label3.Location = new System.Drawing.Point(16, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Coral;
            this.label2.Location = new System.Drawing.Point(14, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "Register!";
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 510);
            this.Controls.Add(this.PanelRight);
            this.Controls.Add(this.PanelLeft);
            this.Controls.Add(this.PanelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Register_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rolesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolesTableData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentTableData)).EndInit();
            this.PanelTop.ResumeLayout(false);
            this.PanelTop.PerformLayout();
            this.PanelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PanelRight.ResumeLayout(false);
            this.PanelRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DataSets.DepartmentTableData departmentTableData;

        private DataSets.DepartmentTableDataTableAdapters.DepartmentsTableAdapter departmentsTableAdapter;
        private System.Windows.Forms.BindingSource departmentsBindingSource;
        private DataSets.RolesTableData rolesTableData;
        private System.Windows.Forms.BindingSource rolesBindingSource;
        private DataSets.RolesTableDataTableAdapters.RolesTableAdapter rolesTableAdapter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PanelTop;
        private System.Windows.Forms.Panel PanelLeft;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel PanelRight;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DateTimePicker DOBpicker;
        private System.Windows.Forms.TextBox UsernameBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox JobTitleBox;
        private System.Windows.Forms.TextBox EmailBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox RoleBox;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox DepartmentBox;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox AddressBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox LastNameBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FirstNameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}