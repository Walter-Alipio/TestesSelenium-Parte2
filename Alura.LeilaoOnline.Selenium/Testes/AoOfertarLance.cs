using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoOfertarLance
    {
        private IWebDriver driver;

        public AoOfertarLance(TestFixture fixture)
        {
            this.driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginInteressadaDeveAtualizarLanceAtual()
        {
            //Arrange
            new LoginPO(this.driver)
                .EfetuarLoginComCredenciais("fulano@example.org", "123");

            var detalhePO = new DetalheLeilaoPO(this.driver);
            detalhePO.Visitar(1);//em andamento

            //Act
            detalhePO.OfertarLance(300);

            //Assert
            /* 
             Essa é uma forma explicita de manipular o tempo de espera utilizando Selenium.Support.
             O TimeSpan representa por quanto tempo o selenium deve ficar tentando buscar o elemento.
             */
            var wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(8));
            var iguais = wait.Until(drv => detalhePO.LanceAtual == 300);

            Assert.True(iguais);
        }
    }
}
