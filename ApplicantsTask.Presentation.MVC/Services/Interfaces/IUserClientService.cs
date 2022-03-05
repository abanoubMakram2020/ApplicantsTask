using ApplicantsTask.Presentation.MVC.DTOs.InputDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicantsTask.Presentation.MVC.DTOs.OutputDTOs;

namespace ApplicantsTask.Presentation.MVC.Services.Interfaces
{
    public interface IUserClientService
    {
        Task<(TokenDTO Token, string Message)> Login(LoginDTO logingDTO);
        Task<(int StatusCode, string Message, Dictionary<string, List<string>> Errors)> Register(RegistrationDTO registrationDTO);
    }
}
