using DevTestBackend.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace DevTestBackend.Entities.Data
{
    public partial class DevTestBackendContext : DbContext
    {
        private readonly IConfiguration _configuration; 

        public DevTestBackendContext(DbContextOptions<DevTestBackendContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<Perfil> Perfils { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));           
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
