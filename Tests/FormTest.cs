namespace NunitTestProject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class FormTest
{
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        //
    }
    [Test]
    public void FillForm()
    {
        // Create instance of selenium webDriver
        IWebDriver driver = new ChromeDriver();

        // Navigate to the URL
        driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
        // Maximize the window
        driver.Manage().Window.Maximize();

        // Find and fill the First Name field
        IWebElement firstNameField = driver.FindElement(By.Id("firstName"));
        firstNameField.SendKeys("Jane");

        // Find and fill the Last Name field
        IWebElement lastNameField = driver.FindElement(By.Id("lastName"));
        lastNameField.SendKeys("Doe");

        // Find and fill the Email field
        IWebElement emailField = driver.FindElement(By.Id("userEmail"));
        emailField.SendKeys("test@gmail.com");

        // Find and select the Gender
        IWebElement gender = driver.FindElement(By.CssSelector("label[for='gender-radio-1']"));
        gender.Click();

        // Find and file Phone Number field
        IWebElement mobileNoField = driver.FindElement(By.Id("userNumber"));
        mobileNoField.SendKeys("9876543210");

        // Date of Birth - open calendar input, clear and enter the desired date, then press Enter
        IWebElement dobInput = driver.FindElement(By.Id("dateOfBirthInput"));
        // dobInput.Click();
        // dobInput.Clear();
        // dobInput.SendKeys("15 May 1990"); // e.g. "15 May 1990" or "15 May 1990"
        // dobInput.SendKeys(Keys.Enter);

        string date = "15 May 1990";
        ((IJavaScriptExecutor)driver).ExecuteScript(@"
            var el = arguments[0], v = arguments[1];
            var nativeSetter = Object.getOwnPropertyDescriptor(window.HTMLInputElement.prototype, 'value').set;
            nativeSetter.call(el, v);
            el.dispatchEvent(new Event('input', { bubbles: true }));
            el.dispatchEvent(new Event('change', { bubbles: true }));
        ", dobInput, date);

        // click outside to close the calendar
        driver.FindElement(By.TagName("body")).Click();

        driver.FindElement(By.Id("hobbies-checkbox-1")).Click();
        driver.FindElement(By.Id("hobbies-checkbox-2")).Click();
        driver.FindElement(By.Id("hobbies-checkbox-3")).Click();
        driver.FindElement(By.Id("currentAddress")).SendKeys("123 Main St, Anytown, USA");
        

        // Optionally, submit the form
        // IWebElement submitButton = driver.FindElement(By.CssSelector(".submit-btn"));
        // submitButton.Click();
    }
}