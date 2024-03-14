using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Persistence.Context
{
    public class EcommerceContextDesingTimeDbContextFactory  : IDesignTimeDbContextFactory<EcommerceContext>
    {
        public EcommerceContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WebApi"))
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile("appsettings.Development.json", optional: true)
               .Build();

            var optionsBuilder = new DbContextOptionsBuilder<EcommerceContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("SqlEcommerce"));

            return new EcommerceContext(optionsBuilder.Options);
        }
    }
}

