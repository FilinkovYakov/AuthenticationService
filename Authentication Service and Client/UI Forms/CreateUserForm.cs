using System;
using System.Collections.Generic;
using System.ServiceModel;
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
        }

        private void CreateUserButtonClick(object sender, EventArgs e)
        {
            errorProviderLogin.Clear();
            errorProviderFullName.Clear();
            errorProviderPass.Clear();
            errorProviderConfPass.Clear();
            errorProviderRole.Clear();
            AuthenticationServiceClient client = new AuthenticationServiceClient();          
            Role userRole = new Role(comboBoxRole.Text);
            IList<Role> Roles = new List<Role>();
            Roles.Add(userRole);
            User user = new User(textBoxLogin.Text, textBoxFullName.Text, Roles);

            try
            {
                Models.OperationResult serviceResult = client.CreateUser(user, textBoxPassword.Text);
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
                else
                    Close();
            }
            catch (FaultException<InvalidRoleFault> exc)
            {

            }
            catch (FaultException exc)
            {

            }
            //if (textBoxFullName.Text.Equals(""))
            //{
            //    errorProviderFullName.SetError(textBoxFullName, "Name is not valid!");
            //    validData = false;
            //}           
            //if (comboBoxRole.Text.Equals(""))
            //{
            //    errorProviderRole.SetError(comboBoxRole, "Role is not valid!");
            //    validData = false;
            //}
            //if (serviceResult.Message.Equals("Passwords do not match!"))
            //{
            //    errorProviderPass.SetError(textBoxPassword, "Passwords do not match!");
            //    errorProviderConfPass.SetError(textBoxConfirmPassword, "Passwords do not match!");
            //    validData = false;
            //}
            //if (textBoxPassword.Text.Equals(""))
            //{
            //    errorProviderPass.SetError(textBoxPassword, "Password is not valid!");
            //    validData = false;
            //}
            //if (textBoxConfirmPassword.Text.Equals(""))
            //{
            //    errorProviderConfPass.SetError(textBoxConfirmPassword, "Password is not valid!");
            //    validData = false;
            //}
            //if (validData)
            //{
            //    AuthenticationServiceClient client = new AuthenticationServiceClient();
            //    if (client.IsExists(textBoxLogin.Text))
            //        errorProviderLogin.SetError(textBoxLogin, "User with this login exists!");
            //    else
            //    {
            //        Role userRole = new Role(comboBoxRole.Text);
            //        IList<Role> Roles = new List<Role>();
            //        Roles.Add(userRole);
            //        User user = new User(textBoxLogin.Text, textBoxFullName.Text, Roles);
            //        client.CreateUser(user, textBoxPassword.Text, textBoxConfirmPassword.Text);
            //        Close();
            //    }
            //}


        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
