using InternshipAuthenticationService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InternshipAuthenticationService.Client.AuthenticationService;
using InternshipAuthenticationService.Models.ServiceModels;
using InternshipAuthenticationService.Models.OperationResult;
using System.ServiceModel;

namespace InternshipAuthenticationService.Client.UIForms
{
    public partial class EditUserForm : Form
    {
        private User user;
        public EditUserForm(User user)
        {
            InitializeComponent();
            this.user = user;
            textBoxLogin.Text = user.Login;
            textBoxFullName.Text = user.FullName;
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
                       Enabled = true;
                        comboBoxRole.Text = user.Roles.First<Role>().RoleName;
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
        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changePasswordForm = new ChangePasswordForm(user);
            changePasswordForm.Owner = this;
            changePasswordForm.ShowDialog();
        }

        private void buttonEditUser_Click(object sender, EventArgs e)
        {
            user.Login = textBoxLogin.Text;
            user.FullName = textBoxFullName.Text;
            IList<Role> roles = new List<Role>();
            roles.Add(new Role(comboBoxRole.Text));
            user.Roles = roles;
            AuthenticationServiceClient client = new AuthenticationServiceClient();
            OperationResult serviceResult = client.UpdateUser(user);
            if (!serviceResult.Success)
            {
                MessageBox.Show("Invalid data!");
            }
            else
            {
                Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
