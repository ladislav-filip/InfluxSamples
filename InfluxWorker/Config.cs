using Microsoft.Extensions.Configuration;

namespace InfluxWorker;

public class Config
{
    private readonly IConfiguration _configuration;

    public Config(IConfiguration configuration) => _configuration = configuration;
    
    public string InfluxUrl => _configuration["InfluxUrl"];
    public string Password => _configuration["Password"];
    public string Username => _configuration["Username"];
    public string Database => _configuration["Database"];
}