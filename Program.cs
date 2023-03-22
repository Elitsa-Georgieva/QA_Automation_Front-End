using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace SeleniumWebDriverDemo
{
    public class Program
    {
        static void Main()
        {
            // create browser instance
            var driver = new ChromeDriver();
            //var driver = new FirefoxDriver();
            //var driver = new EdgeDriver();

            // navigate to Wikipedia
            driver.Url = "https://wikipedia.org";

            // Get browser Title
            var pageTitle = driver.Title;
            Console.WriteLine($"The page title is: {pageTitle}");

            if(pageTitle == "Wikipedia")
            {
                Console.WriteLine("TEST PASS");
            }
            else
            {
                Console.WriteLine("TEST FAIL");
            }

            //close browser
            driver.Quit();

        }
    }
}