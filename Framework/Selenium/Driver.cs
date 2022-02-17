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

        [ThreadStatic]
        public static Wait Wait;

        public static void Init()
        {
            var options = new ChromeOptions();
            if (FW.Config.Driver.Headless == "true") options.AddArgument("headless");
            options.AddArgument("--start-maximized");
            _driver = DriverFactory.Build(FW.Config.Driver.Browser);
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

        public static void TakeScreenshot(string imageName)
        {
            var ss = ((ITakesScreenshot)Current).GetScreenshot();
            var ssFilename = Path.Combine(FW.CurrentTestDirectory.FullName, imageName);
            ss.SaveAsFile($"{ssFilename}.png", ScreenshotImageFormat.Png);
        }

        public static void Quit()
        {
            FW.Log.Info("Browser is closing.");
            Current.Quit();
            Current.Dispose();
        }

        public static Element FindElement(By by, string elementName)
        {
            return new Element(Current.FindElement(by), elementName)
            {
                FoundBy = by
            };
        }

        public static Elements FindElements(By by)
        {
            return new Elements(Current.FindElements(by))
            {
                FoundBy = by
            };
        }
    }
}
