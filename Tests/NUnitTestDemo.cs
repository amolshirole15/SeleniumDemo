using System;
using System.Text.Json;
using NunitTestProject;
using NunitTestProject.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;

namespace NUnitTestDemo
{
    [TestFixture("admin", "password")]
    public class NUnitTestDemo
    {
        private IWebDriver _driver;
        private readonly string _username;
        private readonly string _password;

        public NUnitTestDemo(string username, string password)
        {
            this._username = username;
            this._password = password;
        }

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            _driver.Manage().Window.Maximize();
            Console.WriteLine("Hello, NUnit Test Demo!");
            // ReadJsonData();
        }

        // [Test]
        // [Category("SmokeTest")]
        // public void TestWithPOM()
        // {
        //     // POM Initialization
        //     LoginPage loginPage = new LoginPage(_driver);
        //     // Call method to click login link
        //     loginPage.ClickLoginLink();
        //     // Call method to perform login
        //     loginPage.Login(_username, _password);
        // }

        [Test]
        [Category("SmokeTest")]
        [TestCaseSource(nameof(LoginTestData))]
        public void TestWithPOM(LoginModel loginModel)
        {
            // POM Initialization
            // Arrange
            LoginPage loginPage = new LoginPage(_driver);

            // Call method to click login link
            // Act
            loginPage.ClickLoginLink();
            // Call method to perform login
            loginPage.Login(loginModel.Username, loginModel.Password);

            // Assert
            var getLoggedIn = loginPage.IsLoggedIn();
            Assert.IsTrue(getLoggedIn.employeeDetails && getLoggedIn.manageUser, "Login failed with provided credentials.");
        }

        public static IEnumerable<LoginModel> LoginTestData()
        {
            yield return new LoginModel { Username = "admin", Password = "password" };
            // yield return new LoginModel { Username = "user1", Password = "pass1" };
            // yield return new LoginModel { Username = "user2", Password = "pass2" };
        }

        // [Test]
        // public void TestWithPOM()
        // {
        //     // POM Initialization
        //     LoginPage loginPage = new LoginPage(_driver);

        //     string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LoginData.json");
        //     var jsonString = File.ReadAllText(jsonFilePath);

        //     var loginModel = JsonSerializer.Deserialize<LoginModel>(jsonString);

        //     // Call method to click login link
        //     loginPage.ClickLoginLink();
        //     // Call method to perform login
        //     loginPage.Login(loginModel.Username, loginModel.Password);
        // }

        private void ReadJsonData()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LoginData.json");
            var jsonString = File.ReadAllText(jsonFilePath);

            var loginModel = JsonSerializer.Deserialize<LoginModel>(jsonString);
            Console.WriteLine($"Username: {loginModel.Username}, Password: {loginModel.Password}");
        }

        // [Test]
        // [TestCase("Chrome", "30")]
        // public void BrowserTest(string browser, string version)
        // {
        //     Console.WriteLine($"Running test on {browser} version {version}");
        //     // Additional test logic can be added here
        // }

        [TearDown]
        public void TearDown(){
            _driver.Quit();
            _driver.Dispose();
        }
    }
}