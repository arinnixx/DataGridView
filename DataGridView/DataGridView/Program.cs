using DataGridView.Forms;
using DataGridView.MemoryStorage.Contracts;
using DataGridView.MemoryStorage;
using DataGridView.Services;

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
            
            var storage = new ListStorage();
            var service = new WarehouseService(storage);

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(service));
        }
    }
}