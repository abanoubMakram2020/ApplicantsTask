using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernal.Middlewares.Basees
{
    public class BaseRequestDto<TRequest>
    {
        public TRequest Data { get; set; }
    }


}
