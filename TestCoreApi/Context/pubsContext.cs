using Microsoft.EntityFrameworkCore;
using TestCoreApi.Models.DBView.Pubs;
using TestCoreApi.Models.Entity.Pubs;

namespace TestCoreApi.Context
{
    public partial class pubsContext : DbContext
    {
        public pubsContext()
        {
        }

        public pubsContext(DbContextOptions<pubsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<discount> discounts { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<job> jobs { get; set; }
        public virtual DbSet<pub_info> pub_infos { get; set; }
        public virtual DbSet<publisher> publishers { get; set; }
        public virtual DbSet<roysched> royscheds { get; set; }
        public virtual DbSet<sale> sales { get; set; }
        public virtual DbSet<store> stores { get; set; }
        public virtual DbSet<Title> titles { get; set; }
        public virtual DbSet<TitleAuthor> TitleAuthors { get; set; }
        public virtual DbSet<TitleView> TitleViews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.AuthorID)
                    .HasName("UPKCL_auidind");

                entity.HasIndex(e => new { e.AuthorLastName, e.AuthorFirstName }, "aunmind");

                entity.Property(e => e.AuthorID)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AuthorFirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AuthorLastName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('UNKNOWN')")
                    .IsFixedLength(true);

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Zip)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<discount>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.discount1)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("discount");

                entity.Property(e => e.discounttype)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.stor_id)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.stor)
                    .WithMany()
                    .HasForeignKey(d => d.stor_id)
                    .HasConstraintName("FK__discounts__stor___3B75D760");
            });

            modelBuilder.Entity<employee>(entity =>
            {
                entity.HasKey(e => e.emp_id)
                    .HasName("PK_emp_id")
                    .IsClustered(false);

                entity.ToTable("employee");

                entity.HasIndex(e => new { e.lname, e.fname, e.minit }, "employee_ind")
                    .IsClustered();

                entity.Property(e => e.emp_id)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.fname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.hire_date)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.job_id).HasDefaultValueSql("((1))");

                entity.Property(e => e.job_lvl).HasDefaultValueSql("((10))");

                entity.Property(e => e.lname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.minit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.pub_id)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('9952')")
                    .IsFixedLength(true);

                entity.HasOne(d => d.job)
                    .WithMany(p => p.employees)
                    .HasForeignKey(d => d.job_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__employee__job_id__47DBAE45");

                entity.HasOne(d => d.pub)
                    .WithMany(p => p.employees)
                    .HasForeignKey(d => d.pub_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__employee__pub_id__4AB81AF0");
            });

            modelBuilder.Entity<job>(entity =>
            {
                entity.HasKey(e => e.job_id)
                    .HasName("PK__jobs__6E32B6A5C3432A42");

                entity.Property(e => e.job_desc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('New Position - title not formalized yet')");
            });

            modelBuilder.Entity<pub_info>(entity =>
            {
                entity.HasKey(e => e.pub_id)
                    .HasName("UPKCL_pubinfo");

                entity.ToTable("pub_info");

                entity.Property(e => e.pub_id)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.logo).HasColumnType("image");

                entity.Property(e => e.pr_info).HasColumnType("text");

                entity.HasOne(d => d.pub)
                    .WithOne(p => p.pub_info)
                    .HasForeignKey<pub_info>(d => d.pub_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pub_info__pub_id__4316F928");
            });

            modelBuilder.Entity<publisher>(entity =>
            {
                entity.HasKey(e => e.pub_id)
                    .HasName("UPKCL_pubind");

                entity.Property(e => e.pub_id)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.city)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.country)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('USA')");

                entity.Property(e => e.pub_name)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.state)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<roysched>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("roysched");

                entity.HasIndex(e => e.title_id, "titleidind");

                entity.Property(e => e.title_id)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.title)
                    .WithMany()
                    .HasForeignKey(d => d.title_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__roysched__title___398D8EEE");
            });

            modelBuilder.Entity<sale>(entity =>
            {
                entity.HasKey(e => new { e.stor_id, e.ord_num, e.title_id })
                    .HasName("UPKCL_sales");

                entity.HasIndex(e => e.title_id, "titleidind");

                entity.Property(e => e.stor_id)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ord_num)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.title_id)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.ord_date).HasColumnType("datetime");

                entity.Property(e => e.payterms)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.stor)
                    .WithMany(p => p.sales)
                    .HasForeignKey(d => d.stor_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sales__stor_id__36B12243");

                entity.HasOne(d => d.title)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.title_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sales__title_id__37A5467C");
            });

            modelBuilder.Entity<store>(entity =>
            {
                entity.HasKey(e => e.stor_id)
                    .HasName("UPK_storeid");

                entity.Property(e => e.stor_id)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.city)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.state)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.stor_address)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.stor_name)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.zip)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.HasKey(e => e.TitleID)
                    .HasName("UPKCL_titleidind");

                entity.HasIndex(e => e.Title1, "titleind");

                entity.Property(e => e.TitleID)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Advance).HasColumnType("money");

                entity.Property(e => e.Notes)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.PubID)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PubDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Title1)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('UNDECIDED')")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.titles)
                    .HasForeignKey(d => d.PubID)
                    .HasConstraintName("FK__titles__pub_id__2D27B809");
            });

            modelBuilder.Entity<TitleAuthor>(entity =>
            {
                entity.HasKey(e => new { e.AuthID, e.TitleID })
                    .HasName("UPKCL_taind");

                entity.ToTable("titleauthor");

                entity.HasIndex(e => e.AuthID, "auidind");

                entity.HasIndex(e => e.TitleID, "titleidind");

                entity.Property(e => e.AuthID)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.TitleID)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.TitleAuthors)
                    .HasForeignKey(d => d.AuthID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__titleauth__au_id__30F848ED");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.TitleAuthors)
                    .HasForeignKey(d => d.TitleID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__titleauth__title__31EC6D26");
            });

            modelBuilder.Entity<TitleView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("titleview");

                entity.Property(e => e.au_lname)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.price).HasColumnType("money");

                entity.Property(e => e.pub_id)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.title)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
