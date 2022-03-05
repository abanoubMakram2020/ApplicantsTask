using Microsoft.AspNetCore.Http.Extensions;
using SharedKernal.Middlewares.Basees;
using System.Threading.Tasks;

namespace ApplicantsTask.Presentation.MVC.Services.Interfaces
{
    public interface ICommonHandle
    {
        Task<TResponse> Handle<TResponse, TRequest>(TRequest body, string methodUrl, SharedKernal.Common.Enum.HttpMethod methodType, QueryBuilder qs);
    }
}
