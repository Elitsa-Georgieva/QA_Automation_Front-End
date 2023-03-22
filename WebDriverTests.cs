using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SeleniumWebDriverNUnitDemo
{
    public class WebDriverTests
    {
        private WebDriver driver;

        [SetUp]
        public void OpenBrowser()
        {
            this.driver = new ChromeDriver();
        }

        [TearDown]
        public void CloseBrowser()
        {
            this.driver.Quit();
        }

        [Test]
        public void Test_Wikipedia_CheckTitle()
        {
            driver.Url = "https://wikipedia.org";

            var pageTitle = driver.Title;

            Assert.That("Wikipedia", Is.EqualTo(pageTitle));

        }

        [Test]
        public void Test_Wikipedia_SearchField()
        {
            driver.Url = "http://wikipedia.org";

            var searchField = driver.FindElement(By.Id("searchInput"));
            searchField.SendKeys("QA" + Keys.Enter);

            var pageTitle = driver.Title;
        }

        [Test]
        public void Test_AddTwoNumbers_Valid()
        {
            driver.Url = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";

            driver.FindElement(By.CssSelector("#number1")).SendKeys("15");

            driver.FindElement(By.Id("operation")).SendKeys("+");

            driver.FindElement(By.CssSelector("#number2")).SendKeys("7");

            driver.FindElement(By.Id("calcButton")).Click();

            var resultBox = driver.FindElement(By.Id("result")).Text;

            Assert.That(resultBox, Is.EqualTo("Result: 22"));
        }

        [Test]
        public void Test_AddTwoNumbers_Invalid()
        {
            driver.Url = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";

            driver.FindElement(By.CssSelector("#number1")).SendKeys("15");

            driver.FindElement(By.Id("operation")).SendKeys("+");

            driver.FindElement(By.CssSelector("#number2")).SendKeys("string");

            driver.FindElement(By.Id("calcButton")).Click();

            var resultBox = driver.FindElement(By.Id("result")).Text;

            Assert.That(resultBox, Is.EqualTo("Result: invalid input"));
        }
    }
}