using Microsoft.Extensions.Configuration;
using Serilog;
using System;

namespace SharedKernal.Middlewares.Logging
{
    public class Logger : ILogger
    {
        public Logger(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom
                .Configuration(configuration)
                .Enrich.WithMachineName()
                .Enrich.WithProcessId()
                .Enrich.WithThreadId()
                .CreateLogger();
        }

        public void Debug(string message)
        {
            Log.Debug(message);
        }

        public void Debug(string message, object data)
        {
            Log.Logger.Data(data).Debug(message);
        }

        public void Error(System.Exception exception)
        {
            Log.Error(exception, exception.Message);
        }

        public void Error(System.Exception exception, object data)
        {
            Log.Logger.Data(data).Error(exception, exception.Message);
        }

        public void Error(string message)
        {
            Log.Error(message);
        }

        public void Error(string message, object data)
        {
            Log.Logger.Data(data).Error(message);
        }

        public void Fatal(System.Exception exception)
        {
            Log.Fatal(exception, exception.Message);
        }

        public void Fatal(System.Exception exception, object data)
        {
            Log.Logger.Data(data).Fatal(exception, exception.Message);
        }

        public void Information(string message)
        {
            Log.Information(message);
        }

        public void Information(string message, object data)
        {
            Log.Logger.Data(data).Information(message);
        }

        public void Warning(string message)
        {
            Log.Warning(message);
        }

        public void Warning(string message, object data)
        {
            Log.Logger.Data(data).Warning(message);
        }
    }
}
