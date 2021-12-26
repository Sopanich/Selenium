using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;

namespace HW3.Pages
{
    class Menu : AbstractPage
    {
        public Menu(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.XPath, Using = "//h2")]
        private IWebElement chkMenu;

        [FindsBy(How = How.XPath, Using = "//a[@href = '/Product']")]
        private IWebElement ProductsLnk;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"bs-example-navbar-collapse-1\"]/ul/li[4]/a")]
        private IWebElement logout;

        public string GetNamePage()
        {
            return chkMenu.Text;
        }

        public ProductsPage GoToProducts()
        {
            IAction action = new Actions(driver)
                .Click(ProductsLnk);
            action.Perform();

            return new ProductsPage(driver);
        }

        public void Logout()
        {
            IAction action = new Actions(driver).Click(logout);
            action.Perform();
        }
    }
}
