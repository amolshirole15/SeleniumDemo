namespace NunitTestProject;
using NunitTestProject.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        // Create instance of selenium webDriver
        IWebDriver driver = new ChromeDriver();

        // Naviigate to the URL
        driver.Navigate().GoToUrl("https://www.google.com");

        // Maximize the window
        driver.Manage().Window.Maximize();

        // Find element
        IWebElement element = driver.FindElement(By.Name("q"));
        // Type on the element
        element.SendKeys("Selenium Testing");
        // Clik on the element
        element.SendKeys(Keys.Return);
        // Assert.Pass();

    }

    [Test]
    public void EAWebsiteTest()
    {
        //Create new instance of selenium web driver
        IWebDriver driver = new ChromeDriver();
        // Navigate to URL
        driver.Navigate().GoToUrl("http://eaapp.somee.com/");
        // Maximize the window
        driver.Manage().Window.Maximize();
        //Find the login link
        IWebElement loginLink = driver.FindElement(By.Id("loginLink"));
        // Clik to login link
        loginLink.Click();
        // Find Username textbox
        IWebElement txtUserName = driver.FindElement(By.Name("UserName"));
        txtUserName.SendKeys("admin");
        // Find password
        IWebElement txtPassword = driver.FindElement(By.Name("Password"));
        txtPassword.SendKeys("password");

        // Find log in btn using ClassName
        //IWebElement btnLogIn = driver.FindElement(By.ClassName("btn"));
        // Find log in btn using CssSelector
        IWebElement btnLogIn = driver.FindElement(By.CssSelector(".btn"));
        btnLogIn.Submit();

        // driver.Quit();
    }

    // [Test]
    // public void EAWebsiteCustomMethodTest()
    // {
    //     //Create new instance of selenium web driver
    //     IWebDriver driver = new ChromeDriver();
    //     // Navigate to URL
    //     driver.Navigate().GoToUrl("http://eaapp.somee.com/");
    //     // Maximize the window
    //     driver.Manage().Window.Maximize();
    //     //Find the login link and clik using custom method
    //     CustomMethods.ClickElement(driver, By.Id("loginLink"));
    //     // Find Username textbox
    //     CustomMethods.EnterText(driver, By.Name("UserName"), "admin");
    //     // Find password
    //     CustomMethods.EnterText(driver, By.Name("Password"), "password");

    //     // Find log in btn using ClassName
    //     //IWebElement btnLogIn = driver.FindElement(By.ClassName("btn"));
    //     // Find log in btn using CssSelector
    //     CustomMethods.SubmitClick(driver, By.CssSelector(".btn"));

    //     driver.Quit();
    // }
    
    [Test]
    public void TestWithPOM()
    {
        //Create new instance of selenium web driver
        var driver = new ChromeDriver();
        // Navigate to URL
        driver.Navigate().GoToUrl("http://eaapp.somee.com/");
        // Maximize the window
        driver.Manage().Window.Maximize();

        // Create instance of LoginPage and pass driver as parameter
        LoginPage loginPage = new LoginPage(driver);
        // Call method to click login link
        loginPage.ClickLoginLink();
        // Call method to perform login
        loginPage.Login("admin", "password");

        driver.Quit();
    }
}