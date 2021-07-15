namespace TestCoreApi.Models.Entity.Pubs
{
    public partial class pub_info
    {
        public string pub_id { get; set; }
        public byte[] logo { get; set; }
        public string pr_info { get; set; }

        public virtual publisher pub { get; set; }
    }
}
