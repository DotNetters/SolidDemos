using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using NUnit.Framework;
using Demo2_SOLID.SOLID._04_Interface_Segregation_Principle.Ex1_Segregado;

namespace Test._04_Interface_Segregation_Principle
{
    [TestFixture]
    [Category("SOLID ISP")]
    public class ISP_Test
    {
        [Test]
        public void TestSQL()
        {
            var sut = new SqlDataClient();

            Action act = () =>
            {
                sut.OpenConnection();
                sut.ExecuteSqlCommand();
                sut.CloseConnection();
            };

            act.ShouldNotThrow<Exception>("No ha superado la validación de SQL");
        }

        [Test]
        public void TestOracle()
        {
            var sut = new OracleDataClient();

            Action act = () =>
            {
                sut.OpenConnection();
                sut.ExecuteOracleCommand();
                sut.CloseConnection();
            };

            act.ShouldNotThrow<Exception>("No ha superado la validación de Oracle");
        }
    }
}
