using System;

namespace ApplicantsTask.Presentation.MVC.DTOs.OutputDTOs
{
    public class TokenDTO
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime TokenExpirationDateTime { get; set; }
    }
}
