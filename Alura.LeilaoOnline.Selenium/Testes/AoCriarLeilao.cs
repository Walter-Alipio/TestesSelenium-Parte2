using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoCriarLeilao
    {
        private IWebDriver driver;

        public AoCriarLeilao(TestFixture fixture)
        {
            this.driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginAdminEInfoValidasDeveCadastrarLeilao()
        {
            //Arrange
             new LoginPO(this.driver)
                .EfetuarLoginComCredenciais("admin@example.org", "123");

            var novoLeilaoPO = new NovoLeilaoPO(this.driver);
            novoLeilaoPO.Visitar();
            novoLeilaoPO.PreencheFormulario(
                "Leilão de Coleção 1",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                "Item de Colecionador",
                4000,
                @"C:\Users\walte\OneDrive\Imagens\lawn_leaf.jpg",
                DateTime.Now.AddDays(20),
                DateTime.Now.AddDays(30)
                );

            //Act
            novoLeilaoPO.SubmeteFormulario();
            //Assert
            Assert.Contains("Leilões cadastrados no sistema", driver.PageSource);
        }
    }
}
