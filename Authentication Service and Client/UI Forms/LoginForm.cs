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
using InternshipAuthenticationService.Client.AuthenticationService;
using InternshipAuthenticationService.Models.OperationResult;
using InternshipAuthenticationService.Models.ServiceModels;

namespace InternshipAuthenticationService.Client.UIForms
{
       public partial class LoginForm : Form
    {
        
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                AuthenticationServiceClient client = new AuthenticationServiceClient();
                OperationResult<User> result = client.AuthorizationUser(textBoxLogin.Text, textBoxPassword.Text);
                if (result.Success)
                {
                    Hide();
                    if (result.Result.Roles.First<Role>().RoleName.Equals("Admin"))
                    {
                        AdminForm adminForm = new AdminForm(result.Result);
                        adminForm.FormClosed += FormClosed;
                        adminForm.Show();
                    }
                    else
                    {
                        OtherUserForm otherUserForm = new OtherUserForm(result.Result);
                        otherUserForm.FormClosed += FormClosed;
                        otherUserForm.Show();
                    }
                }
                else
                    MessageBox.Show("Invalid login or password!");
            }
            catch (FaultException exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}
