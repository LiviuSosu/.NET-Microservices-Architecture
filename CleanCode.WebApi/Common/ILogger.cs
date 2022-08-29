using System;

namespace MicroservicesProjectArchitecture.Common
{
    public interface ILogger
    {
        void LogInformation(string methodName, string input);
        void LogException(Exception exception, string actionName, string input);
    }
}
