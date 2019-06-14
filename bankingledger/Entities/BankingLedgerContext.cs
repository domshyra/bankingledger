using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace BankingLedger.Entities
{
    public partial class BankingLedgerDBContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, IdentityUserClaim<Guid>, ApplicationUserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        private string connectionString;

        public BankingLedgerDBContext()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false);

            var configuration = builder.Build();

            connectionString = configuration.GetConnectionString("DefaultConnection").ToString();
        }

        public BankingLedgerDBContext(DbContextOptions<BankingLedgerDBContext> options)
            : base(options)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false);

            var configuration = builder.Build();

            connectionString = configuration.GetConnectionString("DefaultConnection").ToString();
        }


        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Deposit> Deposits { get; set; }





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

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(key => key.Id);

                entity.ToTable("Account");

                entity.Property(e => e.Id);

                entity.Property(e => e.Name)
                    .HasMaxLength(255);

                entity.Property(e => e.Balance)
                    .HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.UserId);

            });

            modelBuilder.Entity<Deposit>(entity =>
            {
                entity.HasKey(key => key.Id);

                entity.ToTable("Deposit");

                entity.Property(e => e.Id);

                entity.Property(e => e.AccountId);

                entity.Property(e => e.Date)
                    .HasColumnType("datetime");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Deposits)
                    .HasForeignKey(d => d.AccountId);

            });

        }
    }
}
