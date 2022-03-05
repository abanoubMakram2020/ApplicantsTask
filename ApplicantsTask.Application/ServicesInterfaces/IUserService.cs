using ApplicantsTask.Application.DTOs.InputDTO;
using ApplicantsTask.Application.DTOs.OutputDTO;
using SharedKernal.Middlewares.Basees;
using System.Threading.Tasks;

namespace ApplicantsTask.Application.ServicesInterfaces
{
    public interface IUserService
    {
        Task<ResponseResultDto<bool>> Register(BaseRequestDto<RegistrationDTO> user);
        Task<ResponseResultDto<TokenDTO>> Login(BaseRequestDto<LoginDTO> user);
    }
}
