using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GUI.Models
{
    public partial class librarysystemdbContext : DbContext
    {
        public librarysystemdbContext()
        {
        }

        public librarysystemdbContext(DbContextOptions<librarysystemdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookDb> BookDbs { get; set; }
        public virtual DbSet<CategoryDb> CategoryDbs { get; set; }
        public virtual DbSet<PersonalDb> PersonalDbs { get; set; }
        public virtual DbSet<UserDb> UserDbs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:librarysystemdbserver.database.windows.net,1433;Initial Catalog=librarysystemdb;Persist Security Info=False;User ID=adminlb;Password=23jjf45A;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BookDb>(entity =>
            {
                entity.ToTable("bookDb");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Ddc)
                    .HasColumnType("decimal(20, 10)")
                    .HasColumnName("DDC");

                entity.Property(e => e.Isbn)
                    .HasMaxLength(17)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Publisher)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.BookDbs)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bookDb__Category__72C60C4A");
            });

            modelBuilder.Entity<CategoryDb>(entity =>
            {
                entity.ToTable("CategoryDb");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PersonalDb>(entity =>
            {
                entity.ToTable("personalDb");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("job_title");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.SocialSecurityNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("socialSecurityNumber");
            });

            modelBuilder.Entity<UserDb>(entity =>
            {
                entity.ToTable("userDb");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.LibraryCard).HasColumnName("library_card");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.SocialSecurityNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("socialSecurityNumber");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
