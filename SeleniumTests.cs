using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
    public class SeleniumTests
    {

        private WebDriver driver;
        private const string baseUrl = "https://shorturl-1.itsageorgieva.repl.co/";

        [SetUp]
        public void OpenWebApp()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.Url = baseUrl;
        }

        [TearDown]
        public void CloseWebApp()
        {
            driver.Quit();
        }

        [Test]
        public void Test_TableTopLeftCell()
        {
            //Navigate to ShortURL page
            var linkShortUrl = driver.FindElement(By.LinkText("Short URLs"));
            linkShortUrl.Click();

            var tableHeaderLeftCell = driver.FindElement(By.CssSelector("th:nth-child(1)"));

            Assert.That(tableHeaderLeftCell.Text, Is.EqualTo("Original URL"));
        }

        [Test]
        public void Test_AddValidUrl()
        {
            var urlToAdd = "http://url" + DateTime.Now.Ticks + ".com";

            //Navigate to Add URL page
            var linkAddUrl = driver.FindElement(By.LinkText("Add URL"));
            linkAddUrl.Click();

            var urlInput = driver.FindElement(By.Id("url"));
            urlInput.SendKeys(urlToAdd);

            var buttonCreate = driver.FindElement(By.XPath("//button[@type='submit']"));
            buttonCreate.Click();

            Assert.That(driver.PageSource.Contains(urlToAdd));

            var tableLastRow = driver.FindElements(By.CssSelector("table > tbody > tr")).Last();
            var tableLastRowFirstCell = tableLastRow.FindElements(By.CssSelector("td")).First();

            Assert.That(tableLastRowFirstCell.Text, Is.EqualTo(urlToAdd));

        }

        [Test]
        public void Test_AddInvalidUrl()
        {

            //Navigate to Add URL page
            var linkAddUrl = driver.FindElement(By.LinkText("Add URL"));
            linkAddUrl.Click();

            var urlInput = driver.FindElement(By.Id("url"));
            urlInput.SendKeys("alabala");

            var buttonCreate = driver.FindElement(By.XPath("//button[@type='submit']"));
            buttonCreate.Click();

            var labelErrorMessage = driver.FindElement(By.XPath("//div[@class='err']"));

            Assert.That(labelErrorMessage.Text, Is.EqualTo("Invalid URL!"));

            Assert.True(labelErrorMessage.Displayed);

        }

        [Test]
        public void Test_VisitNonExistingURL()
        {
            driver.Url = "http://shorturl.nakov.repl.co/go/invalid536524";

            var labelErrorMessage = driver.FindElement(By.XPath("//div[@class='err']"));

            Assert.That(labelErrorMessage.Text, Is.EqualTo("Cannot navigate to given short URL"));

            Assert.True(labelErrorMessage.Displayed);

        }

        [Test]
        public void Test_CounterIncreases()
        {

            //Navigate to Short URLs page
            var linkShortUrls = driver.FindElement(By.XPath("//a[@href='/urls']"));
            linkShortUrls.Click();

            var tableFirstRow = driver.FindElements(By.CssSelector("table > tbody > tr")).First();
            var tableFirstRowLastCell = tableFirstRow.FindElements(By.CssSelector("td")).Last();

            var oldCounter = int.Parse(tableFirstRowLastCell.Text);

            var linkToClickCell = tableFirstRow.FindElements(By.CssSelector("td"))[1];
            var linkToClick = linkToClickCell.FindElement(By.TagName("a"));
            linkToClick.Click();

            driver.SwitchTo().Window(driver.WindowHandles[0]);

            driver.Navigate().Refresh();

            tableFirstRow = driver.FindElements(By.CssSelector("table > tbody > tr")).First();
            var newCounter = int.Parse(tableFirstRow.FindElements(By.CssSelector("td")).Last().Text);

            Assert.That(newCounter, Is.EqualTo(oldCounter + 1));

            //Assert.That(tableLastRowFirstCell.Text, Is.EqualTo(urlToAdd));

        }

    }
}