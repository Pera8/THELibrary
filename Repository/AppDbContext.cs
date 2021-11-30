using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
               .HasKey(x => new { x.Id });
            modelBuilder.Entity<Book>()
                .HasOne(x => x.Author)
                .WithMany(x => x.BooksList)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Book>()
               .HasKey(x => new { x.Id });
            modelBuilder.Entity<Book>()
                .HasOne(x => x.Category)
                .WithMany(x => x.BooksList)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Category>()
            //   .HasKey(x => new { x.Id });
            //modelBuilder.Entity<Category>()
            //    .HasOne(x => x.Id)
            //    .WithMany(x => x.BooksList)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
        //entities
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
