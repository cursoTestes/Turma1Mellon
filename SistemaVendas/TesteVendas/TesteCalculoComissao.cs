using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaVendas;

namespace TesteVendas
{
    
    [TestClass]
    public class TesteCalculoComissao
    {
        [TestMethod]
        public void TesteCalculoComissaoVenda100Retorna5()
        {
            double valorVenda = 100;
            double valorEsperado = 5;

            double retorno = CalculadoraComissao.CalcularComissao(valorVenda);

            Assert.AreEqual(valorEsperado, retorno);
        }
        [TestMethod]
        public void TesteCalculoComissaoVenda200Retorna10()
        {
            double valorVenda = 200;
            double valorEsperado = 10;

            double retorno = CalculadoraComissao.CalcularComissao(valorVenda);

            Assert.AreEqual(valorEsperado, retorno);
        }
        [TestMethod]
        public void TesteCalculoComissaoVenda10000Retorna500()
        {
            double valorVenda = 10000;
            double valorEsperado = 500;

            double retorno = CalculadoraComissao.CalcularComissao(valorVenda);

            Assert.AreEqual(valorEsperado, retorno);
        }
        [TestMethod]
        public void TesteCalculoComissaoVenda100000Retorna6000()
        {
            double valorVenda = 100000;
            double valorEsperado = 6000;

            double retorno = CalculadoraComissao.CalcularComissao(valorVenda);

            Assert.AreEqual(valorEsperado, retorno);
        }
        [TestMethod]
        public void TesteCalculoComissaoVenda200000Retorna12000()
        {
            double valorVenda = 200000;
            double valorEsperado = 12000;

            double retorno = CalculadoraComissao.CalcularComissao(valorVenda);

            Assert.AreEqual(valorEsperado, retorno);
        }

        [TestMethod]
        public void TesteCalculoComissaoVendaComProblemaArrendondamento()
        {
            double valorVenda = 1.99;
            double valorEsperado = 0.09;

            double retorno = CalculadoraComissao.CalcularComissao(valorVenda);

            Assert.AreEqual(valorEsperado, retorno);
        }
        [TestMethod]
        public void TesteCalculoComissaoVendaComErroMaluco()
        {
            Assert.AreEqual(1,2);
        }
    }
}
