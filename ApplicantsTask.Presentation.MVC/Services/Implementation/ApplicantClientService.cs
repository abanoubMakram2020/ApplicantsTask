using ApplicantsTask.Presentation.MVC.DTOs.InputDTOs;
using ApplicantsTask.Presentation.MVC.DTOs.OutputDTOs;
using ApplicantsTask.Presentation.MVC.Helper;
using ApplicantsTask.Presentation.MVC.Services.Interfaces;
using Microsoft.AspNetCore.Http.Extensions;
using SharedKernal.Common.Enum;
using SharedKernal.Middlewares.Basees;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicantsTask.Presentation.MVC.Services.Implementation
{
    public class ApplicantClientService : IApplicantClientService
    {
        private readonly ICommonHandle _commonHandle;
        public ApplicantClientService(ICommonHandle commonHandle)
        {
            _commonHandle = commonHandle;
        }

        public async Task<(ApplicantOutputDTO Applicant, string Message)> GetById(int? applicantId)
        {
            var queryString = new QueryBuilder {
                { nameof(applicantId), $"{applicantId}"}
            };
            var apiResult = await _commonHandle.Handle<ResponseResultDto<ApplicantOutputDTO>, string>(methodUrl: $"{ProjectConfiguration.APIURLs.GET_APPLICANT_BY_ID}",
                body: string.Empty, qs: queryString, methodType: SharedKernal.Common.Enum.HttpMethod.Get);

            return (apiResult.Result, apiResult.Message);

        }

        public async Task<(List<ApplicantOutputDTO> Applicant, string Message)> GetAll()
        {

            var apiResult = await _commonHandle.Handle<ResponseResultDto<List<ApplicantOutputDTO>>, string>(methodUrl: $"{ProjectConfiguration.APIURLs.GET_APPLICANTS}", body: string.Empty, qs: null, methodType: SharedKernal.Common.Enum.HttpMethod.Get);

            if (apiResult.StatusCode == ResponseStatusCode.Successfully)
                return (apiResult.Result, apiResult.Message);
            return (new List<ApplicantOutputDTO>(), apiResult.Message);
        }

        public async Task<(int StatusCode, string Message, Dictionary<string, List<string>> Errors)> Save(ApplicantInputDTO applicant)
        {
            var request = new BaseRequestDto<ApplicantInputDTO> { Data = applicant };
            var apiResult = await _commonHandle.Handle<ResponseResultDto<bool>, BaseRequestDto<ApplicantInputDTO> >(methodUrl: $"{ProjectConfiguration.APIURLs.GET_CREATE_UPDATE_APPLICANT}",
                body: request, qs: null, methodType: SharedKernal.Common.Enum.HttpMethod.Post);


            return ((int)apiResult.StatusCode, apiResult.Message, apiResult.Errors);
        }

        public async Task<(bool Result, string Message)> Delete(int applicantId)
        {
            var queryString = new QueryBuilder {
                { nameof(applicantId), applicantId.ToString()}
            };
            var apiResult = await _commonHandle.Handle<ResponseResultDto<bool>, string>(methodUrl: $"{ProjectConfiguration.APIURLs.DELETE_APPLICANT}",
                                               body: string.Empty, qs: queryString, methodType: SharedKernal.Common.Enum.HttpMethod.Delete);

            return (apiResult.Result, apiResult.Message);
        }


    }
}
