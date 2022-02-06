using Framework.Selenium;
using OpenQA.Selenium;

namespace Royale.Pages
{
    public class CardsPage : PageBase
    {
        public readonly CardsPageMap Map;

        public CardsPage()
        {
            Map = new CardsPageMap();
        }

        public IWebElement GetCardByName(string cardName)
        {
            if(cardName.Contains(" "))
            {
                cardName = cardName.Replace(" ", "+");
            }
            return Map.Card(cardName);
        }

        public CardsPage Goto()
        {
            HeaderNav.GoToCardsPage();
            return this;
        }
    }


    public class CardsPageMap
    {
        public IWebElement Card(string name) => Driver.FindElement(By.CssSelector($"a[href*='{name}']"));
    }
}

 