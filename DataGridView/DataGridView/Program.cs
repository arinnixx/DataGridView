using DataGridView.Forms;
using DataGridView.MemoryStorage;
using DataGridView.Services;
using Serilog;

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
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Debug()
                .WriteTo.Seq("http://localhost:5341", apiKey: "gM4JM83g7yQxnaYYpJak")
                .CreateLogger();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            var storage = new ListStorage();
            var service = new WarehouseService(storage);

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(service));
        }
    }
}