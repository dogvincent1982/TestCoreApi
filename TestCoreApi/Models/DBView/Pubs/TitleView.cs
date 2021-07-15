using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApi.Models.DBView.Pubs
{
    [Table("titleview")]
    public partial class TitleView
    {
        public string title { get; set; }
        public byte? au_ord { get; set; }
        public string au_lname { get; set; }
        public decimal? price { get; set; }
        public int? ytd_sales { get; set; }
        public string pub_id { get; set; }
    }
}
