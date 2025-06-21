using KefTools.Utils;
using Serilog;
using Serilog.Events;

namespace KefTools
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger.Init(LogEventLevel.Debug);

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());

            Application.ApplicationExit += (_, _) => Log.CloseAndFlush();
        }
    }
}