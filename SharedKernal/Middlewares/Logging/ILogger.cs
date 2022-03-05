using System;

namespace SharedKernal.Middlewares.Logging
{
    public interface ILogger
    {
        /// <summary>
        /// The DEBUG Level designates fine-grained informational events that are most useful to debug an application
        /// </summary>
        /// <param name="message">Exception Message</param>
        void Debug(string message);

        /// <summary>
        /// The DEBUG Level designates fine-grained informational events that are most useful to debug an application
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        void Debug(string message, object data);

        /// <summary>
        /// The ERROR level designates error events that might still allow the application to continue running
        /// Log Error Exception
        /// </summary>
        /// <param name="exception"></param>
        void Error(System.Exception exception);

        /// <summary>
        /// The ERROR level designates error events that might still allow the application to continue running
        /// Log Error Exception & data
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="data"></param>
        void Error(System.Exception exception, object data);

        /// <summary>
        /// The ERROR level designates error events that might still allow the application to continue running
        /// Log Error Exception Message
        /// </summary>
        /// <param name="message">Exception Message</param>
        void Error(string message);

        /// <summary>
        /// The ERROR level designates error events that might still allow the application to continue running
        /// Log Error Exception Message & data
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        void Error(string message, object data);

        /// <summary>
        /// The FATAL level designates very severe error events that will presumably lead the application to abort.
        /// </summary>
        /// <param name="exception"></param>
        void Fatal(System.Exception exception);

        /// <summary>
        /// The FATAL level designates very severe error events that will presumably lead the application to abort.
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="data"></param>
        void Fatal(System.Exception exception, object data);

        /// <summary>
        /// The INFO level designates informational messages that highlight the progress of the application at coarse-grained level
        /// </summary>
        /// <param name="message">as string</param>
        void Information(string message);

        /// <summary>
        /// The INFO level designates informational messages that highlight the progress of the application at coarse-grained level
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        void Information(string message, object data);

        /// <summary>
        /// The WARN level designates potentially harmful situations
        /// </summary>
        /// <param name="message"> as string</param>
        void Warning(string message);

        /// <summary>
        /// The WARN level designates potentially harmful situations
        /// </summary>
        /// <param name="message"> as string</param>
        /// <param name="data"></param>
        void Warning(string message, object data);
    }
}
