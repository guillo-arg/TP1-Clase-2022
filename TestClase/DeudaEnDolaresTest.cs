using CalculadorDeuda;
using Moq;
using System;
using Xunit;

namespace TestClase
{
    public class DeudaEnDolaresTest
    {
        [Fact]
        public void Caso1()
        {
            //Arrange
            var montoDeuda = 100;
            DateTime fechaInicio = DateTime.Parse("2020-01-01");
            var fechaFin = DateTime.Parse("2020-01-11");
            var esperado = 110;

            var cotizacionMock = new Mock<ICotizacionDolares>();

            DeudaEnDolares deudaEnDolares = new DeudaEnDolares(montoDeuda, fechaInicio, cotizacionMock.Object);

            //Act

            var actual = deudaEnDolares.GetDeudaEnDolaresPorFecha(fechaFin);

            //Assert
            Assert.Equal(esperado, actual);


        }

        [Fact]
        public void Caso2()
        {
            //Arrange
            var montoDeuda = 100;
            DateTime fechaInicio = DateTime.Parse("2020-01-01");
            var fechaFin = DateTime.Parse("2019-01-11");
            var esperado = "La fecha para el cálculo debe ser mayor o igual a la fecha de la deuda";

            var cotizacionMock = new Mock<ICotizacionDolares>();

            DeudaEnDolares deudaEnDolares = new DeudaEnDolares(montoDeuda, fechaInicio, cotizacionMock.Object);

            //Act


            //Assert
            var ex = Assert.Throws<Exception>(() => deudaEnDolares.GetDeudaEnDolaresPorFecha(fechaFin));
            Assert.Equal(esperado, ex.Message);

        }


        [Fact]
        public void Caso3()
        {
            //Arrange
            var montoDeuda = 100;
            DateTime fechaInicio = DateTime.Parse("2020-01-01");
            var fechaFin = DateTime.Parse("2020-01-11");
            var esperado = 11000;

            var cotizacionMock = new Mock<ICotizacionDolares>();
            cotizacionMock.Setup(x => x.GetEnPesos(fechaFin)).Returns(100);
            DeudaEnDolares deudaEnDolares = new DeudaEnDolares(montoDeuda, fechaInicio, cotizacionMock.Object);

            //act

            var actual = deudaEnDolares.GetDeudaEnPesosPorFecha(fechaFin);

            //Assert
            Assert.Equal(esperado, actual);

        }
    }
}
