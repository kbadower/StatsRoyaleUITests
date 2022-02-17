using Framework;
using Framework.Selenium;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Royale.Tests.Base
{
    public abstract class TestBase
    {

        [OneTimeSetUp]
        public virtual void BeforeAll()
        {
            FW.SetConfig();
            FW.CreateTestResultsDirectory();
        }

        [SetUp]
        public virtual void BeforeEach()
        {
            FW.SetLogger();
            Driver.Init();
            Pages.Pages.Init();
            Driver.Goto(FW.Config.Test.Url);
        }

        [TearDown]
        public virtual void AfterEach()
        {
            var testOutcome = TestContext.CurrentContext.Result.Outcome.Status;

            if (testOutcome == TestStatus.Passed)
            {
                FW.Log.Info("Test outcome: PASSED");
            }
            else if (testOutcome == TestStatus.Failed)
            {
                Driver.TakeScreenshot("test_failed");
                FW.Log.Info("Test outcome: FAILED");
            }
            else
            {
                FW.Log.Warning($"Test outcome: {testOutcome}");
            }
            Driver.Quit();
        }

    }
}
