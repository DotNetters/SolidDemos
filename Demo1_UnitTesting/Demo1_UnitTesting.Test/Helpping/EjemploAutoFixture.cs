using FluentAssertions;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System.Collections.Generic;
using Demo1_UnitTesting.PruebasUnitarias.Model;
using Demo1_UnitTesting.PruebasUnitarias.BLL;

namespace Demo1_UnitTesting.Test{

    [Category("Helpping AutoFixture")]
    [TestFixture]
    public class Ejemplo_AutoFixture
    {
        //Ejemplos de las opciones con AutoFixture: https://github.com/AutoFixture/AutoFixture/wiki/Cheat-Sheet

        Fixture fixture = new Fixture();

        [TestCase]
        public void Pruebas_AutoFixture_Create_TestPrueba()
        {
            //Creamos un dato del tipo que queramos pero no le damos valores, los autogenera aleatoriamente
            int resultExpected = fixture.Create<int>();

            Ejemplo_AutoFixture_Class test = fixture.Create<Ejemplo_AutoFixture_Class>();

            //Podemos customizar la generación de tipos, en este caso numéricos para que lo haga de forma secuencial
            fixture.Customizations.Add(new Int32SequenceGenerator());

            var sut = test.Numero(resultExpected);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(resultExpected.GetType(), sut.GetType(), "No hemos obtenido el tipo esperado");
        }

        [TestCase]
        public void Pruebas_AutoFixture_Build_TestPrueba_TModel()
        {
            //Creamos un dato del tipo que queramos pero no le damos valores, los autogenera aleatoriamente
            //Quitaríamos la propiedades del NIF porque no pasarían la validación            
            PersonaInfo resultExpected = fixture.Build<PersonaInfo>().Without(persona => persona.PropiedadQuePuedeSerIgnorada).Create();

            Ejemplo_AutoFixture_Class test = fixture.Create<Ejemplo_AutoFixture_Class>();

            var sut = test.DatosPersona(resultExpected);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(resultExpected.GetType(), sut.GetType(), "No hemos obtenido el tipo esperado");
        }

        [TestCase]
        public void Pruebas_AutoFixture_Build_TestPrueba_TModel_OmitAutoProperties()
        {
            //Podemos inicializar las propiedades de un objeto con valores por defecto con la propiedad OmitAutoProperties()
            PersonaInfo resultExpected = fixture.Build<PersonaInfo>().OmitAutoProperties().Create();

            Ejemplo_AutoFixture_Class test = fixture.Create<Ejemplo_AutoFixture_Class>();

            var sut = test.DatosPersona(resultExpected);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(resultExpected.GetType(), sut.GetType(), "No hemos obtenido el tipo esperado");
        }

        [TestCase]
        public void Pruebas_AutoFixture_Build_TestPrueba_TModel_With()
        {
            //Permite dar un valor a una propiedad
            PersonaInfo resultExpected = fixture.Build<PersonaInfo>().With(persona => persona.Nombre, "NombrePersona")
                .Without(persona => persona.PropiedadQuePuedeSerIgnorada).Create();

            Ejemplo_AutoFixture_Class test = fixture.Create<Ejemplo_AutoFixture_Class>();

            var sut = test.DatosPersona(resultExpected);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreSame(resultExpected, sut, "No hemos obtenido el tipo esperado");
        }

        [TestCase]
        public void Pruebas_AutoFixture_Create_TestPrueba_NUnit()
        {
            int resultExpected = fixture.Create<int>();
            Ejemplo_AutoFixture_Class test = fixture.Create<Ejemplo_AutoFixture_Class>();

            var sut = test.Numero(resultExpected);
            Assert.AreEqual(resultExpected.GetType(), sut.GetType());
        }

        [TestCase]
        public void Pruebas_AutoFixture_AddMany_TestPrueba_TModel()
        {
            //Permite añadir una secuencia de objetos a una lista ya existente
            var list = new List<PersonaInfo>();

            var resultExpected = fixture.Build<PersonaInfo>().OmitAutoProperties().Create();
            fixture.RepeatCount = 3;
            fixture.AddManyTo(list);

            Ejemplo_AutoFixture_Class test = fixture.Create<Ejemplo_AutoFixture_Class>();

            var sut = test.CrearLista();
            sut.Should().BeOfType(list.GetType(), "No hemos obtenido el tipo esperado");
        }
    }
}

