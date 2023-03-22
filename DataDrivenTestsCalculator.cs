using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Data;

namespace DataDrivenWebDriverTestsCalculator
{
    public class DataDrivenTestsCalculator
    {
        private WebDriver driver;
        private const string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";


        IWebElement firstInput;
        IWebElement operationField;
        IWebElement secondInput;
        IWebElement calcButton;
        IWebElement resetButton;

        [SetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = BaseUrl;

            firstInput = driver.FindElement(By.Id("number1"));
            operationField = driver.FindElement(By.Id("operation"));
            secondInput = driver.FindElement(By.Id("number2"));
            calcButton = driver.FindElement(By.Id("calcButton"));
            resetButton = driver.FindElement(By.Id("resetButton"));

        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }

        [TestCase("10", "+", "2", "Result: 12")]
        [TestCase("-10", "+", "-2", "Result: -12")]
        [TestCase("10", "*", "2", "Result: 20")]
        [TestCase("-10", "*", "-2", "Result: 20")]
        [TestCase("10", "-", "2", "Result: 8")]
        [TestCase("-10", "-", "-2", "Result: -8")]
        [TestCase("10", "/", "2", "Result: 5")]
        [TestCase("-10", "/", "-2", "Result: 5")]
        [TestCase("-10", "/", "aaa", "Result: invalid input")]
        [TestCase("1", "+", "Infinity", "Result: infinity")]
        public void Test_Calculator_SumTwoPositiveNumbers(string firstNum, string operation, 
            string secondNum, string expectedResult)
        {
            //Arrange
            resetButton.Click();
            firstInput.SendKeys(firstNum);

            operationField.SendKeys(operation);

            secondInput.SendKeys(secondNum);

            //Act
            calcButton.Click();

            //Assert
            var resultField = driver.FindElement(By.Id("result"));
            
            Assert.That(expectedResult, Is.EqualTo(resultField.Text));
        }
    }
}