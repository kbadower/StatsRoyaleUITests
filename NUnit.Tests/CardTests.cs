using Framework;
using Framework.Models;
using Framework.Selenium;
using Framework.Services;
using NUnit.Framework;
using Royale.Pages;
using System.Collections.Generic;

namespace NUnit.Tests
{
    public class CardTests
    {
     
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            FW.CreateTestResultsDirectory();
        }

        [SetUp]
        public void Setup()
        {
            FW.SetLogger();
            Driver.Init();
            Pages.Init();
            Driver.Goto("https://statsroyale.com");
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        // alternative TestCaseSource
        static IList<Card> apiCards = new ApiCardService().GetAllCards();

        [Test, Category("Cards")]
        [TestCaseSource("apiCards")]
        [Parallelizable(ParallelScope.Children)]
        public void ShouldDisplayCardOnCardsPage(Card card)
        {
            // arrange & act
            var cardOnPage = Pages.Cards.Goto().GetCardByName(card.Name);

            // assert
            Assert.That(cardOnPage.Displayed);
        }

        [Test, Category("Cards")]
        [TestCaseSource("apiCards")]
        [Parallelizable(ParallelScope.Children)]
        public void ShouldDisplayCardStats(Card card)
        {
            // arrange & act      
            Pages.Cards.Goto().GetCardByName(card.Name).Click();
            var cardOnPage = Pages.CardDetails.GetBaseCard();

            // assert 
            Assert.That(cardOnPage.Name, Is.EqualTo(card.Name));
            Assert.That(cardOnPage.Type, Is.EqualTo(card.Type));
            Assert.That(cardOnPage.Arena, Is.EqualTo(card.Arena));
            Assert.That(cardOnPage.Rarity, Is.EqualTo(card.Rarity));
        }
    }
}