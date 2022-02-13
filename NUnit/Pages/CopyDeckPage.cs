using Framework;
using Framework.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Royale.Pages
{
    public class CopyDeckPage
    {
        public readonly CopyDeckPageMap Map;

        public CopyDeckPage()
        {
            Map = new CopyDeckPageMap();
        }

        public CopyDeckPage Yes()
        {
            FW.Log.Step("Clicking Yes.");
            Map.YesButton.Click();
            Driver.Wait.Until(drvr => Map.DeckCopiedMessage.Displayed);
            return this;
        }

        public CopyDeckPage No()
        {
            FW.Log.Step("Clicking No.");
            Map.NoButton.Click();
            Driver.Wait.Until(drvr => Map.DownloadSection.Displayed);
            AcceptCookies();
            return this;
        }

        public void GoToDownloadPage()
        {
            FW.Log.Step("Clicking Download Page link.");
            Map.DownloadPageLink.Click();
        }

        public void AcceptCookies()
        {
            Map.AcceptCookiesButton.Click();
            Driver.Wait.Until(drvr => !Map.AcceptCookiesButton.Displayed);
        }
    }

    public class CopyDeckPageMap
    {
        public IWebElement YesButton => Driver.FindElement(By.Id("button-open"));

        public IWebElement NoButton => Driver.FindElement(By.Id("not-installed"));

        public IWebElement DeckCopiedMessage => Driver.FindElement(By.CssSelector(".notes-active"));

        public IWebElement DownloadSection => Driver.FindElement(By.Id("app-download"));

        public IWebElement DownloadPageLink => Driver.FindElement(By.XPath("//a[text()='App Store']"));

        public IWebElement AcceptCookiesButton => Driver.FindElement(By.CssSelector("a.cc-btn.cc-dismiss"));
    }
}
