using Serilog;
using Serilog.Events;

namespace KefTools.Utils;

public static class Logger
{
    public static void Init(LogEventLevel level)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Is(level)
            .Enrich.FromLogContext()
            .Enrich.WithProperty("Component", "Global")
            .WriteTo.Console(outputTemplate: "[{Level}] [{Component}] {Message:lj}{NewLine}")
            .CreateLogger();

        Log.Debug("Logger initialized with level: {Level}", level);
    }
}
