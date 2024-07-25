using CRUD_DB_Using_API.Model.Entitys;
using Microsoft.EntityFrameworkCore;

namespace CRUD_DB_Using_API.Model
{
    public class MakeConnection : DbContext
    {
        private static IConfiguration configuration;

        static MakeConnection()
        {
            configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("ConnectionStr"));
        }

        public DbSet<Employee> Employees { get; set; }
        
    }
}
