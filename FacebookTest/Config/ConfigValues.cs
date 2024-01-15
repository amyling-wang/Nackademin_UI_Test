using Microsoft.Extensions.Configuration;

namespace FacebookTest.Config
{
    public class ConfigValues
    {
        private static IConfigurationRoot _configuration = new ConfigurationBuilder().Build();
        private static string url;
        private static string username;
        private static string password;
        public static void LoadConfiguration()
        {
            //var enviromentName = Environment.GetEnvironmentVariable("ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("secrets.json")
                .AddJsonFile("appsettings.json");
               // .AddJsonFile($"appsettings.{enviromentName}.json", true);
            _configuration = builder.Build();            

        }
        public static string Url 
        {  
            get 
            {
                if (string.IsNullOrEmpty(url))
                {
                    url = _configuration.GetSection("AppSettings:url").Value;
                }
                return url; 
            } 
            set { url = value; }
        }
        public static string Username
        {
            get
            {
                if (string.IsNullOrEmpty(username))
                {
                    username = _configuration.GetSection("USERNAME").Value;
                }
                return username;
            }
        }
        public static string Password
        {
            get
            {
                if (string.IsNullOrEmpty(password))
                {
                    password = _configuration.GetSection("PASSWORD").Value;
                }
                return password;
            }
        }
    }
}
