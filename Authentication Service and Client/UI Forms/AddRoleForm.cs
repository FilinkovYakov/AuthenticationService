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
    public partial class AddRoleForm : Form
    {
        public AddRoleForm()
        {
            InitializeComponent();
        }

        private void buttonAddRole_Click(object sender, EventArgs e)
        {
            AuthenticationServiceClient client = new AuthenticationServiceClient();
            client.AddRole(textBoxRoleName.Text);
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
