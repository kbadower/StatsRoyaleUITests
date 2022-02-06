using Framework.Models;
using Framework.Selenium;
using Framework.Services;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Royale.Pages;
using System.IO;

namespace NUnit.Tests
{
    public class CardTests
    {

        [SetUp]
        public void Setup()
        {
            Driver.Init();
            Pages.Init();
            Driver.Goto("https://statsroyale.com");
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Current.Quit();
        }

        [Test]
        public void ShouldDisplayIceSpiritCard()
        {
            // arrange & act
            var iceSpirit = Pages.Cards.Goto().GetCardByName("Ice Spirit");

            // assert
            Assert.That(iceSpirit.Displayed);
        }

        static string[] cardNames = { "Ice Spirit", "Mirror" };
        [Test, Category("Cards")]
        [TestCaseSource("cardNames")]
        [Parallelizable(ParallelScope.Children)]
        public void ShouldDisplayCardStats(string cardName)
        {
            // arrange & act      
            Pages.Cards.Goto().GetCardByName(cardName).Click();
            var cardOnPage = Pages.CardDetails.GetBaseCard();
            var card = new InMemoryCardService().GetCardByName(cardName);

            // assert 
            Assert.That(cardOnPage.Name, Is.EqualTo(card.Name));
            Assert.That(cardOnPage.Type, Is.EqualTo(card.Type));
            Assert.That(cardOnPage.Arena, Is.EqualTo(card.Arena));
            Assert.That(cardOnPage.Rarity, Is.EqualTo(card.Rarity));
        }
    }
}