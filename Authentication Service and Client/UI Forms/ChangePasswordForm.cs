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
            AuthenticationServiceClient client = new AuthenticationServiceClient();
            OperationResult serviceResult = client.ChangePassword(user, textBoxNewPassword.Text);
            if (serviceResult.Success)
                Close();
            else
                MessageBox.Show("Invalid password!");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
