namespace AuthenticationServiceAndClient
{
    partial class AdminForm
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
            this.LoginLabel = new System.Windows.Forms.Label();
            this.labelFullName = new System.Windows.Forms.Label();
            this.labelRoleLabel = new System.Windows.Forms.Label();
            this.SearchUserButton = new System.Windows.Forms.Button();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxFullName = new System.Windows.Forms.TextBox();
            this.dataGridViewSearch = new System.Windows.Forms.DataGridView();
            this.Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.buttonCreateUser = new System.Windows.Forms.Button();
            this.comboBoxRole = new System.Windows.Forms.ComboBox();
            this.buttonAddRole = new System.Windows.Forms.Button();
            this.buttonLogOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Location = new System.Drawing.Point(38, 28);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(33, 13);
            this.LoginLabel.TabIndex = 0;
            this.LoginLabel.Text = "Login";
            // 
            // labelFullName
            // 
            this.labelFullName.AutoSize = true;
            this.labelFullName.Location = new System.Drawing.Point(171, 28);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(54, 13);
            this.labelFullName.TabIndex = 1;
            this.labelFullName.Text = "Full Name";
            // 
            // labelRoleLabel
            // 
            this.labelRoleLabel.AutoSize = true;
            this.labelRoleLabel.Location = new System.Drawing.Point(320, 28);
            this.labelRoleLabel.Name = "labelRoleLabel";
            this.labelRoleLabel.Size = new System.Drawing.Size(29, 13);
            this.labelRoleLabel.TabIndex = 2;
            this.labelRoleLabel.Text = "Role";
            // 
            // SearchUserButton
            // 
            this.SearchUserButton.Location = new System.Drawing.Point(468, 66);
            this.SearchUserButton.Name = "SearchUserButton";
            this.SearchUserButton.Size = new System.Drawing.Size(131, 23);
            this.SearchUserButton.TabIndex = 3;
            this.SearchUserButton.Text = "Search";
            this.SearchUserButton.UseVisualStyleBackColor = true;
            this.SearchUserButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(41, 68);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(100, 20);
            this.textBoxLogin.TabIndex = 4;
            // 
            // textBoxFullName
            // 
            this.textBoxFullName.Location = new System.Drawing.Point(174, 68);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.Size = new System.Drawing.Size(100, 20);
            this.textBoxFullName.TabIndex = 5;
            // 
            // dataGridViewSearch
            // 
            this.dataGridViewSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Login,
            this.FullName,
            this.Role,
            this.Edit,
            this.Delete});
            this.dataGridViewSearch.Location = new System.Drawing.Point(41, 114);
            this.dataGridViewSearch.Name = "dataGridViewSearch";
            this.dataGridViewSearch.Size = new System.Drawing.Size(545, 243);
            this.dataGridViewSearch.TabIndex = 7;
            this.dataGridViewSearch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSearch_CellClick);
            // 
            // Login
            // 
            this.Login.HeaderText = "Login";
            this.Login.Name = "Login";
            this.Login.ReadOnly = true;
            // 
            // FullName
            // 
            this.FullName.HeaderText = "FullName";
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            // 
            // Role
            // 
            this.Role.HeaderText = "Role";
            this.Role.Name = "Role";
            this.Role.ReadOnly = true;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Edit ";
            this.Edit.Name = "Edit";
            this.Edit.Text = "Edit";
            this.Edit.ToolTipText = "Edit";
            this.Edit.UseColumnTextForButtonValue = true;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Text = "Delete";
            this.Delete.ToolTipText = "Delete";
            this.Delete.UseColumnTextForButtonValue = true;
            // 
            // buttonCreateUser
            // 
            this.buttonCreateUser.Location = new System.Drawing.Point(455, 363);
            this.buttonCreateUser.Name = "buttonCreateUser";
            this.buttonCreateUser.Size = new System.Drawing.Size(131, 23);
            this.buttonCreateUser.TabIndex = 8;
            this.buttonCreateUser.Text = "CreateUser";
            this.buttonCreateUser.UseVisualStyleBackColor = true;
            this.buttonCreateUser.Click += new System.EventHandler(this.CreateUserButtonClick);
            // 
            // comboBoxRole
            // 
            this.comboBoxRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRole.FormattingEnabled = true;
            this.comboBoxRole.Items.AddRange(new object[] {
            "Admin",
            "Mentor",
            "Intern"});
            this.comboBoxRole.Location = new System.Drawing.Point(323, 68);
            this.comboBoxRole.Name = "comboBoxRole";
            this.comboBoxRole.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRole.TabIndex = 12;
            // 
            // buttonAddRole
            // 
            this.buttonAddRole.Location = new System.Drawing.Point(41, 363);
            this.buttonAddRole.Name = "buttonAddRole";
            this.buttonAddRole.Size = new System.Drawing.Size(131, 23);
            this.buttonAddRole.TabIndex = 13;
            this.buttonAddRole.Text = "Add Role";
            this.buttonAddRole.UseVisualStyleBackColor = true;
            this.buttonAddRole.Click += new System.EventHandler(this.buttonAddRole_Click);
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.Location = new System.Drawing.Point(702, 363);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(75, 23);
            this.buttonLogOut.TabIndex = 14;
            this.buttonLogOut.Text = "Log out";
            this.buttonLogOut.UseVisualStyleBackColor = true;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 398);
            this.Controls.Add(this.buttonLogOut);
            this.Controls.Add(this.buttonAddRole);
            this.Controls.Add(this.comboBoxRole);
            this.Controls.Add(this.buttonCreateUser);
            this.Controls.Add(this.dataGridViewSearch);
            this.Controls.Add(this.textBoxFullName);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.SearchUserButton);
            this.Controls.Add(this.labelRoleLabel);
            this.Controls.Add(this.labelFullName);
            this.Controls.Add(this.LoginLabel);
            this.Name = "AdminForm";
            this.Text = "SearchUserForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.Label labelRoleLabel;
        private System.Windows.Forms.Button SearchUserButton;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxFullName;
        private System.Windows.Forms.DataGridView dataGridViewSearch;
        private System.Windows.Forms.Button buttonCreateUser;
        private System.Windows.Forms.ComboBox comboBoxRole;
        private System.Windows.Forms.Button buttonAddRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn Login;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Role;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.Button buttonLogOut;
    }
}