using Microsoft.Extensions.Configuration;
using System.IO;

namespace ConsoleApp1.Classes;

public static class ConfigurationHelper
{
    public static IConfigurationRoot GetConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddUserSecrets<Program>()
            .Build();
    }

    public static string GetConnectionString()
    {
        var config = GetConfiguration();
        var env = config["ConnectionsConfiguration:ActiveEnvironment"] ?? "Development";
        return config[$"ConnectionsConfiguration:{env}"];
    }
}
