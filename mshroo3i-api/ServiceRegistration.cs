using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Mshroo3i.Data;

namespace mshroo3i_api;

public static class ServiceRegistration
{
    public static IServiceCollection RegisterServices(this IServiceCollection collection, ConfigurationManager configuration)
    {
        collection.AddControllers();
        
        var connectionString = configuration.GetConnectionString("Mshroo3iDb");
        var sqlConnection = ConnectionFactory.CreateSqlConnection(connectionString);
        collection.AddDbContext<ApplicationContext>(options =>
        {
            options.UseSqlServer(sqlConnection, sqlOptions => { sqlOptions.EnableRetryOnFailure(10); });
            options.LogTo(Console.WriteLine);
        });
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        collection.AddEndpointsApiExplorer();
        collection.AddSwaggerGen();

        collection.AddHealthChecks();

        collection.Configure<JsonOptions>(opt =>
        {
            opt.SerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            opt.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });

        collection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return collection;
    }
}