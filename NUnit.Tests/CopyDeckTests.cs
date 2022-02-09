using Framework.Selenium;
using NUnit.Framework;
using Royale.Pages;

namespace Nunit.Tests
{
    public class CopyDeckTests
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
        public void ShouldCopyDeck()
        {
            // Act
            Pages.DeckBuilder.Goto();
            Driver.Wait.Until(drvr => Pages.DeckBuilder.Map.AddCardsManuallyLink.Displayed);
            Pages.DeckBuilder.AddCardsManually();
            Driver.Wait.Until(drvr => Pages.DeckBuilder.Map.CopyDeckIcon.Displayed);
            Pages.DeckBuilder.CopySuggestedDeck();
            Pages.CopyDeck.Yes();

            // Assert
            Driver.Wait.Until(drvr => Pages.CopyDeck.Map.DeckCopiedMessage.Displayed);
            Assert.That(Pages.CopyDeck.Map.DeckCopiedMessage, Is.Not.Empty);
        }
    }
}
