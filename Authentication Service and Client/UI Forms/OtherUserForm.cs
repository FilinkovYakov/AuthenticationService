using InternshipAuthenticationService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InternshipAuthenticationService.Models.ServiceModels;

namespace InternshipAuthenticationService.Client.UIForms
{
    public partial class OtherUserForm : Form
    {
        User user;
        public OtherUserForm(User user)
        {
            InitializeComponent();
            this.user = user;
            Text = "Welcome " + user.Login + ", your role is " + user.Roles.First<Role>().RoleName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user = null;
            Close();
        }
    }
}
