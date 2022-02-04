using APIDomain.Entities.User;
using APIInfra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIInfra.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        //public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        //{
        //    foreach (var entity in ChangeTracker.Entries().Where(x => x.Entity.GetType().GetProperty("CreateDate") != null && x.Entity.GetType().GetProperty("UpdateDate") != null))
        //    {
        //        if (entity.State == EntityState.Added)
        //        {
        //            entity.Property("CreateDate").CurrentValue = DateTime.Now;
        //            entity.Property("UpdateDate").IsModified = false;
        //        }
        //        if (entity.State == EntityState.Modified)
        //        {
        //            entity.Property("UpdateDate").CurrentValue = DateTime.Now;
        //            entity.Property("CreateDate").IsModified = false;
        //        }
        //    }

        //    return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(new UserMap().Configure);
        }
    }
}
