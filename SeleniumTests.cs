

using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Data;

namespace SeleniumTests
{
    public class SeleniumTests
    {
        private WebDriver driver;
        private const string baseUrl = "https://taskboard--itsageorgieva.repl.co/";

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
        public void Test_TaskBoard_FirstDoneTaskTitle()
        {
            var taskBoardLink = driver.FindElement(By.LinkText("Task Board"));
            taskBoardLink.Click();

            var doneTasksTable = driver.FindElements(By.CssSelector("body > main > div > div"));
            var firstDoneTaskTable = doneTasksTable.Last();

            var firstDoneTaskTitle = firstDoneTaskTable.FindElement(By.CssSelector("tr.title > td"));


            Assert.That(firstDoneTaskTitle.Text, Is.EqualTo("Project skeleton"));


        }

        [Test]
        public void Test_SearchTask_ValidData()
        {
            var searchLink = driver.FindElement(By.LinkText("Search"));
            searchLink.Click();

            var searchInputField = driver.FindElement(By.Id("keyword"));
            searchInputField.SendKeys("home");

            var searchButton = driver.FindElement(By.Id("search"));
            searchButton.Click();

            var resultList = driver.FindElements(By.CssSelector("body > main > div.tasks-grid"));
            var firstResultTable = resultList.First();

            var firstResultCellTitle = firstResultTable.FindElement(By.CssSelector("tr.title > td"));
            Assert.That(firstResultCellTitle.Text, Is.EqualTo("Home page"));

        }

        [Test]
        public void Test_SearchTask_InvalidData()
        {
            var searchLink = driver.FindElement(By.LinkText("Search"));
            searchLink.Click();

            var keyword = "missing" + DateTime.Now.Ticks;
            var searchInputField = driver.FindElement(By.Id("keyword"));
            searchInputField.SendKeys(keyword);

            var searchButton = driver.FindElement(By.Id("search"));
            searchButton.Click();

            TimeSpan.FromSeconds(5);
            var searchResultLabel = driver.FindElement(By.Id("searchResult"));
            Assert.That(searchResultLabel.Text, Is.EqualTo("No tasks found."));

        }

        [Test]
        public void Test_CreateTask_InvalidData()
        {
            var createLink = driver.FindElement(By.LinkText("Create"));
            createLink.Click();

            var createButton = driver.FindElement(By.Id("create"));
            createButton.Click();

            //TimeSpan.FromSeconds(5);
            var errorTextLabel = driver.FindElement(By.XPath("//div[@class='err']"));
            Assert.That(errorTextLabel.Text, Is.EqualTo("Error: Title cannot be empty!"));
            Assert.True(errorTextLabel.Displayed);

        }

        [Test]
        public void Test_createcontacts_validData()
        {
            var createLink = driver.FindElement(By.LinkText("Create"));
            createLink.Click();

            var title = "Title" + DateTime.Now.Ticks;
            var description = "Some description " + DateTime.Now.Ticks;
            
            var titleInputField = driver.FindElement(By.Id("title"));
            var descriptionInputField = driver.FindElement(By.Id("description"));
            
            titleInputField.SendKeys(title);
            descriptionInputField.SendKeys(description);

            var createButton = driver.FindElement(By.Id("create"));
            createButton.Click();

            //timespan.fromseconds(5);

            var openTasksTable = driver.FindElements(By.CssSelector("body > main > div > div"));
            var lastOpenTaskTable = openTasksTable.First();

            var lastOpenTaskTitle = lastOpenTaskTable.FindElements(By.CssSelector("tbody > tr.title > td")).Last();

            Assert.That(lastOpenTaskTitle.Text, Is.EqualTo(title));

            


        }

    }
}