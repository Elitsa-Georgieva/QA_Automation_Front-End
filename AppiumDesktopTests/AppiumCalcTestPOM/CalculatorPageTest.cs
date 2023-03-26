using NUnit.Framework;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using AppiumCalcTestsPOM.Pages;
using static System.Net.Mime.MediaTypeNames;

namespace AppiumCalcTestsPOM.Tests
{
    public class CalculatorPageTest : BaseTest
    {
        
        private CalculatorPage page;

        [SetUp]
        public void OpenApplication()
        { 
            this.page = new CalculatorPage(driver);
        }

        [TearDown]
        public void CloseAplication()
        {
            driver.Quit();
        }

        [Test]
        public void Test_TwoPositiveNumbers()
        {
            var result = page.CalculateTwoNumbers("5", "10");
            Assert.That(result, Is.EqualTo("15"));
        }
    }
}