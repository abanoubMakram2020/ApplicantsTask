using ApplicantsTask.Presentation.MVC.DTOs.InputDTOs;
using ApplicantsTask.Presentation.MVC.DTOs.OutputDTOs;
using ApplicantsTask.Presentation.MVC.Helper;
using ApplicantsTask.Presentation.MVC.Services.Interfaces;
using SharedKernal.Middlewares.Basees;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicantsTask.Presentation.MVC.Services.Implementation
{
    public class UserClientService : IUserClientService
    {
        private readonly ICommonHandle _commonHandle;
        public UserClientService(ICommonHandle commonHandle)
        {
            _commonHandle = commonHandle;
        }

        public async Task<(TokenDTO Token,string Message)> Login(LoginDTO loginDTO)
        {
            var request = new BaseRequestDto<LoginDTO> { Data = loginDTO };
            var apiResult = await _commonHandle.Handle<ResponseResultDto<TokenDTO>, BaseRequestDto<LoginDTO>>(methodUrl: $"{ProjectConfiguration.APIURLs.USER_LOGIN}",
                body: request, qs: null, methodType: SharedKernal.Common.Enum.HttpMethod.Post);


            return (apiResult.Result, apiResult.Message);

        }

        public async Task<(int StatusCode, string Message, Dictionary<string, List<string>> Errors)> Register(RegistrationDTO registrationDTO)
        {
            var request = new BaseRequestDto<RegistrationDTO> { Data = registrationDTO };
            var apiResult = await _commonHandle.Handle<ResponseResultDto<bool>, BaseRequestDto<RegistrationDTO>>(methodUrl: $"{ProjectConfiguration.APIURLs.USER_REGISTRATION}",
                body: request, qs: null, methodType: SharedKernal.Common.Enum.HttpMethod.Post);

            return ((int)apiResult.StatusCode, apiResult.Message, apiResult.Errors);
        }

      
    }
}
