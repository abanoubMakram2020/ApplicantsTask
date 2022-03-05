using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicantsTask.Application.DTOs.OutputDTO
{
    public class UserOutputDTO:BaseOutputDTO<int>
    {
        public UserOutputDTO()
        {
            Applicants = new List<ApplicantOutputDTO>();
        }

        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<ApplicantOutputDTO> Applicants { get; set; }
    }
}
