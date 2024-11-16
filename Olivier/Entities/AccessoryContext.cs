using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Olivier.Folder
{
    public class AccessoryContext : DbContext
    {

        private readonly IConfiguration _configuration;
        public AccessoryContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
        }
        public DbSet<Accessory> Accessories { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Gadget> Gadgets { get; set; }
    }
}
