using System.Collections.Generic;

namespace SharedKernal.PagingModule
{
    public class Paging
    {
        public Paging()
        {
            OrderColumns = new List<OrderColumn>();
        }

        public Search Search { get; set; }
        public List<OrderColumn> OrderColumns { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
    }
}
