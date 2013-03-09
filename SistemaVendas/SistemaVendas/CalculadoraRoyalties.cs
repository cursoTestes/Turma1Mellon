using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVendas
{
    public class CalculadoraRoyalties
    {
        private CalculadoraComissao calculadoraComissao;
        private IVendaRepository vendaRep;

        public CalculadoraRoyalties(CalculadoraComissao calculadoraComissao, IVendaRepository vendaRep)
        {
            // TODO: Complete member initialization
            this.calculadoraComissao = calculadoraComissao;
            this.vendaRep = vendaRep;
        }
        public double Calcular(int mes, int ano){

            var listaVendas = vendaRep.GetVendas(mes, ano);
            double total = 0;

            foreach (var valor in listaVendas)
            {
                total += valor - calculadoraComissao.CalcularComissao(valor);
            }
            
            return total * 0.2;
        }
    }
}
