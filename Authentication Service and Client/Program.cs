using AuthenticationServiceAndClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuthenticationServiceAndClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Models.Role userRole = new Models.Role("admin");
            IList<Models.Role> Roles = new List<Models.Role>();
            Roles.Add(userRole);
            Models.User user = new Models.User("alexey", "Alexey", Roles);
            Application.Run(new AdminForm(user));
        }
    }
}
