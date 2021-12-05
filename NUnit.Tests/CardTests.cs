using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Royale.Pages;
using System.IO;

namespace NUnit.Tests
{
    public class CardTests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(Path.GetFullPath(@"../../../"))
            {
                Url = "https://statsroyale.com"
            };
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void ShouldDisplayIceSpiritCardOnCardsList()
        {
            // arrange
            var cardsPage = new CardsPage(driver);

            //act 
            var iceSpirit = cardsPage.Goto().GetCardByName("Ice Spirit");

            // assert
            Assert.That(iceSpirit.Displayed);
        }
         
        [Test]
        public void ShouldDisplayCorrectIceSpiritCardStats()
        {
            // arrange & act      
            new CardsPage(driver).Goto().GetCardByName("Ice Spirit").Click();
            var cardDetails = new CardDetailsPage(driver);

            var (category, arena) = cardDetails.GetCardCategory();
            var cardName = cardDetails.Map.CardName.Text;
            var cardRarity = cardDetails.Map.CardCategory.Text;

            // assert 
            Assert.That(cardName, Is.EqualTo("Ice Spirit"));
            Assert.That(category, Is.EqualTo("Troop"));
            Assert.That(arena, Is.EqualTo("Arena 8"));
            Assert.That(cardRarity, Is.EqualTo("Common"));
        }
    }
}