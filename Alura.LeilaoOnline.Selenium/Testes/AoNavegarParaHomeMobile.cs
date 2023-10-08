using Alura.LeilaoOnline.Selenium.Helpers;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    public class AoNavegarParaHomeMobile : IDisposable
    {
        private ChromeDriver driver;
        public AoNavegarParaHomeMobile()   { }

        [Fact]
        public void DadaLargura992DeveMostraMenuMobile()
        {
            //Arrange
            var deviceSettings = new ChromeMobileEmulationDeviceSettings();
            deviceSettings.Width = 992;
            deviceSettings.Height = 800;
            deviceSettings.UserAgent = "Customizada";
            var option = new ChromeOptions();
            option.EnableMobileEmulation(deviceSettings);
            driver = new ChromeDriver(TestHelper.PastaDoExecutavel, option);

            var homePO = new HomeNaoLogadaPO(driver);

            //Act
            homePO.Visitar();

            //Assert
            Assert.True(homePO.Menu.MenuMobileVisivel);
        }

        [Fact]
        public void DadoLargur993NaoDeveMostarMenuMobile()
        {
            //Arrange
            var deviceSettings = new ChromeMobileEmulationDeviceSettings();
            deviceSettings.Width = 993;
            deviceSettings.Height = 800;
            deviceSettings.UserAgent = "Customizada";
            var option = new ChromeOptions();
            option.EnableMobileEmulation(deviceSettings);
            driver = new ChromeDriver(TestHelper.PastaDoExecutavel, option);

            var homePO = new HomeNaoLogadaPO(driver);

            //Act
            homePO.Visitar();

            //Assert
            Assert.False(homePO.Menu.MenuMobileVisivel);

        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
