using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumMobileTests
{
    public class AppiumMobileTests
    {
        private AndroidDriver<AndroidElement> driver;
        private AppiumOptions options;
        private const string appLocation = @"C:\AppDemos_QA_FrontEnd\com.android.example.github.apk";
        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";

        [SetUp]
        public void PrepareApp()
        {
            this.options = new AppiumOptions() { PlatformName = "Android"};
            options.AddAdditionalCapability("app", appLocation);
            this.driver = new AndroidDriver<AndroidElement>(new Uri(appiumServer), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromTicks(10);

        }

        [TearDown]
        public void CloseApp()
        {
            driver.Quit();
        }

        [Test]
        public void Test_SearchForKeyWord()
        {
            var searchField = driver.FindElementById("com.android.example.github:id/input");
            
            searchField.Click();
            searchField.SendKeys("Selenium");

            //hit Enter
            driver.PressKeyCode(AndroidKeyCode.Enter);

            Thread.Sleep(5000);

            var seleniumText = driver.FindElementByXPath("//android.view.ViewGroup/android.widget.TextView[2]");
            Assert.That(seleniumText.Text, Is.EqualTo("SeleniumHQ/selenium"));

            seleniumText.Click();
            Thread.Sleep(5000);

            var barancevLine = driver.FindElementByXPath("//android.widget.FrameLayout[2]/android.view.ViewGroup/android.widget.TextView");
            Assert.That(barancevLine.Text, Is.EqualTo("barancev"), "barancev is in the list");

            barancevLine.Click();
            Thread.Sleep(5000);

            var barancevName = driver.FindElementByXPath("//android.widget.TextView[@content-desc='user name']");
            Assert.That(barancevName.Text, Is.EqualTo("Alexei Barantsev"));
        }
       
    }
}