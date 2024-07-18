using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Print_Form_Git_PhillMackinnon
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (IsUserRegistered() == true)
            {
                Application.Run(new LoginForm());
            }
            else
            {
                Application.Run(new registrationform());
            }
        }

        private static bool IsUserRegistered()
        {

            return File.Exists("users");
        }
    }
}
