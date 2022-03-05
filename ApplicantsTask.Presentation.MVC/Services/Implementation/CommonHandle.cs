using ApplicantsTask.Presentation.MVC.Helper;
using ApplicantsTask.Presentation.MVC.Services.Interfaces;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using SharedKernal.Common.Configuration;
using SharedKernal.Middlewares.Basees;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ApplicantsTask.Presentation.MVC.Services.Implementation
{
    public class CommonHandle : ICommonHandle
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public CommonHandle(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<TResponse> Handle<TResponse, TRequest>(TRequest body, string methodUrl, SharedKernal.Common.Enum.HttpMethod methodType, QueryBuilder qs)
        {
            var client = _httpClientFactory.CreateClient(ApplicantAPIConfigurations.ServiceName);
            HttpResponseMessage responseMessage = null;
            switch (methodType)
            {
                case SharedKernal.Common.Enum.HttpMethod.Post:
                    responseMessage = await client.PostAsJsonAsync(requestUri: $"{methodUrl}", body);
                    break;
                case SharedKernal.Common.Enum.HttpMethod.Get:
                    responseMessage = await client.GetAsync(requestUri: $"{methodUrl}{qs}");
                    break;
                case SharedKernal.Common.Enum.HttpMethod.Delete:
                    responseMessage = await client.DeleteAsync(requestUri: $"{methodUrl}{qs}");
                    break;
            }

           

            if (responseMessage.IsSuccessStatusCode)
            {
                var content = await responseMessage.Content.ReadAsStringAsync();

                TResponse result= JsonConvert.DeserializeObject<TResponse>(content);
                
                return result;
            }
            return default;
        }
    }
}
