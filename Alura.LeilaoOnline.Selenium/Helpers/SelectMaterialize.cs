using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.Helpers
{
    public class SelectMaterialize
    {
        private IWebDriver driver;
        private IWebElement selectWrapper;
        private IEnumerable<IWebElement> opcoes;

        public SelectMaterialize(IWebDriver driver, By bySelectWrapper)
        {
            this.driver = driver;
            this.selectWrapper = driver.FindElement(bySelectWrapper);
            opcoes = selectWrapper.FindElements(By.CssSelector("li>span"));
        }

        public IEnumerable<IWebElement> Opcoes => opcoes; 

    

        public void DeselectAll()
        {
            OpenWrapper();
            foreach (var opcoes in opcoes)
            {
                opcoes.Click();
            }
            LoseFocus();
        }
        public void SelectByText(string option) 
        {
            OpenWrapper();
            opcoes.Where(o => o.Text.Contains(option))
                .ToList().ForEach(o =>
                {
                    o.Click();
                });
            LoseFocus() ;
        }

        private void LoseFocus()
        {
            selectWrapper
                .FindElement(By.TagName("li"))
                .SendKeys(Keys.Tab);
        }

        private void OpenWrapper()
        {
            selectWrapper.Click();
        }
    }
}
