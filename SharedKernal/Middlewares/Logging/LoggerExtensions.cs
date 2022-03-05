
namespace SharedKernal.Middlewares.Logging
{
    public static class LoggerExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        /// <param name="data"></param>
        /// <returns>Log</returns>
        public static Serilog.ILogger Data(this Serilog.ILogger log, object data)
        {
            return log.ForContext("@Data", data, true);
        }
    }
}
