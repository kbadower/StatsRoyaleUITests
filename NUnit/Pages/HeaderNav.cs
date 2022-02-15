using Framework.Selenium;
using OpenQA.Selenium;
using System;

namespace Royale.Pages
{
    public class HeaderNav
    { 
        public readonly HeaderNavMap Map;

        public HeaderNav()
        {
            Map = new HeaderNavMap();
        }
        public void GoToCardsPage()
        {
            Map.CardsTabLink.Click();
        }

        public void GoToDeckBuilderPage()
        {
            Map.DeckBuilderLink.Click();
        }
    }

    public class HeaderNavMap
    { 
        public Element CardsTabLink => Driver.FindElement(By.CssSelector("a[href='/cards']"), "Cards Tab Link");
        public Element DeckBuilderLink => Driver.FindElement(By.CssSelector("a[href='/deckbuilder']"), "Deck Builder Link");
    }
}
