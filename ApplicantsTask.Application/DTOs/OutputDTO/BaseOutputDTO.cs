using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicantsTask.Application.DTOs.OutputDTO
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
