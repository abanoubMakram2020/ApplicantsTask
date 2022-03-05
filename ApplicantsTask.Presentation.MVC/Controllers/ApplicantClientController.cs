using ApplicantsTask.Presentation.MVC.DTOs.InputDTOs;
using ApplicantsTask.Presentation.MVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedKernal.Common.Enum;
using System.Threading.Tasks;

namespace ApplicantsTask.Presentation.MVC.Controllers
{
    public class ApplicantClientController : BaseController
    {
        private readonly IApplicantClientService _applicantClientService;
        public ApplicantClientController(IApplicantClientService applicantClientService)
        {
            _applicantClientService = applicantClientService;
        }
        public async Task<IActionResult> Index()
        {
            var (Applicants, Message) = await _applicantClientService.GetAll();
            return View(Applicants);
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrUpdate(int? applicantId)
        {
            ApplicantInputDTO applicantModel = new ApplicantInputDTO();
            if (applicantId is not null)
            {
                var (Applicant, Message) = await _applicantClientService.GetById(applicantId);

                applicantModel.Id = Applicant.Id;
                applicantModel.Name = Applicant.Name;
                applicantModel.FamilyName = Applicant.FamilyName;
                applicantModel.Address = Applicant.Address;
                applicantModel.CountryOfOrigion = Applicant.CountryOfOrigion;
                applicantModel.Age = Applicant.Age;
                applicantModel.EmailAddress = Applicant.EmailAddress;
                applicantModel.Hired = Applicant.Hired;

            }

            return View(applicantModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate(ApplicantInputDTO applicantInputDTO)
        {
            var (StatusCode, Message, Errors) = await _applicantClientService.Save(applicantInputDTO);
            if (StatusCode == (int)ResponseStatusCode.Successfully)
                return RedirectToAction(nameof(Index));
            return RedirectToAction(nameof(CreateOrUpdate), new { applicantId = applicantInputDTO.Id });
        }

        public async Task<IActionResult> Delete(int applicantId)
        {
            var (Result, Message) = await _applicantClientService.Delete(applicantId);
            return RedirectToAction(nameof(Index));
        }
    }
}
