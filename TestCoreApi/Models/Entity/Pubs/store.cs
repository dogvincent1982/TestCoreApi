using System.Collections.Generic;

namespace TestCoreApi.Models.Entity.Pubs
{
    public partial class store
    {
        public store()
        {
            sales = new HashSet<sale>();
        }

        public string stor_id { get; set; }
        public string stor_name { get; set; }
        public string stor_address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }

        public virtual ICollection<sale> sales { get; set; }
    }
}
