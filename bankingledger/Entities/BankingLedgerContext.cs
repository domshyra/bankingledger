using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace BankingLedger.Entities
{
    public partial class BankingLedgerContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, IdentityUserClaim<Guid>, ApplicationUserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        private string connectionString;

        public BankingLedgerContext()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false);

            var configuration = builder.Build();

            connectionString = configuration.GetConnectionString("DefaultConnection").ToString();
        }

        public BankingLedgerContext(DbContextOptions<BankingLedgerContext> options)
            : base(options)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false);

            var configuration = builder.Build();

            connectionString = configuration.GetConnectionString("DefaultConnection").ToString();
        }


        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            
            
        }
    }
}
