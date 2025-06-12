using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DamascusComplaintSystem.Api.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // Retrieve the connection string from the configuration file
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())  
                .AddJsonFile("appsettings.json")              
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Use DbContext options to configure the SQL Server connection
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            // Return a new DbContext instance using the configured options
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
