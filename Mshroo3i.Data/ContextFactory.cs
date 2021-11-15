using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Mshroo3i.Data
{
    class ContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            SqlAuthenticationProvider.SetProvider(
                SqlAuthenticationMethod.ActiveDirectoryDeviceCodeFlow, 
                new CustomAzureSqlAuthProvider());
            var sqlConnection = new SqlConnection(ApplicationContext.ConnectionString);
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(sqlConnection, options =>
            {
                options.EnableRetryOnFailure();
            });

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
