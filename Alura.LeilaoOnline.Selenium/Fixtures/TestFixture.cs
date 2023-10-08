using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.Fixtures
{
    public class TestFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        //Setup
        public TestFixture()
        {
            Driver = new ChromeDriver(TestHelper.PastaDoExecutavel);
            //setando waiter - usado pelos métodos FindElement e FindElements para definir o timeout antes de lançar a exceção
            //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        //TearDown
        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
