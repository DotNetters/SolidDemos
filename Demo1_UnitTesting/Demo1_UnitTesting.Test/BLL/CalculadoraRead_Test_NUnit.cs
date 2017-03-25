using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo1_UnitTesting.PruebasUnitarias.Model;
using Demo1_UnitTesting.PruebasUnitarias.BLL;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Serialization;

namespace Demo1_UnitTesting.Test.BLL
{
    [TestOf(typeof(CalculadoraRead))]
    [TestFixture]
    public class CalculadoraRead_Test_NUnit
    {
        // Un poquito de teoría...

        // BUG en NUnit3TestAdapter.2.0.8.rtp.8/lib
        // else archivo ignore.addins--> borrar el contenido
        // users..appdata\local\test\vstestexploreextensions\NUnitTestAdapter --> borrar carpeta

        // Assert.That(result, Is.EqualTo(3)); --> Mucho más amigable FluentAssertions

        // Autofixture --> Te crea automáticamente los datos e infiere

        // Deben poder lanzarse en paralelo. Dentro de la misma clase.

        /*
         FIRST
         * FAST
         * ISOLATED
         * REPEATABLE
         * SELF-VALIDATING --> Resultado booleano
         *  no logs, no db, etc
         *  automático (NO REQUIERE COMPROBACIÓN MANUAL
         * TIMELY --> Serán construidos en el momento oportuno
         */

        [Category("UT Calculadora Función Cuadrado")]
        public class Cuadrado
        {
            [TestCase(1)]
            [TestCase(3)]
            public void Cuadrado_Should_ReturnRightValue(int s1)
            {
                var sut = new CalculadoraRead();
                var result = sut.Cuadrado(s1);
                var expectedResult = s1 * s1;
                result.Should().Be(expectedResult, "el cuadrado ha fallado");
            }

            /// <summary>
            /// Podemos comprobar si el resultado es un número positivo        
            /// </summary>
            /// <param name="s1">Añadimos al range un inicio negativo para cubrir toda clase de números desde -5 a +5</param>
            [Test]
            public void Cuadrado_Should_ReturnBePositive([Range(-5, 5, 1)]int s1)
            {
                var sut = new CalculadoraRead();
                var result = sut.Cuadrado(s1);
                var expectedResult = s1 * s1;
                result.Should().BeGreaterOrEqualTo(0, "El cuadrado de un número Natural es positivo");
            }

            [Test]
            public void CuadradoRandom_Should_ReturnRightValue([Random(1, 20, 5)]int s1)
            {
                var sut = new CalculadoraRead();
                var result = sut.Cuadrado(s1);
                var expectedResult = s1 * s1;
                result.Should().Be(expectedResult, "el cuadrado ha fallado");
            }

            [TestCase(-3, 3)]
            public void Producto_Negativo(int s1, int s2)
            {
                var sut = new CalculadoraRead();
                Action act = () => sut.ProductoPositivo(s1, s2);
                act.ShouldThrow<ExcepcionNumeroNegativoInfo>();
            }

            [TestCase(3, 3)]
            public void Producto_Positivo(int s1, int s2)
            {
                var sut = new CalculadoraRead();
                var result = sut.ProductoPositivo(s1, s2);
                var expectedResult = s1 * s2;
                result.Should().Be(expectedResult, " El producto de dos números no coincide");
            }
        }

        [Category("UT Calculadora Función Raiz Cuadrada")]
        public class RaizCuadrada
        {
            [NUnit.Framework.Ignore("Test verde ignorado")]
            [Test]
            public void Verde()
            {
                // Esta prueba no hace nada

                // Un test sin assert es un test verde
            }

            //!!! Hay que implementar estas pruebas!!!!
        }

        [Category("UT Calculadora Función Suma")]
        public class Suma
        {
            /// <summary>
            /// TestCase es un atributo de Nunit que indica que el proceso es un prueba.
            /// Si a test case se le pasan parámetros los utilizará en las pruebas para pasarselos al proceso.
            /// Cada test case con parametros lanzará una prueba.
            /// </summary>
            /// <param name="s1"></param>
            /// <param name="s2"></param>
            [TestCase(1, 1)]
            [TestCase(1, 3)]
            public void Suma_Should_ReturnRightValue(int s1, int s2)
            {
                var sut = new CalculadoraRead();
                var result = sut.Sumar(s1, s2);
                var expectedResult = s1 + s2;
                result.Should().Be(expectedResult, "La suma ha fallado");
            }


            [TestCase(1, 1, 2)]
            [TestCase(1, 3, 4)]
            public void Suma_Should_ReturnRightValueExpected(int s1, int s2, int expectedResult)
            {
                var sut = new CalculadoraRead();
                var result = sut.Sumar(s1, s2);
                result.Should().Be(expectedResult, "La suma ha fallado");
            }


            /// <summary>
            /// TestCase también se puede utilizar sin parámetros. En este caso los parámetros los pasamos en la declaración del proceso.
            /// Los argumentos se pueden pasar en la declaración. Se ejecutan tantos test como combinaciones de argumentos haya.
            /// DATA FOR ONE ARGUMENT*****
            /// Values El más elemental, se poneen los valores individuales separados por comas.
            /// Random (limiteinferior,limitesuperior,numdatos) se toman tantos argumentos como indica la última variable que se encuentren entre los dos límites. 
            /// Range (inicio,fin,incremento) se genera un argumento desde el dato de inicio hasta el dato de fin con el incremento que se indica.   
            /// </summary>
            /// <param name="s1"></param>
            /// <param name="s2"></param>
            [Test]
            public void Suma_Should_ReturnRightValueInlineRandom([Values(1, 3)]int s1, [Random(1, 100, 3)]int s2)
            {
                var sut = new CalculadoraRead();
                var result = sut.Sumar(s1, s2);
                var expectedResult = s1 + s2;
                result.Should().Be(expectedResult, "La suma ha fallado");

                //COMPLETE*****
                //TestCase (Values)   Attribute
                //El atribute TestCase se aplica a un método con parámetros, Lo marca como un test    
                //TestCaseSource (source) [Attribute]

                //DATA FOR ONE ARGUMENT*****
                //RandomAttribute
                //RangeAttribute
                //ValuesAttribute

                //ValueSourceAttribute
            }

            /// <summary>
            /// Con el atributo Test indicamos que es una prueba.
            /// En este caso los parámetros los generamos en la propia declaración del proceso.
            /// </summary>
            /// <param name="s1"></param>
            /// <param name="s2"></param>
            [Test]
            public void Suma_Should_ReturnRightValueInlineRange([Values(1, 3)]int s1, [Range(1, 5, 1)]int s2)
            {
                var sut = new CalculadoraRead();
                var result = sut.Sumar(s1, s2);
                var expectedResult = s1 + s2;
                result.Should().Be(expectedResult, "La suma ha fallado");
            }
        }
    }

}
