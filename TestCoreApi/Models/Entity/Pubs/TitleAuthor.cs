using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApi.Models.Entity.Pubs
{
    [Table("titleauthor")]
    public partial class TitleAuthor
    {
        [Column("au_id")]
        public string AuthID { get; set; }
        [Column("title_id")]
        public string TitleID { get; set; }
        [Column("au_ord")]
        public byte? AuthOrder { get; set; }
        [Column("royaltyper")]
        public int? RoyalTyper { get; set; }

        public virtual Author Author { get; set; }
        public virtual Title Title { get; set; }
    }
}
