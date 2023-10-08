using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogout
    {
        private IWebDriver driver;

        public AoEfetuarLogout(TestFixture fixture)
        {
            this.driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginValidoAoEfetuarLogoutDeveIrParaHomeNaoLogada()
        {
            //arrange
           new LoginPO(this.driver)
                .EfetuarLoginComCredenciais("fulano@example.org", "123");

            var dashboardPO = new DashboardInteressadaPO(driver);

            //act - efetuar logout
            dashboardPO.Menu.EfetuarLogout();

            //assert
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }
    }
}
