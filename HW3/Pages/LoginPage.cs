using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;


namespace HW3.Pages
{
    class LoginPage : AbstractPage
    {
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='Name']")]
        private IWebElement LoginName;

        [FindsBy(How = How.XPath, Using = "//*[@id='Password']")]
        private IWebElement LoginPassword;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/form/input[1]")]
        private IWebElement LoginBtn;

        [FindsBy(How = How.XPath, Using = "//h2")]
        private IWebElement chkLogin;

        public void login(String log, string pass)
        {
            IAction action = new Actions(driver)
                .Click(LoginName)
                .SendKeys(log)
                .Click(LoginPassword)
                .SendKeys(pass)
                .Click(LoginBtn);
            action.Perform();
            
        }

        public string GetNamePage()
        {
            return chkLogin.Text;
        }
    }
}
