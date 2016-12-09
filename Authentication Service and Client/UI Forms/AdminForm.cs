using System;
using System.Linq;
using InternshipAuthenticationService.Models.OperationResult;
using System.Windows.Forms;
using InternshipAuthenticationService.Client.AuthenticationService;
using InternshipAuthenticationService.Models.ServiceModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ServiceModel;

namespace InternshipAuthenticationService.Client.UIForms
{
    public partial class AdminForm : Form
    {
        List<ClientUser> clientUsers = new List<ClientUser>();
        User user;
        public AdminForm(User user)
        {
            InitializeComponent();
            this.user = user;
            this.Text = "Welcome " + user.Login + ", you role is " + user.Roles.First<Role>().RoleName;
            dataGridViewSearch.AutoGenerateColumns = false;
            LoadRoles();
        }

        private void LoadRoles()
        {
            AuthenticationServiceClient client = new AuthenticationServiceClient();
            Task<Role[]> rolesTask = client.GetAllRolesAsync();
            rolesTask.ContinueWith(task =>
            {
                Invoke(new Action(() =>
                {
                    try
                    {
                        comboBoxRole.Items.Clear();
                        foreach (string role in task.Result.Select(r => r.RoleName))
                        {
                            comboBoxRole.Items.Add(role);
                        }
                        comboBoxRole.Items.Add("All roles");
                        Enabled = true;
                    }
                    catch (FaultException<Models.Faults.InvalidRoleFault> exc)
                    {
                        MessageBox.Show(exc.Message);
                    }
                    catch (FaultException exc)
                    {
                        MessageBox.Show(exc.Message);
                    }
                }));
            });
        }

        private void CreateUserButtonClick(object sender, EventArgs e)
        {
            CreateUserForm createUserForm = new CreateUserForm();
            createUserForm.Owner = this;
            createUserForm.ShowDialog();
        }

        private void dataGridViewSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 3 && e.RowIndex < dataGridViewSearch.RowCount)
            {
                ClientUser clientUser = (ClientUser)dataGridViewSearch.Rows[e.RowIndex].DataBoundItem;
                User user = MapToServiceUser(clientUser);
                EditUserForm form = new EditUserForm(user);
                form.Owner = this;
                form.ShowDialog();
            }
            else
                if (e.ColumnIndex == 4 && e.RowIndex < dataGridViewSearch.RowCount)
            {
                ClientUser clientUser = (ClientUser)dataGridViewSearch.Rows[e.RowIndex].DataBoundItem;
                User user = MapToServiceUser(clientUser);
                DialogResult dialogResult = MessageBox.Show(
                    this,
                    string.Format("Are you sure you want delete '{0}' user?", user.FullName),
                    "Delete user",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.Yes)
                {
                    AuthenticationServiceClient client = new AuthenticationServiceClient();
                    OperationResult serviceResult = client.DeleteUser(user);
                    if (!serviceResult.Success)
                    {
                        MessageBox.Show("Users not found!");
                    }                   
                }


            }
        }

        private static User MapToServiceUser(ClientUser clientUser)
        {
            User user = new User();
            user.Id = clientUser.Id;
            user.Login = clientUser.Login;
            user.FullName = clientUser.FullName;
            user.Roles = new List<Role> { new Models.ServiceModels.Role(clientUser.Role) };
            return user;
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

        private void SearchUserButton_Click(object sender, EventArgs e)
        {
            AuthenticationServiceClient client = new AuthenticationServiceClient();
            string roleName = comboBoxRole.Text;
            if (roleName.ToLower().Equals("all roles"))
            {
                roleName = "";
            }
            User[] users = client.SearchUser(textBoxLogin.Text, textBoxFullName.Text, roleName);
            clientUsers = new List<ClientUser>();
            if (users.Count() == 0)
            {
                MessageBox.Show("Users not found!");
            }
            else {
                foreach (User user in users) {
                    clientUsers.Add(new ClientUser(user));
                }
            }
            dataGridViewSearch.DataSource = clientUsers;
        }
    }
}
