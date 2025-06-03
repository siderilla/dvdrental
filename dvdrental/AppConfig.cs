using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvdrental
{
    //internal static class AppConfig
    //{
    //    //public static string? GetConnectionString() //normalmente le statiche non hanno costruttore ma in c# posso fare un costruttore statico
    //    //{
    //    //    var configuration = new ConfigurationBuilder()
    //    //        .SetBasePath(AppContext.BaseDirectory)
    //    //        .AddJsonFile("appConfig.json")
    //    //        .Build();
    //    //    return configuration.GetConnectionString("postgres");
    //    //}

    //}

    internal class AppConfig
    {
        public static IConfiguration Configuration { get; set; }

        static AppConfig()
        {
            if (Configuration == null)
            {
                Configuration = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appConfig.json")
                    .Build();
            }
        }
        public static string? GetConnectionString() { //così lo legge solo una volta
            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(AppContext.BaseDirectory)
            //    .AddJsonFile("appConfig.json")
            //    .Build();
            return Configuration.GetConnectionString("postgres");
        }

    }
}
