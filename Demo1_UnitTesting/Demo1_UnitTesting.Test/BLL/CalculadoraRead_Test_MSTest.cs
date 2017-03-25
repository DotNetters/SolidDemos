
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Demo1_UnitTesting.PruebasUnitarias.Model;
using Demo1_UnitTesting.PruebasUnitarias.BLL;

namespace Demo1_UnitTesting.Test.BLL
{
    
    [TestClass()]
    public class CalculadoraRead_Test_MSTest
    {
        [TestCategory("MSTest")]
        [TestMethod(), Description("Prueba")]
        public void CalculadoraMSTest_SumaTest()
        {
            var micalculadora = new CalculadoraRead();
            int p1 = 1;
            int p2 = 1;
            int expectedResult = p1 + p2;
            int result;
            result = micalculadora.Sumar(p1, p2);

            result.Should().Be(expectedResult, "La suma ha fallado");

        }

        [TestCategory("MSTest")]
        [TestMethod()]
        public void CalculadoraMSTest_SumaTestGeneral(int p1, int p2)
        {
            var sut = new CalculadoraRead();
            int expectedResult = p1 + p2;
            int result;
            result = sut.Sumar(p1, p2);

            result.Should().Be(expectedResult, "La suma ha fallado");
        }
    }
}
