using Microsoft.Extensions.Configuration;
using System;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightDotNet.Utilities
{
    public class Configuration
    {
        private Configuration()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true)
                //.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("TEST_ENVIRONMENT")}.json", true)
                .Build();
            configuration.Bind(this);
        }
        public static readonly Configuration Instance = new();
        public TestParameters TestParameters { get; set; }
        public string UrlPath { get; set; }
        
        
    }
}
