using ApplicantsTask.Presentation.MVC.DTOs.InputDTOs;
using ApplicantsTask.Presentation.MVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApplicantsTask.Presentation.MVC.Controllers
{
    public class UserClientController : Controller
    {
        private readonly IUserClientService _userClientService;
        public UserClientController(IUserClientService userClientService)
        {
            _userClientService = userClientService;
        }

        [HttpGet]
        public async Task<IActionResult> Register() => View(new RegistrationDTO());


        [HttpPost]
        public async Task<IActionResult> Register(RegistrationDTO registrationDTO)
        {
            var (StatusCode, Message, Errors) = await _userClientService.Register(registrationDTO);
            return RedirectToAction(nameof(Login));
        }


        [HttpGet]
        public async Task<IActionResult> Login() => View(new LoginDTO());


        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var (TokenDTO, Message) = await _userClientService.Login(loginDTO);
            if (!string.IsNullOrWhiteSpace(TokenDTO.Token))
                return RedirectToAction("Index", "ApplicantClient", new { area = "" });
            return RedirectToAction(nameof(Login));
        }


    }
}
