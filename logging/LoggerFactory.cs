using NLog;
using NLog.Config;
using NLog.Targets;

namespace TrepidaApp.Logging
{
    public static class LoggerFactory
    {
        public static void Configure()
        {
            var config = new LoggingConfiguration();

            var logfile = new FileTarget("logfile")
            {
                FileName = "logs/log.txt",
                Layout = "${longdate} | ${level:uppercase=true} | ${logger} | ${message} ${exception:format=ToString}"
            };

            var logconsole = new ConsoleTarget("logconsole");

            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            LogManager.Configuration = config;
        }
    }
}
