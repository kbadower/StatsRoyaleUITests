
using Framework.Selenium;
using OpenQA.Selenium;

namespace Royale.Pages
{
    public class DownloadPage : PageBase
    {
        public readonly DownloadPageMap Map;

        public DownloadPage()
        {
            Map = new DownloadPageMap();
        }

        public void OpenAppStore()
        {
            AcceptCookies();
            Map.AppStoreButton.Click();
        }

        public void OpenGooglePlay()
        {
            AcceptCookies();
            Map.GooglePlayButton.Click();
        }

        public void AcceptCookies()
        {
            Map.AcceptCookiesButton.Click();
            Driver.Wait.Until(drvr => !Map.AcceptCookiesButton.Displayed);
        }
    }

    public class DownloadPageMap
    {
        public IWebElement AppStoreButton => Driver.FindElement(By.XPath("//a[text()='App Store']"));

        public IWebElement GooglePlayButton => Driver.FindElement(By.XPath("//a[text()='Google Play']"));

        public IWebElement AcceptCookiesButton => Driver.FindElement(By.CssSelector("a.cc-btn.cc-dismiss"));

    }
}
