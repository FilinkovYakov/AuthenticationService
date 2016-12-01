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
    public partial class EditUserForm : Form
    {
        private User user;
        public EditUserForm(User user)
        {
            InitializeComponent();
            this.user = user;
            textBoxLogin.Text = user.Login;
            textBoxFullName.Text = user.FullName;
            comboBoxRole.Text = user.Roles.First<Models.Role>().RoleName;
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changePasswordForm = new ChangePasswordForm(user);
            changePasswordForm.Owner = this;
            changePasswordForm.ShowDialog();
        }

        private void buttonEditUser_Click(object sender, EventArgs e)
        {
            AuthenticationServiceClient client = new AuthenticationServiceClient();
            Role userRole = new Role(comboBoxRole.Text);
            IList<Role> Roles = new List<Role>();
            Roles.Add(userRole);
            User newUser = new User(textBoxLogin.Text, textBoxFullName.Text, Roles);
            client.UpdateUser(user, newUser);
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
