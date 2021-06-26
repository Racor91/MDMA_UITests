using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace TestProject1
{
    public class Tests
    {
        private IWebDriver _driver;
        
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver("C:\\SRC\\");
            _driver.Url = "https://www.hs-heilbronn.de/";
        }

        [Test]
        public void Test1()
        {
            _driver.FindElement(By.CssSelector("#options-navigation > a.btn.btn-primary.d-none.d-sm-block")).Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.FindElement(By.CssSelector(".btn-secondary")));
            _driver.FindElement(By.CssSelector(".btn-secondary")).Click();
            wait.Until(driver => driver.FindElement(By.CssSelector(".form-control")));
            _driver.FindElement(By.CssSelector("#col3_content > div > form > input:nth-child(4)")).SendKeys("testUser");
            _driver.FindElement(By.CssSelector("#col3_content > div > form > input:nth-child(5)")).SendKeys("123456");
            _driver.FindElement(By.CssSelector("#col3_content > div > form > div > input")).Click();

            Assert.AreEqual("Anmeldung fehlgeschlagen", 
                _driver.FindElement(By.CssSelector(".login-notice")).Text);
            Assert.Pass();
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}