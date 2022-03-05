using System.ComponentModel.DataAnnotations;

namespace ApplicantsTask.Presentation.MVC.DTOs.InputDTOs
{
    public class LoginDTO
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
