using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.Common.Enum
{
    public class ResourceEnum
    {
        public enum LocalizationType
        {

            [EnumMessage("ValidationMessage_{0}")]
            ValidationMessage = 1,
            [EnumMessage("Messages_{0}")]
            Message = 2,

        }
    }
}