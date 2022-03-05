using ApplicantsTask.Presentation.MVC.DTOs.InputDTOs;
using ApplicantsTask.Presentation.MVC.DTOs.OutputDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicantsTask.Presentation.MVC.Services.Interfaces
{
    public interface IApplicantClientService
    {
        Task<(List<ApplicantOutputDTO> Applicant, string Message)> GetAll();
        Task<(ApplicantOutputDTO Applicant, string Message)> GetById(int? applicantId);
        Task<(int StatusCode, string Message, Dictionary<string, List<string>> Errors)> Save(ApplicantInputDTO applicant);
        Task<(bool Result, string Message)> Delete(int applicantId);
    }
}
