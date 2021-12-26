using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;

namespace HW3.Pages
{
    class ProductPage : AbstractPage
    {
        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.XPath, Using = "//a[contains(@class,'btn')]")]
        private IWebElement NewProduct;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Шоколад')]")]
        private IWebElement Product;

        [FindsBy(How = How.XPath, Using = "(//*[@data-remove])[78]")]
        private IWebElement remove;

        public CreateProduct AddNewProduct()
        {
            IAction action = new Actions(driver)
                .Click(NewProduct);
            action.Perform();

            return new CreateProduct(driver);
        }

        public EditProduct ViewProduct()
        {
            IAction action = new Actions(driver)
                .Click(Product);
            action.Perform();
            return new EditProduct(driver);
        }

        public void Remove()
        {
            IAction action = new Actions(driver).Click(remove);
            action.Perform();
            driver.SwitchTo().Alert().Accept();
        }
    }
}
