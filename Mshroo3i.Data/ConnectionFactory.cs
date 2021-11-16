using Microsoft.Data.SqlClient;

namespace Mshroo3i.Data;

public static class ConnectionFactory
{
    public static SqlConnection CreateSqlConnection(string connectionString)
    {
        SqlAuthenticationProvider.SetProvider(
            SqlAuthenticationMethod.ActiveDirectoryDeviceCodeFlow, 
            new CustomAzureSqlAuthProvider());
        var sqlConnection = new SqlConnection(connectionString);
        return sqlConnection;
    }
}