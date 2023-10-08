using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using Alura.LeilaoOnline.Selenium.Helpers;
using System.Security.Cryptography.X509Certificates;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardInteressadaPO
    {
        private IWebDriver driver;

        public FiltroLeiloesPO Filtro {  get; }
        public MenuLogadoPO Menu { get; }

        public DashboardInteressadaPO(IWebDriver driver)
        {
            this.driver = driver;

            Filtro = new FiltroLeiloesPO(driver);
            Menu = new MenuLogadoPO(driver);
        }

    }
}
