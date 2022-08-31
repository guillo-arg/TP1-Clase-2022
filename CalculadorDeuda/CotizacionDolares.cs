using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadorDeuda
{
    public class CotizacionDolares : ICotizacionDolares
    {
        public CotizacionDolares()
        {

        }
        public decimal GetEnPesos(DateTime dateTime)
        {
            return 100;
        }
    }
}
