using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaVendas;
using Moq;
using System.Collections.Generic;

namespace TesteVendas
{
    [TestClass]
    public class TesteCalculoRoyalties
    {
        [TestInitialize]
        public void rodaAntesTeste()
        {

        }

        [TestMethod]
        public void TesteCalculaTotalDeRoyaltiesDoMes1Venda100()
        {
            //arrange
            int mes = 1;
            int ano = 2013;
            double valorVenda = 100;
            double comissaoEsperada = 5;
            double royaltiesEsperado = 19;

            //Mock repositorio
            Mock<IVendaRepository> mockRepository = new Mock<IVendaRepository>();
            
            List<double> listaVendasMock = new List<double>();
            listaVendasMock.Add(valorVenda);

            mockRepository.Setup(r => r.GetVendas(mes, ano)).Returns(listaVendasMock);
            //dada uma lista de vendas no mes X, calcular total de royalties

            IVendaRepository vendaRep = mockRepository.Object;

            Mock<CalculadoraComissao> mockCalculaComissao = new Mock<CalculadoraComissao>();
            mockCalculaComissao.Setup(c => c.CalcularComissao(It.IsAny<double>())).Returns(comissaoEsperada);

            //act
            CalculadoraRoyalties calculadoraRoyalties = new CalculadoraRoyalties(mockCalculaComissao.Object, vendaRep);
            double totalRoyalties = calculadoraRoyalties.Calcular(mes,ano);

            //assert
            Assert.AreEqual(royaltiesEsperado, totalRoyalties);
            mockRepository.Verify(mock => mock.GetVendas(mes, ano), Times.Once()); 

        }


        [TestMethod]
        public void TesteCalculaTotalDeRoyaltiesDoMes2Vendas100()
        {
            //arrange
            int mes = 1;
            int ano = 2013;
            double valorVenda = 100;
            double comissaoEsperada = 0;
            double royaltiesEsperado = 40;

            //Mock repositorio
            Mock<IVendaRepository> mockRepository = new Mock<IVendaRepository>();
            
            List<double> listaVendasMock = new List<double>();
            listaVendasMock.Add(valorVenda);
            listaVendasMock.Add(valorVenda);

            mockRepository.Setup(r => r.GetVendas(mes, ano)).Returns(listaVendasMock);
            //dada uma lista de vendas no mes X, calcular total de royalties

            IVendaRepository vendaRep = mockRepository.Object;

            Mock<CalculadoraComissao> mockCalculaComissao = new Mock<CalculadoraComissao>();
            mockCalculaComissao.Setup(c => c.CalcularComissao(valorVenda)).Returns(comissaoEsperada);

            //act
            CalculadoraRoyalties calculadoraRoyalties = new CalculadoraRoyalties(mockCalculaComissao.Object, vendaRep);
            double totalRoyalties = calculadoraRoyalties.Calcular(mes, ano);

            //assert
            Assert.AreEqual(royaltiesEsperado, totalRoyalties);
        }
    }
}
