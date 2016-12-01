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

namespace AuthenticationServiceAndClient
{
    public partial class OtherUserForm : Form
    {
        User user;
        public OtherUserForm(User user)
        {
            InitializeComponent();
            this.user = user;
            Text = "Welcome " + user.Login + ", you role is " + user.Roles.First<Models.Role>().RoleName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user = null;
            Close();
        }
    }
}
