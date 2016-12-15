using InternshipAuthenticationService.Models.OperationResult;
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
using System.ServiceModel;

namespace InternshipAuthenticationService.Client.UIForms
{
    public partial class ChangePasswordForm : Form
    {
        User user;
        public ChangePasswordForm(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            ClearErrorProvidres();
            if (!ValidateUserData())
                return;
            try
            {
                AuthenticationServiceClient client = new AuthenticationServiceClient();
                OperationResult serviceResult = client.ChangePassword(user, textBoxNewPassword.Text);
                if (serviceResult.Success)
                    Close();
                if (serviceResult.Errors.Contains(OperationErrors.PassErr))
                {
                    errorProviderNewPassword.SetError(textBoxNewPassword, "Password is not valid!");
                }

            }
            catch (FaultException exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private bool ValidateUserData()
        {
            bool result = true;
            if (!textBoxNewPassword.Text.Equals(textBoxConfirmPassword.Text))
            {
                errorProviderConfirmNewPassword.SetError(textBoxConfirmPassword, "Password and confirm password don't match!");
                result = false;
            }
            return result;
        }

        private void ClearErrorProvidres()
        {
            errorProviderNewPassword.Clear();
            errorProviderConfirmNewPassword.Clear();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
