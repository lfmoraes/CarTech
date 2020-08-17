using CarTech.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarTech.Registration.Data.Context
{
    public class RegistrationDbContext : DbContext
    {
        public RegistrationDbContext(DbContextOptions options)
            : base (options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
