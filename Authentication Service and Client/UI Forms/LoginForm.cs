using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AuthenticationServiceAndClient.AuthenticationService;
using Models;

namespace AuthenticationServiceAndClient
{
       public partial class LoginForm : Form
    {
        
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {

            AuthenticationServiceClient client = new AuthenticationServiceClient();
            User user = client.AuthorizationUser(textBoxLogin.Text, textBoxPassword.Text);
            if (user.Roles.First<Models.Role>().RoleName.Equals("admin"))
            {
                AdminForm adminForm = new AdminForm(user);
                adminForm.Show();
            }
            else
            {
                OtherUserForm otherUserForm = new OtherUserForm(user);
                otherUserForm.Show();
            }
        }
    }
}
