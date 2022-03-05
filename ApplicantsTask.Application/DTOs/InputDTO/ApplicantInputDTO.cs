namespace ApplicantsTask.Application.DTOs.InputDTO
{
    public class ApplicantInputDTO : BaseInputDTO<int>
    {
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Address { get; set; }
        public string CountryOfOrigion { get; set; }
        public string EmailAddress { get; set; }
        public int Age { get; set; }
        public bool? Hired { get; set; }
    }
}
