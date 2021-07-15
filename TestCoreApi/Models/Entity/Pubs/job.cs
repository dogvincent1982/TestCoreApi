using System.Collections.Generic;

namespace TestCoreApi.Models.Entity.Pubs
{
    public partial class job
    {
        public job()
        {
            employees = new HashSet<employee>();
        }

        public short job_id { get; set; }
        public string job_desc { get; set; }
        public byte min_lvl { get; set; }
        public byte max_lvl { get; set; }

        public virtual ICollection<employee> employees { get; set; }
    }
}
