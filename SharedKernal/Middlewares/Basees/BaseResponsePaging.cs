using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedKernal.Middlewares.Basees
{
    public class BaseResponsePaging<TResult>
    {
        public List<TResult> Result { get; set; }
        public int Draw { get; set; }
        public int RecordsFiltered { get; set; }
        public int RecordsTotal { get; set; }
    }
}
