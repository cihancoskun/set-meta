using System.Collections.Generic;

namespace SetMeta.Web.ViewModels
{
    public class PageViewModel<T> where T : BaseViewModel
    {
        public int PageNumber { get; set; }
        public int PageCount { get; set; }

        public long ItemCount { get; set; }

        public bool HasPrevPage { get; set; }
        public bool HasNextPage { get; set; }

        public List<T> Items { get; set; }
    }
}