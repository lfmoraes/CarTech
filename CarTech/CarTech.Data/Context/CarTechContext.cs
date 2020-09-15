using CarTech.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarTech.Data.Context
{
    public class CarTechContext : IdentityDbContext
    {
        public CarTechContext(DbContextOptions<CarTechContext> options)
            : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public override DbSet<IdentityUser> Users { get; set; }
    }
}

