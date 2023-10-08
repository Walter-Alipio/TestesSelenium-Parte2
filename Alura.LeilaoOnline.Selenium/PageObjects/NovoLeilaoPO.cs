using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class NovoLeilaoPO
    {
        private IWebDriver driver;

        private By byInputTitulo;
        private By byInputDescricao;
        private By byInputCategoria;
        private By bytSpanCaterorias;
        private By byInputValorInicial;
        private By byInputImagem;
        private By byInputInicioPregao;
        private By byInputTerminoPregao;

        private By byButaoSalvar;

        public IEnumerable<string> Categorias 
        {
            get
            {
                var categorias = driver.FindElements(bytSpanCaterorias);

                
                return categorias.Select(cat => cat.Text);

            }
        }

        public NovoLeilaoPO(IWebDriver driver)
        {
            this.driver = driver;

            byInputTitulo = By.Id("Titulo");
            byInputDescricao = By.Id("Descricao");
            byInputCategoria = By.ClassName("select-dropdown");
            bytSpanCaterorias = By.TagName("span");
            byInputValorInicial = By.Id("ValorInicial");
            byInputImagem = By.Id("ArquivoImagem");
            byInputInicioPregao = By.Id("InicioPregao");
            byInputTerminoPregao = By.Id("TerminoPregao");

            byButaoSalvar = By.CssSelector("button[type=submit]");
        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("https://localhost:5001/Leiloes/Novo");
        }

        public void PreencheFormulario(
            string titulo,
            string descricao,
            string categoria,
            double valor,
            string imagem,
            DateTime inicio,
            DateTime termino
            )
        {
            driver.FindElement(byInputTitulo).SendKeys(titulo);
            driver.FindElement(byInputDescricao).SendKeys(descricao);
            driver.FindElement(byInputCategoria).Click();
            var categorias = driver.FindElements(bytSpanCaterorias);
            foreach ( var span in categorias ) { 
                if( span.Text == categoria ) span.Click();                
            }
            driver.FindElement(byInputValorInicial).SendKeys(valor.ToString());
            driver.FindElement(byInputImagem).SendKeys(imagem);
            driver.FindElement(byInputInicioPregao).SendKeys(inicio.ToString("dd/MM/yyyy"));
            driver.FindElement(byInputTerminoPregao).SendKeys(termino.ToString("dd/MM/yyyy"));
        }

        public void SubmeteFormulario()
        {
            driver.FindElement(byButaoSalvar).Click();
        }
    }
}
