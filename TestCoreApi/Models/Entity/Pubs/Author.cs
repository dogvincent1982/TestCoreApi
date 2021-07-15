using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApi.Models.Entity.Pubs
{
    [Table("author")]
    public class Author
    {
        public Author()
        {
            TitleAuthors = new HashSet<TitleAuthor>();
        }
        [Column("au_id")]
        public string AuthorID { get; set; }
        [Column("au_lname")]
        public string AuthorLastName { get; set; }
        [Column("au_fname")]
        public string AuthorFirstName { get; set; }
        [Column("phone")]
        public string Phone { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("city")]
        public string City { get; set; }
        [Column("state")]
        public string State { get; set; }
        [Column("zip")]
        public string Zip { get; set; }
        [Column("contract")]
        public bool Contract { get; set; }

        public virtual ICollection<TitleAuthor> TitleAuthors { get; set; }
    }
}
