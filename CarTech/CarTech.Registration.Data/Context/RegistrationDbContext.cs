using CarTech.Domain.Models;
using CarTech.Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarTech.Registration.Data.Context
{
    public class RegistrationDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public RegistrationDbContext(DbContextOptions<RegistrationDbContext> options)
            : base (options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(o => {
                o.HasKey(ur => new { ur.UserId, ur.RoleId });
                o.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(r => r.RoleId).IsRequired();
                o.HasOne(ur => ur.User).WithMany(r => r.UserRoles).HasForeignKey(r => r.UserId).IsRequired();
            });
        }
    }
}
