using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DetalheLeilaoPO
    {
        private IWebDriver driver;
        private By byInputValor;
        private By byBotaoOfertar;
        private By byLanceAtual;

        public DetalheLeilaoPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputValor = By.Id("Valor");
            byBotaoOfertar = By.Id("btnDarLance");
            byLanceAtual = By.Id("lanceAtual");
        }

        public double LanceAtual { 
            
            get {
                var valor = driver.FindElement(byLanceAtual).Text.Replace("R$","").Replace(",",".");
                var valorConvertido = double.Parse(valor, System.Globalization.NumberStyles.Currency);
                return valorConvertido;
            }
        }

        public void Visitar(int idLeilao)
        {
            driver.Navigate().GoToUrl($"https://localhost:5001/Home/Detalhes/{idLeilao}");
        }

        public void OfertarLance(double valor)
        {
            var inputValor = driver.FindElement(byInputValor);
            inputValor.Clear();
            inputValor.SendKeys(valor.ToString());
            driver.FindElement(byBotaoOfertar).Click();
        }
    }
}
