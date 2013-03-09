using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVendas
{
    public class CalculadoraComissao
    {
        public virtual double CalcularComissao(double valor)
        {
            double retorno;
            if (valor <= 10000)
            {
                retorno =  0.05 * valor;
            }
            else
            {
                retorno = 0.06 * valor;
            }

            return Math.Floor(retorno * 100) / 100; 
        }
    }
}
