using DataGridView.Forms;
using DataGridView.MemoryStorage;
using DataGridView.Services;
using Microsoft.Extensions.Logging;
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
            using var log = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Debug()
                .WriteTo.File("logs/log-.txt",
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.Seq("http://localhost:5341", apiKey: "gM4JM83g7yQxnaYYpJak")
                .CreateLogger();

            using var loggerFactory = LoggerFactory.Create(builder =>
                {
                builder.AddSerilog(log);
            });

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            var storage = new ListStorage();
            var service = new WarehouseService(storage, loggerFactory);

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(service));
        }
    }
}