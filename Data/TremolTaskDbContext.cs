namespace Administration.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Administration.Data.Models.Base;

    public class AdministrationDbContext : DbContext
    {

        public AdministrationDbContext(DbContextOptions<AdministrationDbContext> options)
            :base(options)
        {

        }


        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
            base.OnModelCreating(modelBuilder);
        }


        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAudtitInformation();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            this.ApplyAudtitInformation();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void ApplyAudtitInformation()
            => this.ChangeTracker
                .Entries()
                .ToList()
                .ForEach(entry =>
                {

                    var entityy = entry.Entity;
                    if (entry.Entity is IDeletableEntity deletableEntity)
                    {
                        if (entry.State == EntityState.Deleted)
                        {
                            deletableEntity.IsDeleted = true;
                            deletableEntity.DeletedOn = DateTime.UtcNow;
                            entry.State = EntityState.Modified;
                            return;
                        }
                    }

                    if (entry.Entity is IEntity entity)
                    {
                        if (entry.State == EntityState.Added)
                        {
                            entity.CreatedOn = DateTime.Now;
                        }
                        else if (entry.State == EntityState.Modified)
                        {
                            entity.ModifiedOn = DateTime.Now;
                        }
                    }
                });
    }
}
