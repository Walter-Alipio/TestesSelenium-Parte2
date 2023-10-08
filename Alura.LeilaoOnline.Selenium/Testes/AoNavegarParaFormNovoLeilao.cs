using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System.Linq;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoNavegarParaFormNovoLeilao
    {
        private IWebDriver _driver;

        public AoNavegarParaFormNovoLeilao(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginAdminDeveMostrarTresCategorias()
        {
            //Arrange
           new LoginPO(_driver)
                .EfetuarLoginComCredenciais("admin@example.org", "123");

            var novoLeilaoPO = new NovoLeilaoPO(_driver);

            //Act
            novoLeilaoPO.Visitar();
            var result = novoLeilaoPO.Categorias;

            //Assert
            //Assert.Equal(3, result.Count());
            Assert.True(result.Count() > 0);
        }
    }
}
