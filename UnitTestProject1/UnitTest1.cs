using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { get; set; }

        private static TestContext _testContext;

        [ClassInitialize]
        public static void SetupTests(TestContext testContext)
        {
            _testContext = testContext;
        }
        [TestMethod]
        public void TestMethod1()
        {
           string p= TestContext.Properties["applicationpath"].ToString();
            //var applicationDirectory = TestContext.TestRunDirectory;
            //Console.WriteLine(applicationDirectory);

            var applicationPath = Path.Combine(p, "WpfApp1.exe");
            Application application = Application.Launch(applicationPath);
            Window window = application.GetWindow("MainWindow", InitializeOption.NoCache);
            TextBox tb= window.Get<TextBox>("textBox");
            Button button = window.Get<Button>("button");
            button.Click();
            application.Close();


        }
    }
}
