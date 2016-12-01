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
            if (client.ChangePassword(user, textBoxNewPassword.Text))
                Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
