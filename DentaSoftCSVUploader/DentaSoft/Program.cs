using System;
using System.Windows.Forms;

namespace DentaSoft
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            string connectionString = AppConfig.ConnectionString;
            DatabaseConfig.Initialize(connectionString);
            
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}