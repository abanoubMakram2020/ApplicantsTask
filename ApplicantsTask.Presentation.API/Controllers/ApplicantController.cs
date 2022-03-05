using ApplicantsTask.Application.DTOs.InputDTO;
using ApplicantsTask.Application.DTOs.OutputDTO;
using ApplicantsTask.Application.ServicesInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernal.Common;
using SharedKernal.Middlewares.Basees;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicantsTask.Presentation.API.Controllers
{
    public class ApplicantController : BaseController
    {
        #region Fields
        private readonly IApplicantService _ApplicantService;
        #endregion

        #region ctor
        public ApplicantController(IApplicantService ApplicantService, Presenter presenter) : base(presenter)
        {
            _ApplicantService = ApplicantService;
        }

        #endregion

        #region Actions
        [HttpGet]
        [MapToApiVersion(APIVersion.Version1)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseResultDto<List<ApplicantOutputDTO>>))]
        public async Task<IActionResult> GetAll() => await _Presenter.Handle(_ApplicantService.GetAll);

        [HttpGet]
        [MapToApiVersion(APIVersion.Version1)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseResultDto<ApplicantOutputDTO>))]
        public async Task<IActionResult> GetById(int? applicantId)
        {
            ApplicantOutputDTO model = new ApplicantOutputDTO();

            if (applicantId != null)
                return await _Presenter.Handle(_ApplicantService.GetById, new BaseRequestDto<int>
                {
                    Data = applicantId.Value
                });

            return Ok(model);
        }

        [HttpPost]
        [MapToApiVersion(APIVersion.Version1)]
        public async Task<IActionResult> CreateOrUpdate(BaseRequestDto<ApplicantInputDTO> applicantInputDTO) =>
            await _Presenter.Handle(_ApplicantService.SaveApplicant,  applicantInputDTO );

        [HttpDelete]
        [MapToApiVersion(APIVersion.Version1)]
        public async Task<IActionResult> Delete(int applicantId) =>
            await _Presenter.Handle(_ApplicantService.DeleteById, new BaseRequestDto<int> { Data = applicantId });



        #endregion
    }
}
