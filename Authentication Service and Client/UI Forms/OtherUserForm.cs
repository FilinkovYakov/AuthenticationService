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
    public partial class OtherUserForm : Form
    {
        private User _user = new User();
        private User[] users = new User[5];
        public OtherUserForm(User user)
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
