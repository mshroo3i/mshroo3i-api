using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Mshroo3i.Data
{
    class ContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(ApplicationContext.ConnectionString, options =>
            {
                options.EnableRetryOnFailure();
            });

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
