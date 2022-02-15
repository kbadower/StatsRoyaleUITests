using Framework.Models;
using Framework.Selenium;
using OpenQA.Selenium;
using System.Linq;

namespace Royale.Pages
{
    public class CardDetailsPage : PageBase
    {

        public readonly CardDetailsPageMap Map;

        public CardDetailsPage()
        {
            Map = new CardDetailsPageMap();
        }

        public (string Category, string Arena) GetCardCategory()
        {
            var categories = Map.CardCategory.Text.Split(',');
            return (categories[0].Trim(), categories[1].Trim());
        }

        public Card GetBaseCard()
        {
            var (category, arena) = GetCardCategory();

            return new Card
            {
                Name = Map.CardName.Text,
                Rarity = Map.CardRarity.Text.Split('\n').Last(),
                Type = category,
                Arena = arena
            };
        }
    }

    public class CardDetailsPageMap
    {
        public Element CardName => Driver.FindElement(By.CssSelector("[class*='cardName']"), "Card Name");
        public Element CardRarity => Driver.FindElement(By.CssSelector("[class*='card__rarity']"), "Card Rarity");
        public Element CardCategory => Driver.FindElement(By.CssSelector("[class*='rarityCaption']"), "Card Category");
    }
}
