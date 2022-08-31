using System;
using System.Globalization;

namespace CalculadorDeuda
{
    class Program
    {
        static void Main(string[] args)
        {
            int operacion = 0;
            decimal montoDeuda = 0;
            DateTime fechaDeuda = DateTime.Now;
            DateTime fechaFin = DateTime.Now;
            bool condicion = true;

            string text;

            while (condicion)
            {
                Console.WriteLine("Ingrese el monto de la deuda:");
                text = Console.ReadLine();
                condicion = !decimal.TryParse(text, out montoDeuda);
            }
            condicion = true;
            while (condicion)
            {
                Console.WriteLine("Ingrese la fecha de inicio de la deuda con formato AAAA-MM-DD");
                text = Console.ReadLine();
                condicion = !DateTime.TryParse(text, out fechaDeuda);
            }

            condicion = true;
            while (condicion)
            {
                Console.WriteLine("Ingrese la fecha  fin para calcular la deuda con formato AAAA-MM-DD");
                text = Console.ReadLine();
                condicion = !DateTime.TryParse(text, out fechaFin);
            }


            while (operacion != 1 && operacion != 2)
            {
                Console.WriteLine("Introduzca 1 para calcular deuda en dólares");
                Console.WriteLine("Introduzca 2 para calcular deuda en pesos");
                text = Console.ReadLine();
                if (text.Trim() == "")
                {
                    operacion = 0;
                }
                else
                {
                    operacion = int.TryParse(text, out operacion) ? operacion : 0;
                }
            }

            DeudaEnDolares deudaEnDolares = new DeudaEnDolares(montoDeuda, fechaDeuda, new CotizacionDolares()); ;

            if (operacion == 1)
            {
                Console.WriteLine($"La deuda en dolares es US${deudaEnDolares.GetDeudaEnDolaresPorFecha(fechaFin)}");
            }

            if (operacion == 2)
            {
                Console.WriteLine($"La deuda en pesos es AR${deudaEnDolares.GetDeudaEnPesosPorFecha(fechaFin)}");
            }



        }
    }
}
