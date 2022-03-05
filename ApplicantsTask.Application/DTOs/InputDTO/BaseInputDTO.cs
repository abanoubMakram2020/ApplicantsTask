using System;

namespace ApplicantsTask.Application.DTOs.InputDTO
{
    public class BaseInputDTO<T>
    {
        public T Id { get; set; }
        //public DateTime CreationDate { get; set; }
        //public DateTime? ModificationDate { get; set; }
        //public int CreatedBy { get; set; } = 1;
        //public int? ModifiedBy { get; set; } = 1;
    }
}
