using Framework;
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
            FW.Log.Step("Opening Google Play.");
            Map.AppStoreButton.Click();
        }

        public void OpenGooglePlay()
        {
            AcceptCookies();
            FW.Log.Step("Opening Google Play.");
            Map.GooglePlayButton.Click();
        }

        public void AcceptCookies()
        {
            FW.Log.Step("Accepting cookies.");
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
