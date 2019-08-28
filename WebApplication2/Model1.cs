namespace WebApplication2
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersAndBooks> UsersAndBooks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Authors>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Authors>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Authors)
                .HasForeignKey(e => e.AuthorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Books>()
                .Property(e => e.Title)
                .IsUnicode(false);


            modelBuilder.Entity<Users>()
                .HasMany(e => e.UsersAndBooks)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Books>()
                .HasMany(e => e.UsersAndBooks)
                .WithRequired(e => e.Books)
                .HasForeignKey(e => e.IdBook)
                .WillCascadeOnDelete(false);
        }
    }
}
