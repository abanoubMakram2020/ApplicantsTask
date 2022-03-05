using System.ComponentModel.DataAnnotations;

namespace ApplicantsTask.Domain.Entities
{
    public class Applicant : BaseEntity<int>
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string FamilyName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string CountryOfOrigion { get; set; }

        [Required]
        [MaxLength(50)]
        public string EmailAddress { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public bool Hired { get; set; }

        //[ForeignKey("CreatedBy")]
        //public User CreationUser { get; set; }
        //[ForeignKey("ModifiedBy")]
        //public User ModificationUser { get; set; }
    }
}
