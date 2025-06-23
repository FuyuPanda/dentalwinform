using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentaSoft
{
    public class AppConfig
    {
        public static IConfigurationRoot Configuration { get; private set; }

        static AppConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public static string ConnectionString =>
            Configuration.GetConnectionString("DefaultConnection");
    }
}
