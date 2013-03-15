using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using MbUnit.Framework;
using SistemaVendas.Negocio;
using NHibernate;

namespace TestProject1.Testes
{
    [TestFixture]
    public class TesteRelatorioDeVenda : TesteBase
    {

        [Test]
        public void teste_consulta_vendedor_inexistente()
        {
            ISession session = Contexto.SessionFactory.OpenSession();
            RelatorioVendasRepository relatorioVendas = new RelatorioVendasRepository(session);

            decimal valorEsperado = 0;
            int idVendedor = 9999;
            int ano = 2011;

            decimal valorAnual = relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }

        [Test]
        public void teste_consulta_vendedor_com_uma_venda_no_ano()
        {
            ISession session = Contexto.SessionFactory.OpenSession();
            RelatorioVendasRepository relatorioVendas = new RelatorioVendasRepository(session);

            decimal valorEsperado = 100;
            int idVendedor = 1;
            int ano = 2011;

            decimal valorAnual = relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }

        [Test]
        public void teste_consulta_vendedor_com_duas_vendas_no_ano()
        {
            ISession session = Contexto.SessionFactory.OpenSession();
            RelatorioVendasRepository relatorioVendas = new RelatorioVendasRepository(session);

            decimal valorEsperado = 200;
            int idVendedor = 20;
            int ano = 2011;

            decimal valorAnual = relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }

        [Test]
        public void teste_consulta_vendedor_sem_venda_no_ano()
        {
            ISession session = Contexto.SessionFactory.OpenSession();
            RelatorioVendasRepository relatorioVendas = new RelatorioVendasRepository(session);

            decimal valorEsperado = 0;
            int idVendedor = 1;
            int ano = 2000;

            decimal valorAnual = relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }

        [Test]
        public void teste_consulta_vendedor_com_uma_venda_compartilhada_no_ano()
        {
            ISession session = Contexto.SessionFactory.OpenSession();
            RelatorioVendasRepository relatorioVendas = new RelatorioVendasRepository(session);

            decimal valorEsperado = 50;
            int idVendedor = 3;
            int ano = 2011;

            decimal valorAnual = relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }

        [Test]
        public void teste_consulta_vendedor_com_uma_venda_compartilhada_outra_nao_no_ano()
        {
            ISession session = Contexto.SessionFactory.OpenSession();
            RelatorioVendasRepository relatorioVendas = new RelatorioVendasRepository(session);

            decimal valorEsperado = 150;
            int idVendedor = 4;
            int ano = 2011;

            decimal valorAnual = relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }
        [Test]
        public void teste_consulta_vendedor_com_uma_venda_compartilhada_por_tres_vendedores_no_ano()
        {
            ISession session = Contexto.SessionFactory.OpenSession();
            RelatorioVendasRepository relatorioVendas = new RelatorioVendasRepository(session);

            decimal valorEsperado = 150;
            int idVendedor = 4;
            int ano = 2012;

            decimal valorAnual = relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }
    }
}
