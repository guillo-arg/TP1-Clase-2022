using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadorDeuda
{
    public interface ICotizacionDolares
    {
        decimal GetEnPesos(DateTime dateTime);
    }
}
