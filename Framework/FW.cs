using Framework.Logging;
using NUnit.Framework;
using System;
using System.IO;

namespace Framework
{
    public class FW
    {
        public static string WORKSPACE_DIRECTORY = Path.GetFullPath(@"../../../");

        [ThreadStatic]
        public static DirectoryInfo CurrentTestDirectory;

        [ThreadStatic]
        private static Logger _logger;

        public static Logger Log => _logger ?? throw new NullReferenceException("_logger is null.");

        public static DirectoryInfo CreateTestResultsDirectory()
        {
            var testDirectory = WORKSPACE_DIRECTORY + "/TestResults";

            if (Directory.Exists(testDirectory))
            {
                Directory.Delete(testDirectory, recursive: true);
            }

            return Directory.CreateDirectory(testDirectory);
        }

        public static void SetLogger()
        {
            lock (_setLoggerLock)
            {
                var testResultsDir = WORKSPACE_DIRECTORY + "/testResults";
                var testName = TestContext.CurrentContext.Test.Name;
                var fullpath = $"{testResultsDir}/{testName}";

                if (Directory.Exists(fullpath))
                {
                     CurrentTestDirectory = Directory.CreateDirectory(fullpath + TestContext.CurrentContext.Test.ID);
                }
                else
                {
                    CurrentTestDirectory = Directory.CreateDirectory(fullpath);
                }

                _logger = new Logger(testName, CurrentTestDirectory.FullName + "/log.txt");
            }
        }

        private static object _setLoggerLock = new object();
    }
}
