using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Service;

namespace AppiumCalculatorTests
{
    public class CalculatorTests
    {
        //private WebDriver driver;
        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";
        private const string appLocation = @"C:\Users\Elitsa\Desktop\softuni\QA_Automation_FrontEnd\Appium Desktop Testing\SummatorDesktopApp.exe";
        private WindowsDriver<WindowsElement> driver;
        private AppiumOptions appiumOptions;
        private AppiumLocalService appiumLocalService;

        [SetUp]
        public void OpenApplication()
        {
            //Start Appium using Desktop Appium Server
            this.appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("app", appLocation);
            appiumOptions.AddAdditionalCapability("PlatformName", "Windows");
            this.driver = new WindowsDriver<WindowsElement>(new Uri(appiumServer), appiumOptions);

            ////Start Appium using headless mode
            //this.appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            //appiumLocalService.Start();
            //this.appiumOptions = new AppiumOptions();
            //appiumOptions.AddAdditionalCapability("app", appLocation);
            //appiumOptions.AddAdditionalCapability("PlatformName", "Windows");
            //this.driver = new WindowsDriver<WindowsElement>(appiumLocalService, appiumOptions);



        }

        [OneTimeTearDown]
        public void CloseApplication()
        {
            driver.Quit();
        }

        [Test]
        public void Test_Sum_TwoPositiveNumbers()
        {
            //Thread.Sleep(10000);
            var firstField = driver.FindElementByAccessibilityId("textBoxFirstNum");
            var secondField = driver.FindElementByAccessibilityId("textBoxSecondNum");
            var resultField = driver.FindElementByAccessibilityId("textBoxSum");
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");

            //Act
            firstField.SendKeys("5");
            secondField.SendKeys("15");
            calcButton.Click();

            //Assert
            Assert.That(resultField.Text, Is.EqualTo("20"));

        }

        [Test]
        public void Test_Sum_InvalidInputs()
        {
            //Thread.Sleep(10000);
            var firstField = driver.FindElementByAccessibilityId("textBoxFirstNum");
            var secondField = driver.FindElementByAccessibilityId("textBoxSecondNum");
            var resultField = driver.FindElementByAccessibilityId("textBoxSum");
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");

            //Act
            firstField.SendKeys("alabala");
            secondField.SendKeys("15");
            calcButton.Click();

            //Assert
            Assert.That(resultField.Text, Is.EqualTo("error"));

        }
    }
}