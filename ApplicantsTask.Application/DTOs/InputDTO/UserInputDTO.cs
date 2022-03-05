﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicantsTask.Application.DTOs.InputDTO
{
    public class UserInputDTO : BaseInputDTO<int>
    {
        public UserInputDTO()
        {
            Applicants = new List<ApplicantInputDTO>();
        }

        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<ApplicantInputDTO> Applicants { get; set; }
    }
}
