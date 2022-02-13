using Framework;
using Framework.Selenium;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Royale.Pages
{
    public class DeckBuilderPage : PageBase
    {
        public readonly DeckBuilderPageMap Map;

        public DeckBuilderPage()
        {
            Map = new DeckBuilderPageMap();
        }

        public DeckBuilderPage Goto()
        {
            FW.Log.Step("Clicking Deck Builder link");
            HeaderNav.Map.DeckBuilderLink.Click();
            Driver.Wait.Until(drvr => Map.AddCardsManuallyLink.Displayed);
            return this;
        }

        public void AddCardsManually()
        {
            FW.Log.Step("Clicking Add Cards Manually link");
            Map.AddCardsManuallyLink.Click();
            Driver.Wait.Until(drvr => Map.CopyDeckIcon.Displayed);
        }

        public void CopySuggestedDeck()
        {
            FW.Log.Step("Clicking Copy Deck icon");
            Map.CopyDeckIcon.Click();
        }
    }

    public class DeckBuilderPageMap
    {
        public IWebElement AddCardsManuallyLink => Driver.FindElement(By.XPath("//a[text()='add cards manually']"));

        public IWebElement CopyDeckIcon => Driver.FindElement(By.CssSelector(".copyButton"));
    }
}
