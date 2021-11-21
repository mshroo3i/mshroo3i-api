using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Mshroo3i.Data
{
    class ContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var sqlConnection = ConnectionFactory.CreateSqlConnection(ApplicationContext.ConnectionString);
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(sqlConnection, options =>
            {
                options.EnableRetryOnFailure();
            });

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
