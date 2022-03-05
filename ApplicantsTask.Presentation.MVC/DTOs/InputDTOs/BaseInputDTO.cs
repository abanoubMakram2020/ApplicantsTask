using System;

namespace ApplicantsTask.Presentation.MVC.DTOs.InputDTOs
{
    public class BaseInputDTO<T>
    {
        public T Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
