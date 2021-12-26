using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using NUnit.Framework;

namespace HW3.Pages
{
    class EditProduct : AbstractPage
    {
        public EditProduct(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='ProductName']")]
        private IWebElement ProductName;

        [FindsBy(How = How.XPath, Using = "//option[@selected='selected'][contains(text(),'Confections')]")]
        private IWebElement CategoryId;

        [FindsBy(How = How.XPath, Using = "//option[@selected='selected'][contains(text(),'Bigfoot Breweries')]")]
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

        public void Check()
        {
            Assert.AreEqual(ProductName.GetAttribute("value"), "Шоколад");
            Assert.AreEqual(CategoryId.Text, "Confections");
            Assert.AreEqual(SupplierId.Text, "Bigfoot Breweries");
            Assert.AreEqual(UnitPrice.GetAttribute("value"), "100,0000");
            Assert.AreEqual(QuantityPerUnit.GetAttribute("value"), "10");
            Assert.AreEqual(UnitsInStock.GetAttribute("value"), "10");
            Assert.AreEqual(UnitsOnOrder.GetAttribute("value"), "10");
            Assert.AreEqual(ReorderLevel.GetAttribute("value"), "10");
        }
    }
}
