using FacebookTest.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookTest.Utilities
{
    internal class Driver
    {
        private static IWebDriver? driver;
       
        public static IWebDriver GetWebDriver()
        {
            return driver = new ChromeDriver();
        }
    }
}
