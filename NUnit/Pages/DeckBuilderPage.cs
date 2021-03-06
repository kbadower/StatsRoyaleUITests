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
            HeaderNav.Map.DeckBuilderLink.Click();
            Driver.Wait.Until(drvr => Map.AddCardsManuallyLink.Displayed);
            return this;
        }

        public void AddCardsManually()
        {
            Map.AddCardsManuallyLink.Click();
            Driver.Wait.Until(drvr => Map.CopyDeckIcon.Displayed);
        }

        public void CopySuggestedDeck()
        {
            Map.CopyDeckIcon.Click();
        }
    }

    public class DeckBuilderPageMap
    {
        public Element AddCardsManuallyLink => Driver.FindElement(By.XPath("//a[text()='add cards manually']"), "Adds Cards Manually Link");

        public Element CopyDeckIcon => Driver.FindElement(By.CssSelector(".copyButton"), "Copy Deck Icon");
    }
}
