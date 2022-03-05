using SharedKernal.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.Middlewares.ResourcesReader.Message
{
    public class MessageResourceReader : FileReader, IMessageResourceReader
    {
        public string GetMessage(ResponseStatusCode responseStatus) => GetKeyValue(key: responseStatus.ToString());
        public string GetMessage(string messageKey) => GetKeyValue(key: messageKey);
        public string GetValidationMessage(string messageKey) => GetValidationKeyValue(key: messageKey);
    }
}
