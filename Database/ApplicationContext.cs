using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options){}

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // FLUENT API

            #region tables
            modelBuilder.Entity<Article>().ToTable("Articles");
            modelBuilder.Entity<Category>().ToTable("Categories");
            #endregion

            #region "primary keys"
            modelBuilder.Entity<Article>().HasKey(article => article.Id);
            modelBuilder.Entity<Category>().HasKey(category => category.Id);
            #endregion

            #region "relationships"
            modelBuilder.Entity<Category>()
                .HasMany<Article>(category => category.Articles)
                .WithOne(article => article.Category)
                .HasForeignKey(article => article.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region "property configurations"

            #region articles
            modelBuilder.Entity<Article>().Property(article => article.Name).IsRequired();
            modelBuilder.Entity<Article>().Property(article => article.Price).IsRequired();
            #endregion

            #region categories
            modelBuilder.Entity<Category>().Property(article => article.Name).IsRequired().HasMaxLength(150);
            #endregion

            #endregion
        }
    }
}
