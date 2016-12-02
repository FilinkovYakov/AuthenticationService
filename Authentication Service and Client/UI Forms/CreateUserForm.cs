using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AuthenticationServiceAndClient.AuthenticationService;
using Models;
using Models.Faults;

namespace AuthenticationServiceAndClient
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
            Task<Models.Role[]> rolesTask = client.GetAllRolesAsync();
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
                    catch (FaultException<InvalidRoleFault> exc)
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
                Models.OperationResult serviceResult = client.CreateUser(user, textBoxPassword.Text);
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
                if (serviceResult.Errors.Contains(OperationError.LoginErr))
                {
                    errorProviderLogin.SetError(textBoxLogin, "Login is not valid!");
                }
                if (serviceResult.Errors.Contains(OperationError.FullNameErr))
                {
                    errorProviderFullName.SetError(textBoxFullName, "Full name is not valid!");
                }
                if (serviceResult.Errors.Contains(OperationError.RoleErr))
                {
                    errorProviderRole.SetError(comboBoxRole, "Role is not valid!");
                }
                if (serviceResult.Errors.Contains(OperationError.PassErr))
                {
                    errorProviderPass.SetError(textBoxPassword, "Password is not valid!");
                }
                if (serviceResult.Errors.Contains(OperationError.UserExistsErr))
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
            IList<Role> Roles = new List<Role>();
            Roles.Add(userRole);
            User user = new User(textBoxLogin.Text, textBoxFullName.Text, Roles);
            return user;
        }
    }
}
