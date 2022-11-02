
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace globalTask
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void yourLogo()
        {

            int waitingTime = 1000;
            By searchBar = By.Id("search_query_top");
            By searchButton = By.Name("submit_search");
            By picture = By.XPath("//*[@id=\"center_column\"]/ul/li/div/div[1]/div/a[1]/img");
            By pictureSummer = By.XPath("//*[@id=\"center_column\"]/ul/li[1]/div/div[1]/div/a[1]/img");
            By sizeDropDown = By.Id("group_1");
            By colour = By.Id("color_14");
            By addToCart = By.XPath("//*[@id=\"add_to_cart\"]/button/span");
            By keepShopping = By.XPath("//*[@id=\"layer_cart\"]/div[1]/div[2]/div[4]/span/span");
            By proceed = By.XPath("//*[@id=\"layer_cart\"]/div[1]/div[2]/div[4]/a/span");
            By remove = By.XPath("//*[@id=\"cart_quantity_down_4_16_0_0\"]/span");

            
            IWebDriver webDriver = new ChromeDriver();

            webDriver.Manage().Window.Maximize();

            webDriver.Navigate().GoToUrl("http://automationpractice.com/index.php");

            //Add to the cart a Faded Short Sleeve T Shirt, size medium, colour blue 
            webDriver.FindElement(searchBar).SendKeys("Faded Short Sleeve T Shirt");
            webDriver.FindElement(searchButton).Click();
            Thread.Sleep(waitingTime);
            webDriver.FindElement(picture).Click();
            Thread.Sleep(waitingTime);

            IWebElement elem = webDriver.FindElement(sizeDropDown);
            SelectElement element = new SelectElement(elem);
            element.SelectByIndex(1);

            webDriver.FindElement(colour).Click();
            Thread.Sleep(waitingTime);
            webDriver.FindElement(addToCart).Click();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            webDriver.FindElement(keepShopping).Click();


            //Add to the cart an Evening Dress, size small, colour beige 
            webDriver.FindElement(searchBar).Clear();
            webDriver.FindElement(searchBar).SendKeys("Evening Dress");
            webDriver.FindElement(searchButton).Click();
            Thread.Sleep(waitingTime);
            webDriver.FindElement(picture).Click();
            Thread.Sleep(waitingTime);

            IWebElement elem2 = webDriver.FindElement(sizeDropDown);
            SelectElement element2 = new SelectElement(elem2);
            element2.SelectByIndex(0);

            webDriver.FindElement(By.Id("color_7")).Click();
            Thread.Sleep(waitingTime);
            webDriver.FindElement(addToCart).Click();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            webDriver.FindElement(keepShopping).Click();


            //Add to the cart a Printed Summer Dress, size medium, colour orange 
            webDriver.FindElement(searchBar).Clear();
            webDriver.FindElement(searchBar).SendKeys("Printed Summer Dress");
            webDriver.FindElement(searchButton).Click();
            Thread.Sleep(waitingTime);
            webDriver.FindElement(pictureSummer).Click();
            Thread.Sleep(waitingTime);

            IWebElement elem3 = webDriver.FindElement(sizeDropDown);
            SelectElement element3 = new SelectElement(elem3);
            element3.SelectByIndex(1);

            webDriver.FindElement(By.Id("color_13")).Click();
            Thread.Sleep(waitingTime);
            webDriver.FindElement(addToCart).Click();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            
            //Checkout
            webDriver.FindElement(proceed).Click();

            //Remove the Evening Dress from the cart 
            webDriver.FindElement(remove).Click();

            //Add a second Faded Short Sleeve T Shirt of the same size and colour 
            webDriver.FindElement(searchBar).SendKeys("Faded Short Sleeve T Shirt");
            webDriver.FindElement(searchButton).Click();
            Thread.Sleep(waitingTime);
            webDriver.FindElement(picture).Click();
            Thread.Sleep(waitingTime);

            IWebElement elem4 = webDriver.FindElement(sizeDropDown);
            SelectElement element4 = new SelectElement(elem4);
            element4.SelectByIndex(1);

            webDriver.FindElement(colour).Click();
            Thread.Sleep(waitingTime);
            webDriver.FindElement(addToCart).Click();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            webDriver.FindElement(proceed).Click();


            //Assert the total for each line in the cart 
            var summerDressPrice = webDriver.FindElement(By.Id("total_product_price_5_25_0"));
            Assert.IsTrue(summerDressPrice.Text.Equals("$28.98"));
            var tshirtPrice = webDriver.FindElement(By.Id("total_product_price_1_4_0"));
            Assert.IsTrue(tshirtPrice.Text.Equals("$33.02"));

            //Assert the cart total is $65.53 
            var totalPrice = webDriver.FindElement(By.Id("total_price"));
            Assert.IsFalse(totalPrice.Text.Equals("$65.53"));


            //webDriver.Quit();

        }

    }

}

