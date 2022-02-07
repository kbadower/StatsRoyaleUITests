
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace Framework.Selenium
{
    public static class Driver
    {
        [ThreadStatic]
        private static IWebDriver _driver;

        public static void Init()
        {
            var options = new ChromeOptions();
            options.AddArgument("headless");
            _driver = new ChromeDriver(Path.GetFullPath(@"../../../"), options);
        }

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null.");
    }
}
