using MicroservicesProjectArchitecture.Common;
using System;

namespace MicroservicesProjectArchitecture.Infrastructure
{
    public class Logger : ILogger
    {
        public Logger()
        {
            //initialize and configure a logger (i.e serilog)
            //Log.Logger = new LoggerConfiguration()
            //    .WriteTo.File(new Configuration().LoggingFilePath)
            //    .CreateLogger();
        }

        public void LogInformation(string methodName, string input)
        {
            //not implemented yet
            //Log.Logger.Information(string.Format("Logging on {0} with input {1} having the token {2}", methodName, input, token), LogEventLevel.Information);
        }

        public void LogException(Exception exception, string actionName, string input)
        {
            //not implemented yet
            //Log.Logger.Error(string.Format("Occured exception {0} on {1} having the input: {2} and the token {3}", exception.Message, actionName, input, token), LogEventLevel.Error);
        }
    }
}
