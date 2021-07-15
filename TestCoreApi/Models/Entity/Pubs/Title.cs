using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApi.Models.Entity.Pubs
{
    [Table("title")]
    public partial class Title
    {
        public Title()
        {
            Sales = new HashSet<sale>();
            TitleAuthors = new HashSet<TitleAuthor>();
        }

        [Column("title_id")]
        public string TitleID { get; set; }
        [Column("title1")]
        public string Title1 { get; set; }
        [Column("type")]
        public string Type { get; set; }
        [Column("pub_id")]
        public string PubID { get; set; }
        [Column("price")]
        public decimal? Price { get; set; }
        [Column("advance")]
        public decimal? Advance { get; set; }
        [Column("royalty")]
        public int? Royalty { get; set; }
        [Column("ytd_sales")]
        public int? Ytd_Sales { get; set; }
        [Column("notes")]
        public string Notes { get; set; }
        [Column("pubdate")]
        public DateTime PubDate { get; set; }

        public virtual publisher Publisher { get; set; }
        public virtual ICollection<sale> Sales { get; set; }
        public virtual ICollection<TitleAuthor> TitleAuthors { get; set; }
    }
}
