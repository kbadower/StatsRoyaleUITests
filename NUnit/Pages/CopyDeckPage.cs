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
            Map.YesButton.Click();
            Driver.Wait.Until(drvr => Map.DeckCopiedMessage.Displayed);
            return this;
        }

        public CopyDeckPage No()
        {
            Map.NoButton.Click();
            Driver.Wait.Until(drvr => Map.DownloadSection.Displayed);
            AcceptCookies();
            return this;
        }

        public void GoToDownloadPage()
        {
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
        public Element YesButton => Driver.FindElement(By.Id("button-open"), "Yes");

        public Element NoButton => Driver.FindElement(By.Id("not-installed"), "No");

        public Element DeckCopiedMessage => Driver.FindElement(By.CssSelector(".notes-active"), "Deck Copied Message");

        public Element DownloadSection => Driver.FindElement(By.Id("app-download"), "Download Section");

        public Element DownloadPageLink => Driver.FindElement(By.XPath("//a[text()='App Store']"), "Download Page Link");

        public Element AcceptCookiesButton => Driver.FindElement(By.CssSelector("a.cc-btn.cc-dismiss"), "Accept Cookies Button");
    }
}
