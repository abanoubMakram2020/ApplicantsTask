using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using SharedKernal.Common.Enum;

namespace SharedKernal.Middlewares.Basees
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public class ResponseResultDto<TResult>
    {

        public TResult Result { get; set; }
        public string Message { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }
        public string ReferenceCode { get; set; }
        public ResponseStatusCode StatusCode { get; set; }
        public string StatusName => StatusCode.ToString();

        /// <summary>
        /// Return Success Code => 1 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResponseResultDto<TResult> Success(TResult result, string message)
        {
            return new ResponseResultDto<TResult>()
            {
                StatusCode = ResponseStatusCode.Successfully,
                Message = message,
                Result = result,
            };
        }
         
        /// <summary>
        /// Return NotFound Code => 2
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResponseResultDto<TResult> NotFound(TResult result, string message)
        {
            return new ResponseResultDto<TResult>()
            {
                StatusCode = ResponseStatusCode.NotFound,
                Message = message,
                Result = result,
            };
        }

        /// <summary>
        /// Return NotAccept Code => 3 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResponseResultDto<TResult> NotAccept(TResult result, string message)
        {
            return new ResponseResultDto<TResult>()
            {
                StatusCode = ResponseStatusCode.NotAccept,
                Message = message,
                Result = result,
            };
        }

        /// <summary>
        /// Return MultiError code => 4 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResponseResultDto<TResult> MultiError(TResult result, string message)
        {
            return new ResponseResultDto<TResult>()
            {
                StatusCode = ResponseStatusCode.MultiError,
                Message = message,
                Result = result,
            };
        }
        public static ResponseResultDto<TResult> MultiError(Dictionary<string, List<string>> dic, string message)
        {
            return new ResponseResultDto<TResult>()
            {
                StatusCode = ResponseStatusCode.MultiError,
                Message = message,
                Errors = dic,
            };
        }
        /// <summary>
        /// Return MoveNotAccept code => 5 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResponseResultDto<TResult> MoveNotAccept(TResult result, string message)
        {
            return new ResponseResultDto<TResult>()
            {
                StatusCode = ResponseStatusCode.MoveNotAccept,
                Message = message,
                Result = result,
            };
        }

        /// <summary>
        /// Return InternalError code => 6  
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResponseResultDto<TResult> SystemError(TResult result, string message)
        {
            return new ResponseResultDto<TResult>()
            {
                StatusCode = ResponseStatusCode.SystemInternalError,
                Message = message,
                Result = result,
            };
        }

        /// <summary>
        /// Return Dublicate code => 7  
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResponseResultDto<TResult> Dublicate(TResult result, string message)
        {
            return new ResponseResultDto<TResult>()
            {
                StatusCode = ResponseStatusCode.Dublicate,
                Message = message,
                Result = result,
            };
        }

        /// <summary>
        /// Return InvalidData code => 8  
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResponseResultDto<TResult> InvalidData(TResult result, string message)
        {
            return new ResponseResultDto<TResult>()
            {
                StatusCode = ResponseStatusCode.InvalidData,
                Message = message,
                Result = result,
            };
        }
    }
}
