using SharedKernal.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.Middlewares.ResourcesReader.Message
{
    public interface IMessageResourceReader
    {
        string GetMessage(ResponseStatusCode responseStatus);
        string GetMessage(string messageKey);
        string GetValidationMessage(string messageKey);
    }
}
