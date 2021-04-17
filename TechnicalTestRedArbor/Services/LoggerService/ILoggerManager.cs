using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTestRedArbor.Services.LoggerService
{
    public interface ILoggerManager
    {
        void LogDebug(string message);

        void LogError(string message);

        void LogInfo(string message);

        void LogWarn(string message);
    }
}