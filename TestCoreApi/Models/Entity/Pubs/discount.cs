namespace TestCoreApi.Models.Entity.Pubs
{
    public partial class discount
    {
        public string discounttype { get; set; }
        public string stor_id { get; set; }
        public short? lowqty { get; set; }
        public short? highqty { get; set; }
        public decimal discount1 { get; set; }

        public virtual store stor { get; set; }
    }
}
