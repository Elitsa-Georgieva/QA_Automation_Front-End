using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DataDrivenWebDriverTests
{
    public class DataDrivenTests
    {
        private WebDriver driver;
        

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test_NakovPageTitle()
        {
            driver.Url = "https://shorturl.softuniqa.repl.co/urls";
            var pageTitle = driver.FindElement(By.CssSelector("body > main > h1")).Text;
            var expected = "Short URLs";

            Assert.That(pageTitle,Is.EqualTo(expected));

            var expected1 = "https://nakov.com";
            var allTableCells = driver.FindElements(By.CssSelector("table tr > td"));

            var actual = allTableCells[0].Text;
            StringAssert.Contains(expected1, actual);

            var actual2 = allTableCells[1].Text;
            var expected2 = "http://shorturl.softuniqa.repl.co/go/nak";

            StringAssert.Contains(expected2, actual2);
        }
    }
}