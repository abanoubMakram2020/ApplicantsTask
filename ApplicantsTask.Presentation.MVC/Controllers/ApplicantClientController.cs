using ApplicantsTask.Presentation.MVC.DTOs.InputDTOs;
using ApplicantsTask.Presentation.MVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

                applicantModel = new ApplicantInputDTO
                {
                    Id = Applicant.Id,
                    Name = Applicant.Name,
                    FamilyName = Applicant.FamilyName,
                    Address = Applicant.Address,
                    CountryOfOrigion = Applicant.CountryOfOrigion,
                    Age = Applicant.Age,
                    EmailAddress = Applicant.EmailAddress,
                    Hired = Applicant.Hired,

                };
            }

            return View(applicantModel);

        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(ApplicantInputDTO applicantInputDTO)
        {
            var (StatusCode, Message,Errors) = await _applicantClientService.Save(applicantInputDTO);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int applicantId)
        {
            var (Result, Message) = await _applicantClientService.Delete(applicantId);
            return RedirectToAction(nameof(Index));
        }
    }
}
