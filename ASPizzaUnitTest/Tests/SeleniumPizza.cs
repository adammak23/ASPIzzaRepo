using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
using System.Collections.ObjectModel;

namespace ASPizzaTest.Tests
{
    [TestClass]
    public class SeleniumPizza
    {
        [TestMethod]
        public void TestClickSprawdzDodatek()
        {
            IWebDriver driver = new ChromeDriver();
            INavigation nav = driver.Navigate();
            nav.GoToUrl("http://localhost:61811/Pizza/");
            IWebElement element = driver.FindElement(By.XPath("/html/body/div[2]/table/tbody/tr[1]/td[1]/a[2]"));
            element.Click();
            string checkTest = driver.FindElement(By.XPath("/html/body/div[2]/div/p[2]")).Text;
            Assert.AreEqual("Dodatek: Węgiel ⊛", checkTest);
            driver.Close();
        }
        [TestMethod]
        public void TestDodajPizze()
        {
            IWebDriver driver = new ChromeDriver();
            INavigation nav = driver.Navigate();
            nav.GoToUrl("http://localhost:61811/Pizza");
            //sprawdzany ilość elementów w liście
            IWebElement tabela = driver.FindElement(By.XPath("/html/body/div[2]/table/tbody"));
            int IleKolumnPrzed = tabela.FindElements(By.XPath("tr")).Count;
            //click dodaj nową pizzę
            IWebElement element = driver.FindElement(By.XPath("/html/body/div[2]/p[2]/a"));
            element.Click();
            driver.FindElement(By.Id("Pizza_Name")).Click();
            driver.FindElement(By.Id("Pizza_Name")).SendKeys("NowaPizza");
            driver.FindElement(By.Id("Pizza_Price")).Click();
            driver.FindElement(By.Id("Pizza_Price")).SendKeys("15");
            driver.FindElement(By.Id("Pizza_DodatekId")).Click();
            driver.FindElement(By.Id("Pizza_DodatekId")).SendKeys("Cebula");
            IWebElement element2 = driver.FindElement(By.XPath("/html/body/div[2]/form/button"));
            element2.Click(); //stwórz
            //sprawdzany ilość elementów w liście ponownie
            IWebElement tabela2 = driver.FindElement(By.XPath("/html/body/div[2]/table/tbody"));
            int IlekolumnPo = tabela2.FindElements(By.XPath("tr")).Count;
            Assert.AreEqual(IlekolumnPo, IleKolumnPrzed+1);
            driver.Close();
        }
        [TestMethod]
        public void TestDodajOrazUsuńPizze()
        {
            IWebDriver driver = new ChromeDriver();
            INavigation nav = driver.Navigate();
            nav.GoToUrl("http://localhost:61811/Pizza");
            IWebElement tabela = driver.FindElement(By.XPath("/html/body/div[2]/table/tbody"));
            int IleKolumnPrzed = tabela.FindElements(By.XPath("tr")).Count;
            //click dodaj nową pizzę
            IWebElement element = driver.FindElement(By.XPath("/html/body/div[2]/p[2]/a"));
            element.Click();
            driver.FindElement(By.Id("Pizza_Name")).Click();
            driver.FindElement(By.Id("Pizza_Name")).SendKeys("NowaPizza");
            driver.FindElement(By.Id("Pizza_Price")).Click();
            driver.FindElement(By.Id("Pizza_Price")).SendKeys("15");
            driver.FindElement(By.Id("Pizza_DodatekId")).Click();
            driver.FindElement(By.Id("Pizza_DodatekId")).SendKeys("Cebula");
            IWebElement element2 = driver.FindElement(By.XPath("/html/body/div[2]/form/button"));
            element2.Click(); //stwórz
            //sprawdzam ilość elementów w liście
            IWebElement tabela2 = driver.FindElement(By.XPath("/html/body/div[2]/table/tbody"));
            int IlekolumnPoDodaniu = tabela2.FindElements(By.XPath("tr")).Count;
            //usuwam ostatni element w liście
            string DynamicDeleteButton = "/html/body/div[2]/table/tbody/tr[" + IlekolumnPoDodaniu + "]/td[3]/a";
            IWebElement DeleteButton = driver.FindElement(By.XPath(DynamicDeleteButton));
            DeleteButton.Click();
            //sprawdzam ilość elementów w liście po usunięciu
            IWebElement tabela3 = driver.FindElement(By.XPath("/html/body/div[2]/table/tbody"));
            int IlekolumnPoUsun = tabela3.FindElements(By.XPath("tr")).Count;

            Assert.AreEqual(IlekolumnPoUsun, IleKolumnPrzed);
            driver.Close();
        }
        [TestMethod]
        public void TestDodajOrazUsuńDodatek()
        {
            IWebDriver driver = new ChromeDriver();
            INavigation nav = driver.Navigate();
            nav.GoToUrl("http://localhost:61811/Dodatek");
            IWebElement tabela = driver.FindElement(By.XPath("/html/body/div[2]/table/tbody"));
            int IleKolumnPrzed = tabela.FindElements(By.XPath("tr")).Count;
            //click dodaj
            IWebElement element = driver.FindElement(By.XPath("/html/body/div[2]/p[2]/a/h"));
            element.Click();
            driver.FindElement(By.Id("Dodatek_Name")).Click();
            driver.FindElement(By.Id("Dodatek_Name")).SendKeys("NowyDodatek");
            IWebElement element2 = driver.FindElement(By.XPath("/html/body/div[2]/form/button/h2"));
            element2.Click(); //stwórz
            nav.GoToUrl("http://localhost:61811/Dodatek");
            //sprawdzam ilość elementów w liście
            IWebElement tabela2 = driver.FindElement(By.XPath("/html/body/div[2]/table/tbody"));
            int IlekolumnPoDodaniu = tabela2.FindElements(By.XPath("tr")).Count;
            //usuwam ostatni element w liście
            string DynamicDeleteButton = "/html/body/div[2]/table/tbody/tr[" + IlekolumnPoDodaniu + "]/td[2]/a";
            IWebElement DeleteButton = driver.FindElement(By.XPath(DynamicDeleteButton));
            DeleteButton.Click();
            //sprawdzam ilość elementów w liście po usunięciu
            IWebElement tabela3 = driver.FindElement(By.XPath("/html/body/div[2]/table/tbody"));
            int IlekolumnPoUsun = tabela3.FindElements(By.XPath("tr")).Count;
            Assert.AreEqual(IlekolumnPoUsun, IleKolumnPrzed);
            driver.Close();
        }

    }
}