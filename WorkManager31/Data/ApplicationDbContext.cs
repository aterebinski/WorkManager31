using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WorkManager31.Models;

namespace WorkManager31.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<WorkManager31.Models.Assignment> Assignment { get; set; }

        public DbSet<WorkManager31.Models.Client> Client { get; set; }

        public DbSet<WorkManager31.Models.Job> Job { get; set; }
        public DbSet<WorkManager31.Models.ClientGroup> ClientGroup { get; set; }
        public DbSet<WorkManager31.Models.ClientGroupElement> ClientGroupElement { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");
            builder.Entity<IdentityUser>(entity =>
            {
                entity.ToTable(name: "User");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
            builder.Entity<Client>()
                .HasMany(c=>c.ClientGroupElements)
                .WithOne(cge=>cge.Client)
                .HasForeignKey(cge => cge.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ClientGroup>()
                .HasMany(cg => cg.ClientGroupElements)
                .WithOne(cge => cge.ClientGroup)
                .HasForeignKey(cge => cge.ClientGroupId)
                .OnDelete(DeleteBehavior.ClientCascade);
                

            


        }

    }
}
