using DataGridView.Forms;
using DataGridView.MemoryStorage.Contracts;
using DataGridView.MemoryStorage;

namespace DataGridView
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            IStorage storage = new ListStorage();
            Application.Run(new MainForm(storage));
        }
    }
}