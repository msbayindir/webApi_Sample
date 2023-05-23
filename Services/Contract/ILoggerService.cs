using System;
namespace Services.Contract
{
	public interface ILoggerService
	{
		void LogInfo(string meesage);
        void LogWarning(string meesage);
        void LogError(string meesage);
        void LogDebug(string meesage);

    }
}

