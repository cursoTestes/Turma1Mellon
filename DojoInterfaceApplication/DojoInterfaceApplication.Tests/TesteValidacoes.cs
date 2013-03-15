using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using DojoInterfaceApplication.Tests;

namespace SeleniumTests
{
    [TestClass]
    public class TesteValidacoes : TesteBase
    {
        [TestMethod]
        public void Retorna_Erro_quando_idVendedor_for_alfa()
        {
            driver.Navigate().GoToUrl(baseURL + "/Venda/Add");

            driver.FindElement(By.Id("Vendedor")).SendKeys("teste");
            driver.FindElement(By.Id("DataVenda")).SendKeys("10/01/2011");
            driver.FindElement(By.Id("Valor")).SendKeys("10");


            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();

            String resultado = driver.FindElement(By.Id("Mensagem")).GetAttribute("value").ToString();
            String esperado = "Vendedor deve ser numerico.";
            Assert.AreEqual(resultado, esperado);

            Assert.AreEqual(baseURL + "/Venda/Add", driver.Url);

        }

        [TestMethod]
        public void Retorna_MensagemDeGravadoComSucesso()
        {
            driver.Navigate().GoToUrl(baseURL + "/Venda/Add");

            driver.FindElement(By.Id("Vendedor")).SendKeys("1");
            driver.FindElement(By.Id("DataVenda")).SendKeys("10/01/2011");
            driver.FindElement(By.Id("Valor")).SendKeys("10");


            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();

            String resultado = driver.FindElement(By.Id("Mensagem")).GetAttribute("value").ToString();
            String esperado = "Gravado com sucesso.";
            Assert.AreEqual(resultado, esperado);

            Assert.AreEqual(baseURL + "/Venda/Add", driver.Url);

        }

        
        [TestMethod]
        public void Retorna_Erro_quando_valor_for_alfa()
        {
            driver.Navigate().GoToUrl(baseURL + "/Venda/Add");

            driver.FindElement(By.Id("Vendedor")).SendKeys("1");
            driver.FindElement(By.Id("DataVenda")).SendKeys("10/01/2011");
            driver.FindElement(By.Id("Valor")).SendKeys("teste");


            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            
            var elemento = driver.FindElement(By.Id("Mensagem"));

            Assert.IsNotNull(elemento);

            String resultado = elemento.GetAttribute("value").ToString();
            String esperado = "Valor deve ser numerico.";
            Assert.AreEqual(resultado, esperado);

            Assert.AreEqual(baseURL + "/Venda/Add", driver.Url);

        }
    }
}
