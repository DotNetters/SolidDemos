using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using NUnit.Framework;
using Demo2_SOLID.SOLID._03_Liskov_Substitution_Principle.Ex1_ElSuperEvidente;


namespace Test._03_Liskov_Substitution_Principle
{
    [TestFixture]
    [Category("SOLID LSP")]
    public class LSP_Test
    {
        [Test]
        public void GetPagaPersona()
        {
            var sut = new Demo2_SOLID.SOLID._03_Liskov_Substitution_Principle.Ex2_ElNoTanEvidente.PersonaInfo()
            {
                AniosDeExperiencia = 3
            };

            var paga = sut.GetPaga();

            paga.Should().Be(3000M);
        }


        [Test]
        public void GetPagaPolitico()
        {
            var sut = new Demo2_SOLID.SOLID._03_Liskov_Substitution_Principle.Ex2_ElNoTanEvidente.PoliticoInfo()
            {
                AniosDeExperiencia = 3
            };

            var paga = sut.GetPaga();

            paga.Should().Be(5000M);
        }

        [Test]
        public void GetArea()
        {
            Rectangulo rectangulo = Demo2_SOLID.SOLID._03_Liskov_Substitution_Principle.Ex1_ElSuperEvidente.LSP.CrearInstancia();

            // Se asume que el objeto con el que trabajamos es un rectángulo. Por lo tanto..
            rectangulo.SetAncho(5);
            rectangulo.SetAlto(10);

            rectangulo.GetArea().Should().Be(50);
        }
    }
}
