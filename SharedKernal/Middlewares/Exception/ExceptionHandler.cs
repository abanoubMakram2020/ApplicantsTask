using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SharedKernal.Middlewares.Basees;
using SharedKernal.Middlewares.Handler;
using SharedKernal.Middlewares.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SharedKernal.Middlewares.Exception
{
    public class ExceptionHandler
    {
        #region Fields
        private readonly RequestDelegate request;
        private readonly ILogger logger;
        #endregion

        #region Ctor
        public ExceptionHandler(RequestDelegate request,
                                ILogger logger)
        {
            this.request = request;
            this.logger = logger;
        }
        #endregion

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await request(context);
            }
            catch (System.Exception exception)
            {
                var refCode = Guid.NewGuid().ToString();
                exception.Data.Add("@Reference Code : ", refCode);
                exception.Data.Add("@DateTime : ", DateTime.Now.ToString());
                exception.Data.Add("@Request URL : ", context.Request.Path.ToString());
                logger.Error(exception: exception);

                ResponseResultDto<object> responceResult = new ResponseResultDto<object>
                {
                    ReferenceCode = refCode,
                    StatusCode = Common.Enum.ResponseStatusCode.SystemInternalError,
                    Message = GetLastException(exception),
                };
                var response = JsonHandler.Serialize(responceResult);
                context.Response.Clear();
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(response);
            }
        }

        private static string GetLastException(System.Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex.Message;
        }
    }
}
