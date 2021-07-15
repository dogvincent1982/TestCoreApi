using System;

namespace TestCoreApi.Models.Entity.Pubs
{
    public partial class sale
    {
        public string stor_id { get; set; }
        public string ord_num { get; set; }
        public DateTime ord_date { get; set; }
        public short qty { get; set; }
        public string payterms { get; set; }
        public string title_id { get; set; }

        public virtual store stor { get; set; }
        public virtual Title title { get; set; }
    }
}
