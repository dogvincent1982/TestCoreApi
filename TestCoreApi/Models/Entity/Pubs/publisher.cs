using System.Collections.Generic;

namespace TestCoreApi.Models.Entity.Pubs
{
    public partial class publisher
    {
        public publisher()
        {
            employees = new HashSet<employee>();
            titles = new HashSet<Title>();
        }

        public string pub_id { get; set; }
        public string pub_name { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }

        public virtual pub_info pub_info { get; set; }
        public virtual ICollection<employee> employees { get; set; }
        public virtual ICollection<Title> titles { get; set; }
    }
}
