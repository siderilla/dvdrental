using Microsoft.Extensions.Configuration;

namespace dvdrental
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(AppContext.BaseDirectory)
            //    .AddJsonFile("appConfig.json") //guardare properties di appConfig.json
            //    .Build();

            //var connectionString = configuration.GetConnectionString("postgres");//.GetSection("ConnectionStrings")["pippodb"];
            //Console.WriteLine($"Connection String: {connectionString}");

            Console.WriteLine(AppConfig.GetConnectionString());
        }
    }
}
