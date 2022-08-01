using Framework.Logging;
using NLog;

namespace WeatherInformationOfCities.Api.Infrastructure.Logging
{
    public static class LoggerProxy
    {
        static LoggerProxy()
        {
        }

        public static void Log(LogLevels level, Type type, string message,
            Exception exception = null, params object[] args)
        {
            Logger logger = LogManager.GetLogger(type.ToString());
            switch (level)
            {
                case LogLevels.Debug:
                    {
                        logger.Debug(exception: exception, message: message, args: args);
                        break;
                    }
                case LogLevels.Error:
                    {
                        logger.Error(exception: exception, message: message, args: args);
                        break;
                    }
                case LogLevels.Fatal:
                    {
                        logger.Fatal(exception: exception, message: message, args: args);
                        break;
                    }
                case LogLevels.Info:
                    {
                        logger.Info(exception: exception, message: message, args: args);
                        break;
                    }
                case LogLevels.Trace:
                    {
                        logger.Trace(exception: exception, message: message, args: args);
                        break;
                    }
                case LogLevels.Warn:
                    {
                        logger.Warn(exception: exception, message: message, args: args);
                        break;
                    }
            }
        }
    }
}
