namespace TestCoreApi.Models.Entity.Pubs
{
    public partial class roysched
    {
        public string title_id { get; set; }
        public int? lorange { get; set; }
        public int? hirange { get; set; }
        public int? royalty { get; set; }

        public virtual Title title { get; set; }
    }
}
