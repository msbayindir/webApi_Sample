

using NLog;
using Services.Contract;

namespace Services
{
	public class LoggerManager:ILoggerService
	{
        private static ILogger logger =  LogManager.GetCurrentClassLogger();





        public void LogDebug(string meesage) => logger.Debug(meesage);


        public void LogError(string meesage) => logger.Error(meesage);


        public void LogInfo(string meesage) => logger.Info(meesage);


        public void LogWarning(string meesage) => logger.Warn(meesage);
        
    }
}

