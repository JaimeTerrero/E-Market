using E_Market.Domain.Common;
using EMarket.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EMarket.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public override Task<int> SaveChangesAsync (CancellationToken cancellationToken = new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "DefaultAppUser";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModied = DateTime.Now;
                        entry.Entity.LastModiedBy = "DefaultAppUser";
                        break;
                }
            }

            return base.SaveChangesAsync (cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // FLUENT API

            #region tables
            modelBuilder.Entity<Article>().ToTable("Articles");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<User>().ToTable("Users");
            #endregion

            #region "primary keys"
            modelBuilder.Entity<Article>().HasKey(article => article.Id);
            modelBuilder.Entity<Category>().HasKey(category => category.Id);
            modelBuilder.Entity<User>().HasKey(user => user.Id);
            #endregion

            #region "relationships"
            modelBuilder.Entity<Category>()
                .HasMany<Article>(category => category.Articles)
                .WithOne(article => article.Category)
                .HasForeignKey(article => article.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany<Article>(user => user.Articles)
                .WithOne(article => article.User)
                .HasForeignKey(article => article.UserId)
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

            #region users
            modelBuilder.Entity<User>().Property(user => user.UserName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(user => user.Password).IsRequired();
            modelBuilder.Entity<User>().Property(user => user.Name).HasMaxLength(150).IsRequired();
            modelBuilder.Entity<User>().Property(user => user.LastName).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<User>().Property(user => user.Email).HasMaxLength(150).IsRequired();
            modelBuilder.Entity<User>().Property(user => user.Phone).HasMaxLength(150).IsRequired();
            #endregion

            #endregion
        }
    }
}
