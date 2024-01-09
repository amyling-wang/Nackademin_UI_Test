using Microsoft.Extensions.Configuration;

namespace FacebookTest.Config
{
    public class ConfigValues
    {
        private static IConfigurationRoot _configuration = new ConfigurationBuilder().Build();
        private static string _url;
        private static string _username;
        private static string _password;
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
                if (string.IsNullOrEmpty(_url))
                {
                    _url = _configuration.GetSection("AppSettings:url").Value;
                }
                return _url; 
            } 
            set { _url = value; }
        }
        public static string Username
        {
            get
            {
                if (string.IsNullOrEmpty(_username))
                {
                    _username = _configuration.GetSection("USERNAME").Value;
                }
                return _username;
            }
        }
        public static string Password
        {
            get
            {
                if (string.IsNullOrEmpty(_password))
                {
                    _password = _configuration.GetSection("PASSWORD").Value;
                }
                return _password;
            }
        }
    }
}
