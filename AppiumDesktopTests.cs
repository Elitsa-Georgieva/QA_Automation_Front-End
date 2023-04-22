using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace AppiumDesktopTests
{
    public class AppiumDesktopTests
    {
        private WindowsDriver<WindowsElement> driver;
        private AppiumOptions options;

        private const string appLocation = @"D:\softuni\QA_Automation_FrontEnd\ExamPrep\ShortURL-DesktopClient-v1.0.net6\\ShortURL-DesktopClient.exe";
        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";
        private const string appServer = "https://shorturl-1.itsageorgieva.repl.co/api";

        [SetUp]
        public void PrepareApp()
        {
            this.options = new AppiumOptions();
            options.AddAdditionalCapability("app", appLocation);
            driver = new WindowsDriver<WindowsElement>(new Uri(appiumServer), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void CloseApp()
        {
            driver.Close();
        }

        [Test]
        public void Test_AddNewUrl()
        {
            var urlToAdd = "http://url" + DateTime.Now.Ticks + ".com";

            var inputAppUrl = driver.FindElementByAccessibilityId("textBoxApiUrl");
            inputAppUrl.Clear();
            inputAppUrl.SendKeys(appServer);

            var buttonConnect = driver.FindElementByAccessibilityId("buttonConnect");
            buttonConnect.Click();

            var buttonAdd = driver.FindElementByAccessibilityId("buttonAdd");
            buttonAdd.Click();

            var textBoxURL = driver.FindElementByAccessibilityId("textBoxURL");
            textBoxURL.SendKeys(urlToAdd);

            var buttonCreate = driver.FindElementByAccessibilityId("buttonCreate");
            buttonCreate.Click();

            var linkCreatedField = driver.FindElementByName(urlToAdd);

            //Assert.IsNotEmpty(linkCreatedField.Text);
            Assert.That(linkCreatedField.Text, Is.EqualTo(urlToAdd));

        }
    }
}