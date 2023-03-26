

using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using AppiumCalcTestsPOM.Pages;

namespace AppiumCalcTestsPOM.Tests
{
    public class BaseTest
    {
        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";
        private const string appLocation = @"C:\Users\Elitsa\Desktop\softuni\QA_Automation_FrontEnd\Appium Desktop Testing\SummatorDesktopApp.exe";
        protected WindowsDriver<WindowsElement> driver;
        private AppiumOptions appiumOptions;
        private AppiumLocalService appiumLocalService;

        [SetUp]
        public void OpenApplication()
        {

            this.appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("app", appLocation);
            this.driver = new WindowsDriver<WindowsElement>(new Uri(appiumServer), appiumOptions);
            
        }

        [TearDown]
        public void CloseAplication()
        {
            driver.Quit();
        }
    }
}
