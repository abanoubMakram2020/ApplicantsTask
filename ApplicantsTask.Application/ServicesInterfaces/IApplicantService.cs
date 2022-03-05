using ApplicantsTask.Application.DTOs.InputDTO;
using ApplicantsTask.Application.DTOs.OutputDTO;
using SharedKernal.Middlewares.Basees;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicantsTask.Application.ServicesInterfaces
{
    public interface IApplicantService
    {
        Task<ResponseResultDto<ApplicantOutputDTO>> GetById(BaseRequestDto<int> Id);
        Task<ResponseResultDto<List<ApplicantOutputDTO>>> GetAll();
        Task<ResponseResultDto<bool>> SaveApplicant(BaseRequestDto<ApplicantInputDTO> ApplicantInputDTO);
        Task<ResponseResultDto<bool>> DeleteById(BaseRequestDto<int> Id);
    }
}
