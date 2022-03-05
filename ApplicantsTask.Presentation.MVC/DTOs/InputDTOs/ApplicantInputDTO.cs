using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApplicantsTask.Presentation.MVC.DTOs.InputDTOs
{
    public class ApplicantInputDTO : BaseInputDTO<int>
    {
        [Required]
        [Display(Name = "Name")]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [Display(Name="Family Name")]
        [StringLength(50, MinimumLength = 5)]
        public string FamilyName { get; set; }

        [Required]
        [Display(Name = "Address")]
        [StringLength(50, MinimumLength = 10)]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Country Of Origion")]
        [StringLength(50, MinimumLength = 1)]
        public string CountryOfOrigion { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [StringLength(50, MinimumLength = 8)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$|^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}", ErrorMessage = "Please enter a valid email address ")]
        public string EmailAddress { get; set; }

        [Required]
        [Range(20, 60)]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Hired")]
        public bool Hired { get; set; }
    }
}
