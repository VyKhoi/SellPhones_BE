using log4net;
using System.Diagnostics;

namespace BestEnglish.Services.Extensions.Logger
{
    public class LoggerManager : ILoggerManager
    {
        private ILog GetLogger()
        {
            var stack = new StackTrace();
            var frame = stack.GetFrame(2);
            return LogManager.GetLogger(frame!.GetMethod()!.DeclaringType);
        }

        public void LogDebug(string message)
        {
            var logger = GetLogger();
            logger.Debug(message);
        }

        public void LogError(string message)
        {
            var logger = GetLogger();
            logger.Error(message);
        }

        public void LogInfo(string message)
        {
            var logger = GetLogger();
            logger.Info(message);
        }

        public void LogWarn(string message)
        {
            var logger = GetLogger();
            logger.Warn(message);
        }
    }
}