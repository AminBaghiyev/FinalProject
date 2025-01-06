using Microsoft.Extensions.Configuration;

namespace FinalProject.DL.Utilities;

public class Connection
{
    public static string GetConnectionString(string key = "local")
    {
        ConfigurationManager configurationManager = new();
        configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "FinalProject.API"));
        configurationManager.AddJsonFile("appsettings.json");

        return
            configurationManager.GetConnectionString(key) ??
            throw new Exception("Connection string not found!");
    }
}
