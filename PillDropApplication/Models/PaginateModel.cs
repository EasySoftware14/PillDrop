using System.Collections.Generic;

namespace PillDropApplication.Models
{
    public class PaginateModel
    {
        public int sEcho { get; set; }
        public long iTotalRecords { get; set; }
        public long iTotalDisplayRecords { get; set; }
        public IList<string[]> aaData { get; set; }
    }
}