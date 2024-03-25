using Microsoft.Extensions.Configuration;

namespace FacebookTest.Config
{
    public class ConfigValues
    {
        private static IConfigurationRoot _configuration = new ConfigurationBuilder().Build();
        private static string? url;
        //private static string browser;
        //private static string username;
        //private static string password;
        public static void LoadConfiguration()
        {
            //var enviromentName = Environment.GetEnvironmentVariable("ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
              //  .AddJsonFile("secrets.json")
                .AddJsonFile("appsettings.json");
               // .AddJsonFile($"appsettings.{enviromentName}.json", true);
            _configuration = builder.Build();            

        }
        public static string? Url 
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
        private static int Timeout;
        public int PageLoadTiemout()
        {
            if (_configuration != null && _configuration.GetSection("AppSettings:pageLoadTimeout").Exists())
            {
                Timeout = Convert.ToInt32(_configuration.GetSection("AppSettings:pageLoadTimeout").Value) * 1000;
            }
            else if (Timeout == 0)
            {
                throw new ApplicationException("Browser pageload timeout cannot be '0'");
            }

            return Timeout;
        }
        public static string? Browser => _configuration.GetSection("AppSettings:browserToUse").Value;
        //public static string Username
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(username))
        //        {
        //            username = _configuration.GetSection("USERNAME").Value;
        //        }
        //        return username;
        //    }
        //}
        //public static string Password
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(password))
        //        {
        //            password = _configuration.GetSection("PASSWORD").Value;
        //        }
        //        return password;
        //    }
        //}
    }
}
