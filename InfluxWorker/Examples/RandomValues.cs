using InfluxDB.WriteOnly;

namespace InfluxWorker.Examples;

public static class RandomValues
{
    private static readonly Random Random = new();
    
    public static void Run(Config config)
    {
        var opt = new InfluxDbClientOptions
        {
            Login = new LoginInformation(config.Username, config.Password)
        };
        var client = new InfluxDbClient(new Uri(config.InfluxUrl), opt);
        
        client.WriteAsync(config.Database, new List<Point>
        {
            new()
            {
                Measurement = "my_value",
                Tags = new [] { new Tag("my_tag", "random") },
                Fields = new []
                {
                    new Field("value", Random.NextDouble() * 80.0),
                    new Field("value1", Random.NextDouble() * 100.0),
                },
                Timestamp = DateTime.UtcNow.AddMinutes(-5) // pokud potřebujete jiný čas, nastavte zde jako UTC
            }
        }).Wait();

    }
}