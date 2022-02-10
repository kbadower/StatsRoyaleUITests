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

        [Test, Category("CopyDeck")]
        public void ShouldCopyDeck()
        {
            // Act
            Pages.DeckBuilder.Goto().AddCardsManually();
            Pages.DeckBuilder.CopySuggestedDeck();
            Pages.CopyDeck.Yes();

            // Assert
            Assert.That(Pages.CopyDeck.Map.DeckCopiedMessage, Is.Not.Empty);
        }

        [Test, Category("CopyDeck")]
        public void ShouldOpenAppStore()
        {
            // Act
            Pages.DeckBuilder.Goto().AddCardsManually();
            Pages.DeckBuilder.CopySuggestedDeck();
            Pages.CopyDeck.No().GoToDownloadPage();
            Pages.Download.OpenAppStore();

            // Assert - constraint model
            Assert.That(Driver.Title, Is.EqualTo("Clash Royale on the App Store"));
        }

        [Test, Category("CopyDeck")]
        public void ShouldOpenGooglePlay()
        {
            Pages.DeckBuilder.Goto().AddCardsManually();
            Pages.DeckBuilder.CopySuggestedDeck();
            Pages.CopyDeck.No().GoToDownloadPage();
            Pages.Download.OpenGooglePlay();

            // Assert - classic model
            Assert.AreEqual("Clash Royale - Apps on Google Play", Driver.Title);
        }
    }
}
