using System;

namespace ApplicantsTask.Presentation.MVC.DTOs.OutputDTOs
{
    public class BaseOutputDTO<T>
    {
        public T Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
