using Blog.DataAccess.Configurations;
using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Blog.DataAccess
{
    public class BlogContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            var rates = new List<Rates>
            {
                new Rates
                {
                    Id = 1,
                    Rate = 1
                },
                new Rates
                {
                    Id = 2,
                    Rate = 2
                },
                new Rates
                {
                    Id = 3,
                    Rate = 3
                },
                new Rates
                {
                    Id = 4,
                    Rate = 4
                },
                new Rates
                {
                    Id = 5,
                    Rate = 5
                },

            };

            modelBuilder.Entity<Users>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Articles>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Comments>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Categories>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Images>().HasQueryFilter(x => !x.IsDeleted);

            modelBuilder.Entity<Rates>().HasData(rates);
            modelBuilder.ApplyConfiguration(new UsersConfigurations());
            modelBuilder.ApplyConfiguration(new ArticlesConfigurations());
            modelBuilder.ApplyConfiguration(new CommentsConfigurations());
            modelBuilder.ApplyConfiguration(new CategoriesConfigurations());
            modelBuilder.ApplyConfiguration(new ImagesConfigurations());
            modelBuilder.ApplyConfiguration(new RatesConfigurations());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.IsActive = true;
                            e.CreatedAt = DateTime.Now;
                            e.IsDeleted = false;
                            e.ModifiedAt = null;
                            e.DeletedAt = null;
                            break;
                        case EntityState.Modified:
                            e.ModifiedAt = DateTime.Now;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-9T8EKM5\SQLEXPRESS01;Initial Catalog=BlogASP;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Articles> Articles { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Rates> Rates { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<ArticleCategories> ArticleCategories { get; set; }
        public DbSet<ArticlesImages> ArticlesImages { get; set; }
        public DbSet<ArticlesRates> ArticlesRates { get; set; }
        public DbSet<UserUseCases> UserUseCases { get; set; }
        public DbSet<UseCaseLogs> UseCaseLogs { get; set; }



    }
}
