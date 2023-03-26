using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumCalcTestsPOM.Pages
{
    public class CalculatorPage
    {
        private WindowsDriver<WindowsElement> driver;
        public CalculatorPage(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
        }

        public WindowsElement FirstField => driver.FindElementByAccessibilityId("textBoxFirstNum");
        public WindowsElement SecondField => driver.FindElementByAccessibilityId("textBoxSecondNum");
        public WindowsElement ResultField => driver.FindElementByAccessibilityId("textBoxSum");
        public WindowsElement CalcButton => driver.FindElementByAccessibilityId("buttonCalc");

        public string CalculateTwoNumbers(string firstValue, string secondValue)
        {
            FirstField.Clear();
            SecondField.Clear();
            FirstField.SendKeys(firstValue);
            SecondField.SendKeys(secondValue);
            CalcButton.Click();

            return ResultField.Text;
        }
    }
}
