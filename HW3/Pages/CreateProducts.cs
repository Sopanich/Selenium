using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;

namespace HW3.Pages
{
    class CreateProduct : AbstractPage
    {
        public CreateProduct(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='ProductName']")]
        private IWebElement ProductName;

        [FindsBy(How = How.XPath, Using = "//*[@id='CategoryId']")]
        private IWebElement CategoryId;

        [FindsBy(How = How.XPath, Using = "//*[@id='SupplierId']")]
        private IWebElement SupplierId;

        [FindsBy(How = How.XPath, Using = "//*[@id='UnitPrice']")]
        private IWebElement UnitPrice;

        [FindsBy(How = How.XPath, Using = "//*[@id='QuantityPerUnit']")]
        private IWebElement QuantityPerUnit;

        [FindsBy(How = How.XPath, Using = "//*[@id='UnitsInStock']")]
        private IWebElement UnitsInStock;

        [FindsBy(How = How.XPath, Using = "//*[@id='UnitsOnOrder']")]
        private IWebElement UnitsOnOrder;

        [FindsBy(How = How.XPath, Using = "//*[@id='ReorderLevel']")]
        private IWebElement ReorderLevel;

        [FindsBy(How = How.XPath, Using = "//input[contains(@class,'btn')]")]
        private IWebElement SendBtn;

        public void Create()
        {
            new SelectElement(CategoryId).SelectByText("Confections");
            new SelectElement(SupplierId).SelectByText("Bigfoot Breweries");
            IAction action = new Actions(driver)
                .Click(ProductName)
                .SendKeys("Шоколад")
                .Click(UnitPrice)
                .SendKeys("100")
                .Click(QuantityPerUnit)
                .SendKeys("10")
                .Click(UnitsInStock)
                .SendKeys("10")
                .Click(UnitsOnOrder)
                .SendKeys("10")
                .Click(ReorderLevel)
                .SendKeys("10")
                .Click(SendBtn);
            action.Perform();
        }

    }
}
