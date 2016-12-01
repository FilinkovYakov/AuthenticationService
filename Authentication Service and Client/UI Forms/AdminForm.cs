using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AuthenticationServiceAndClient.AuthenticationService;

namespace AuthenticationServiceAndClient
{
    public partial class AdminForm : Form
    {
        User user;
        public AdminForm(User user)
        {
            InitializeComponent();
            this.user = user;
            this.Text = "Welcome " + user.Login + ", you role is " + user.Roles.First<Models.Role>().RoleName;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            dataGridViewSearch.Rows.Add(textBoxLogin.Text, textBoxFullName.Text, comboBoxRole.Text);
            //Authentication_Service_WCFClient client = new Authentication_Service_WCFClient();
            //if (client.searchUser(textBoxLogin.Text, textBoxFullName.Text, comboBoxRole.Text) != null)
            //{
            //    foreach (User user in client.searchUser(textBoxLogin.Text, textBoxFullName.Text, comboBoxRole.Text))
            //        dataGridViewSearch.Rows.Add(user.Login, user.FullName, user.Role.RoleName);
            //}
            //else
            //    dataGridViewSearch.Rows.Add(null, null, null);
        }

        private void CreateUserButtonClick(object sender, EventArgs e)
        {
            CreateUserForm createUserForm = new CreateUserForm();
            createUserForm.Owner = this;
            createUserForm.ShowDialog();
        }

        private void dataGridViewSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 3 && e.RowIndex < dataGridViewSearch.RowCount - 1)
            {
                Role userRole = new Role(dataGridViewSearch.Rows[e.RowIndex].Cells[2].Value.ToString());
                IList<Role> Roles = new List<Role>();
                Roles.Add(userRole);
                User user = new User(dataGridViewSearch.Rows[e.RowIndex].Cells[0].Value.ToString(), dataGridViewSearch.Rows[e.RowIndex].Cells[1].Value.ToString(), Roles);
                EditUserForm form = new EditUserForm(user);
                form.Owner = this;
                form.ShowDialog();
            }
            else
                if (e.ColumnIndex == 4 && e.RowIndex < dataGridViewSearch.RowCount - 1) {
                DialogResult result = MessageBox.Show(
        "Are you sure you want delete this user?",
        "Confirm action",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Information,
        MessageBoxDefaultButton.Button1,
        MessageBoxOptions.DefaultDesktopOnly);

                if (result == DialogResult.Yes) {
                    Role userRole = new Role(dataGridViewSearch.Rows[e.RowIndex].Cells[2].Value.ToString());
                    IList<Role> Roles = new List<Role>();
                    Roles.Add(userRole);
                    User user = new User(dataGridViewSearch.Rows[e.RowIndex].Cells[0].Value.ToString(), dataGridViewSearch.Rows[e.RowIndex].Cells[1].Value.ToString(), Roles);
                    AuthenticationServiceClient client = new AuthenticationServiceClient();
                    client.DeleteUser(user);
                }

                
            }
        }

        private void buttonAddRole_Click(object sender, EventArgs e)
        {
            AddRoleForm addRoleForm = new AddRoleForm();
            addRoleForm.Owner = this;
            addRoleForm.ShowDialog();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            user = null;
            Close();
        }
    }
}
