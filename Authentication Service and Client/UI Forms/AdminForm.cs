using System;
using System.Linq;
using InternshipAuthenticationService.Models.OperationResult;
using System.Windows.Forms;
using InternshipAuthenticationService.Client.AuthenticationService;
using InternshipAuthenticationService.Models.ServiceModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ComponentModel;
using InternshipAuthenticationService.Client.UI_Forms;

namespace InternshipAuthenticationService.Client.UIForms
{
    public partial class AdminForm : Form
    {
        private User _user = new User();
        private User[] users = new User[5];
        public AdminForm(User user)
        {
            InitializeComponent();
            this._user = user;
            this.Text = "Welcome " + user.Login + ", your role is " + user.Roles.First<Role>().RoleName;
            dataGridViewSearch.AutoGenerateColumns = false;
            dataGridViewSearch.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridViewSearch.AllowUserToResizeRows = false;
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
                        comboBoxRole.Items.Add("All roles");
                        foreach (string role in task.Result.Select(r => r.RoleName))
                        {
                            comboBoxRole.Items.Add(role);
                        }
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
            createUserForm.ShowDialog(this);
        }

        private async void dataGridViewSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 3 && e.RowIndex < dataGridViewSearch.RowCount && e.RowIndex >= 0)
            {
                ClientUser clientUser = (ClientUser)dataGridViewSearch.Rows[e.RowIndex].DataBoundItem;
                User user = MapToServiceUser(clientUser);
                EditUserForm form = new EditUserForm(user, _user);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    dataGridViewSearch.Rows[e.RowIndex].Cells[0].Value = user.Login;
                    dataGridViewSearch.Rows[e.RowIndex].Cells[1].Value = user.FullName;
                    dataGridViewSearch.Rows[e.RowIndex].Cells[2].Value = user.Roles.First().RoleName;
                }
            }
            else
                if (e.ColumnIndex == 4 && e.RowIndex < dataGridViewSearch.RowCount && e.RowIndex >= 0)
            {
                ClientUser clientUser = (ClientUser)dataGridViewSearch.Rows[e.RowIndex].DataBoundItem;
                if (clientUser.Id == _user.Id)
                {
                    MessageBox.Show(this, "You can not delete yourself!");
                    return;
                }
                User user = MapToServiceUser(clientUser);
                DialogResult dialogResult = MessageBox.Show(
                    this,
                    string.Format("Are you sure to delete '{0}' user?", user.FullName),
                    "Delete user",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        AuthenticationServiceClient client = new AuthenticationServiceClient();
                        Form frm = new ProgressForm();
                        frm.Show();
                        OperationResult serviceResult = await client.DeleteUserAsync(user);
                        frm.Close();
                        if (!serviceResult.Success)
                        {
                            MessageBox.Show(this, "Users not found!");
                        }
                        else
                        {
                            dataGridViewSearch.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                    catch (FaultException exc)
                    {
                        MessageBox.Show(exc.Message);
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

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            _user = null;
            Close();
        }

        private async void SearchUserButton_Click(object sender, EventArgs e)
        {
            try
            {
                AuthenticationServiceClient client = new AuthenticationServiceClient();
                string roleName = comboBoxRole.Text;
                if (roleName.ToLower().Equals("all roles"))
                {
                    roleName = "";
                }
                Form frm = new ProgressForm();
                frm.Show();
                User[] users = await client.SearchUserAsync(textBoxLogin.Text, textBoxFullName.Text, roleName);
                frm.Close();
                dataGridViewSearch.DataSource = new BindingList<ClientUser>(users.Select(user => new ClientUser(user)).ToList());
                if (users.Length == 0)
                {
                    MessageBox.Show("Users not found!");
                }
            }
            catch (FaultException exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
