using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using InternshipAuthenticationService.Models.OperationResult;
using InternshipAuthenticationService.Models.Faults;
using InternshipAuthenticationService.Models.ServiceModels;
using InternshipAuthenticationService.Client.AuthenticationService;

namespace InternshipAuthenticationService.Client.UIForms
{
    public partial class CreateUserForm : Form
    {
        public CreateUserForm()
        {
            InitializeComponent();

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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Enabled = false;
        }

        private void CreateUserButtonClick(object sender, EventArgs e)
        {
            ClearErrorProvidres();
            if (!ValidateUserData())
                return;

            User user = BuildNewUser();

            try
            {
                AuthenticationServiceClient client = new AuthenticationServiceClient();
                OperationResult serviceResult = client.CreateUser(user, textBoxPassword.Text);
                if (CheckServiceResult(serviceResult))
                {
                    Close();
                }
            }
            catch (FaultException<InvalidRoleFault> exc)
            {
                MessageBox.Show(exc.Message);
            }
            catch (FaultException exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private bool ValidateUserData()
        {
            bool result = true;
            if (!textBoxPassword.Text.Equals(textBoxConfirmPassword.Text))
            {
                errorProviderConfPass.SetError(textBoxConfirmPassword, "Password and confirm password don't match!");
                result = false;
            }
            return result;
        }

        private bool CheckServiceResult(OperationResult serviceResult)
        {
            if (!serviceResult.Success)
            {
                if (serviceResult.Errors.Contains(OperationErrors.LoginErr))
                {
                    errorProviderLogin.SetError(textBoxLogin, "Login is not valid!");
                }
                if (serviceResult.Errors.Contains(OperationErrors.FullNameErr))
                {
                    errorProviderFullName.SetError(textBoxFullName, "Full name is not valid!");
                }
                if (serviceResult.Errors.Contains(OperationErrors.RoleErr))
                {
                    errorProviderRole.SetError(comboBoxRole, "Role is not valid!");
                }
                if (serviceResult.Errors.Contains(OperationErrors.PassErr))
                {
                    errorProviderPass.SetError(textBoxPassword, "Password is not valid!");
                }
                if (serviceResult.Errors.Contains(OperationErrors.UserExistErr))
                {
                    errorProviderLogin.SetError(textBoxLogin, "User with this login exists!");
                }
            }
            return serviceResult.Success;
        }

        private void ClearErrorProvidres()
        {
            errorProviderLogin.Clear();
            errorProviderFullName.Clear();
            errorProviderPass.Clear();
            errorProviderConfPass.Clear();
            errorProviderRole.Clear();
        }

        private User BuildNewUser()
        {
            Role userRole = new Role(comboBoxRole.Text);
            List<Role> Roles = new List<Role>();
            Roles.Add(userRole);
            User user = new User(textBoxLogin.Text, textBoxFullName.Text, Roles);
            return user;
        }
    }
}
