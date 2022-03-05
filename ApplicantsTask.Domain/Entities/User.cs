using System.Collections.Generic;

namespace ApplicantsTask.Domain.Entities
{
    public class User : BaseEntity<int>
    {
        //public User()
        //{
        //    Applicants = new List<Applicant>();
        //}

        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        //public List<Applicant> Applicants { get; set; }
    }
}
