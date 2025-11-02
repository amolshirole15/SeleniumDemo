using OpenQA.Selenium;

namespace NunitTestProject
{
    public static class CustomMethods
    {
        public static void ClickElement(this IWebElement locator)
        {
            locator.Click();
        }

        public static void EnterText(this IWebElement locator, String text)
        {
            locator.Clear();
            locator.SendKeys(text);
        }

        public static void SubmitClick(this IWebElement locator)
        {
            locator.Submit();
        }
    }
}