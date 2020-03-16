using System;
using System.Windows.Forms;
using VehicleHistoryDesktop.Forms;

namespace VehicleHistoryDesktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>s
        [STAThread]
        static void Main()
        {
            Environment.SetEnvironmentVariable("runenv", "Prod");
#if DEBUG
            Environment.SetEnvironmentVariable("runenv", "Dev");
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginScreen());
        }
    }
}
