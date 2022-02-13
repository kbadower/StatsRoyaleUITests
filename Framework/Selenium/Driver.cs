﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Framework.Selenium
{
    public static class Driver
    {
        [ThreadStatic]
        private static IWebDriver _driver;

        [ThreadStatic]
        public static Wait Wait;

        public static void Init()
        {
            FW.Log.Info("Browser: Chrome");
            var options = new ChromeOptions();
            // options.AddArgument("headless");
            _driver = new ChromeDriver(Path.GetFullPath(@"../../../"), options);
            Wait = new Wait(10);
        }

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null.");

        public static string Title => Current.Title;

        public static void Goto(string url)
        {
            if (!url.StartsWith("http"))
            {
                url = "http://" + url;
            }

            FW.Log.Info(url);
            Current.Navigate().GoToUrl(url);
        }

        public static void Quit()
        {
            FW.Log.Info("Browser is closing.");
            Current.Quit();
            Current.Dispose();
        }

        public static IWebElement FindElement(By by)
        {
            return Current.FindElement(by);
        }

        public static IList<IWebElement> FindElements(By by)
        {
            return Current.FindElements(by);
        }
    }
}
