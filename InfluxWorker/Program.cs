using InfluxWorker;
using InfluxWorker.Examples;
using Microsoft.Extensions.Configuration;

Console.WriteLine("Start...");

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
    .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: false)
    .Build();
    
var config = new Config(configuration);

while (true)
{
    RandomValues.Run(config);
    await Task.Delay(1000);
}

Console.WriteLine("Finish.");    