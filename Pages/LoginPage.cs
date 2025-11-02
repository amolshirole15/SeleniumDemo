using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NunitTestProject.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        IWebElement loginLink => driver.FindElement(By.Id("loginLink"));
        IWebElement UserName => driver.FindElement(By.Name("UserName"));
        IWebElement Password => driver.FindElement(By.Name("Password"));
        IWebElement LoginButton => driver.FindElement(By.CssSelector(".btn"));
        IWebElement LnkEmployeeDetails => driver.FindElement(By.LinkText("Employee Details"));
        IWebElement LnkManageUser => driver.FindElement(By.LinkText("Manage Users"));
        IWebElement LnkLogOff => driver.FindElement(By.LinkText("Log off"));

        public void ClickLoginLink()
        {
            loginLink.ClickElement();
        }

        public void Login(string username, string password)
        {
            UserName.Clear();
            UserName.EnterText(username);
            Password.Clear();
            Password.EnterText(password);
            LoginButton.SubmitClick();
        }
        
        public (bool employeeDetails, bool manageUser) IsLoggedIn()
        {
            // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            // wait.Until(drv => LnkEmployeeDetails.Displayed && LnkManageUser.Displayed && LnkLogOff.Displayed);
            return (LnkEmployeeDetails.Displayed,LnkManageUser.Displayed);
        }
    }
}