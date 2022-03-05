using Microsoft.AspNetCore.Mvc;
using SharedKernal.Middlewares.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SharedKernal.Middlewares.Basees
{
    public sealed class Presenter
    {
        #region Properties
        public ContentResult ContentResult { get; }
        #endregion

        #region Constructor
        public Presenter()
        {
            ContentResult = new ContentResult
            {
                ContentType = "application/json"
            };
        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="serviceRequest"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ContentResult> Handle<TRequest, TResponse>(Func<BaseRequestDto<TRequest>, Task<ResponseResultDto<TResponse>>> serviceRequest, BaseRequestDto<TRequest> request)
        {
            ResponseResultDto<TResponse> response = await serviceRequest.Invoke(request);
            if (response != null)
            {
                ContentResult.StatusCode = (int)HttpStatusCode.OK;
                ContentResult.Content = JsonHandler.Serialize(response);
                return ContentResult;
            }
            ContentResult.StatusCode = (int)HttpStatusCode.OK;
            ContentResult.Content = JsonHandler.Serialize(response);
            return ContentResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="serviceRequest"></param>
        /// <returns></returns>
        public async Task<ContentResult> Handle<TResponse>(Func<Task<ResponseResultDto<TResponse>>> serviceRequest)
        {
            ResponseResultDto<TResponse> response = await serviceRequest.Invoke();
            if (response != null)
            {
                ContentResult.StatusCode = (int)HttpStatusCode.OK;
                ContentResult.Content = JsonHandler.Serialize(response);
                return ContentResult;
            }
            ContentResult.StatusCode = (int)HttpStatusCode.OK;
            ContentResult.Content = JsonHandler.Serialize(response);
            return ContentResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="serviceRequest"></param>
        /// <returns></returns>
        public async Task<ContentResult> Handle<TResponse>(Func<Task<TResponse>> serviceRequest)
        {
            TResponse response = await serviceRequest.Invoke();
            if (response != null)
            {
                ContentResult.StatusCode = (int)HttpStatusCode.OK;
                ContentResult.Content = JsonHandler.Serialize(response);
                return ContentResult;
            }
            ContentResult.StatusCode = (int)HttpStatusCode.OK;
            ContentResult.Content = JsonHandler.Serialize(response);
            return ContentResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="serviceRequest"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ContentResult> Handle<TRequest, TResponse>(Func<TRequest, Task<TResponse>> serviceRequest, TRequest request)
        {
            TResponse response = await serviceRequest.Invoke(request);
            if (response != null)
            {
                ContentResult.StatusCode = (int)HttpStatusCode.OK;
                ContentResult.Content = JsonHandler.Serialize(response);
                return ContentResult;
            }
            ContentResult.StatusCode = (int)HttpStatusCode.OK;
            ContentResult.Content = JsonHandler.Serialize(response);
            return ContentResult;
        }
        #endregion

    }
}
