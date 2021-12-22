using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace HW3
{
    public class Tests
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public bool IsElementNotPresent(By locator)
        {
            try
            {
                driver.FindElement(locator);
            }
            catch (NoSuchElementException)
            {
                return true;
            }
            return false;
        }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://localhost:5000";


            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            wait.Timeout = TimeSpan.FromSeconds(1);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='Name']"))).SendKeys("user");

            driver.FindElement(By.XPath("//*[@id='Password']")).SendKeys("user");
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();

            Assert.AreEqual(driver.FindElement(By.XPath("//h2")).Text, "Home page");
        }

        [Test]
        public void AddProduct()
        {
            driver.FindElement(By.XPath("//a[@href = '/Product']")).Click();
            driver.FindElement(By.XPath("//a[contains(text(),'Create new')]")).Click();

            driver.FindElement(By.XPath("//*[@id='ProductName']")).SendKeys("Шоколад");
            new SelectElement(driver.FindElement(By.XPath("//*[@id='CategoryId']"))).SelectByText("Confections");
            new SelectElement(driver.FindElement(By.XPath("//*[@id='SupplierId']"))).SelectByText("Bigfoot Breweries");
            driver.FindElement(By.XPath("//*[@id='UnitPrice']")).SendKeys("100");
            driver.FindElement(By.XPath("//*[@id='QuantityPerUnit']")).SendKeys("10");
            driver.FindElement(By.XPath("//*[@id='UnitsInStock']")).SendKeys("10");
            driver.FindElement(By.XPath("//*[@id='UnitsOnOrder']")).SendKeys("10");
            driver.FindElement(By.XPath("//*[@id='ReorderLevel']")).SendKeys("10");

            driver.FindElement(By.XPath("//input[@type='submit']")).Click();

            Assert.IsTrue(IsElementNotPresent(By.XPath("//*[h2='Product editing']")));
        }

        [Test]
        public void FindProduct()
        {
            driver.FindElement(By.XPath("//a[@href = '/Product']")).Click();
            driver.FindElement(By.XPath("//a[contains(text(),'Шоколад')]")).Click();

            Assert.AreEqual(driver.FindElement(By.XPath("//*[@id='ProductName']")).GetAttribute("value"), "Шоколад");
            Assert.AreEqual(driver.FindElement(By.XPath("//option[@selected='selected'][contains(text(),'Confections')]")).Text, "Confections");
            Assert.AreEqual(driver.FindElement(By.XPath("//option[@selected='selected'][contains(text(),'Bigfoot Breweries')]")).Text, "Bigfoot Breweries");
            Assert.AreEqual(driver.FindElement(By.XPath("//*[@id='UnitPrice']")).GetAttribute("value"), "100,0000");
            Assert.AreEqual(driver.FindElement(By.XPath("//*[@id='QuantityPerUnit']")).GetAttribute("value"), "10");
            Assert.AreEqual(driver.FindElement(By.XPath("//*[@id='UnitsInStock']")).GetAttribute("value"), "10");
            Assert.AreEqual(driver.FindElement(By.XPath("//*[@id='UnitsOnOrder']")).GetAttribute("value"), "10");
            Assert.AreEqual(driver.FindElement(By.XPath("//*[@id='ReorderLevel']")).GetAttribute("value"), "10");
        }

        [Test]
        public void RemoveProduct()
        {
            driver.FindElement(By.XPath("//a[@href = '/Product']")).Click();
            driver.FindElement(By.XPath("(//*[@data-remove])[78]")).Click();

            driver.SwitchTo().Alert().Accept();
        }

        [TearDown]
        public void TearDown()
        {
            driver.FindElement(By.XPath("//a[contains(@href,'Logout')]")).Click();

            Assert.AreEqual(driver.FindElement(By.XPath("//h2")).Text, "Login");

            driver.Quit();
        }

    }
}