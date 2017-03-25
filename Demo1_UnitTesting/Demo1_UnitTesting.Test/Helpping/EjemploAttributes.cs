using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using System.Collections;
using System.Threading;
using Demo1_UnitTesting.PruebasUnitarias.Model;
using Demo1_UnitTesting.PruebasUnitarias.BLL;



namespace Demo1_UnitTesting.Test.Helpping
{
    [Category("Helpping Test and TestCase and TestCaseSource")]
    [TestFixture]
    public class EjemploAttributes
    {
        /// <summary>
        /// El atributo test, nos marca el método como Test. 
        /// En este caso probaremos una simple suma
        /// </summary>
        [Test]
        public void ExampleAttributes_00_EjemploTestAttribute()
        {
            var sut = new CalculadoraRead();

            var result = sut.Sumar(2, 3);

            Assert.AreEqual(result, 5);
        }


        /// <summary>
        /// TestCase además de marcarnos el método como un caso de Test, 
        /// nos proporciona los datos con los que vamos a ejecutar dicho Test
        /// En este caso nos proporcionaremos parámetros.
        /// </summary>
        [TestCase(2, 3)]
        public void ExampleAttributes_01_EjemploTestCaseAttribute(int param1, int param2)
        {
            var sut = new CalculadoraRead();

            var result = sut.Sumar(param1, param2);

            Assert.AreEqual(result, 5);
        }

        /// <summary>
        /// Ejemplo de TestCase con parámetros. Nos marca el método como Test, 
        /// y nos proporciona los datos con los que se van a realizar los Test
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>    
        /// <param name="param3"></param>    
        [TestCase(12, 3, 4)]
        [TestCase(12, 2, 6)]
        [TestCase(12, 4, 3)]
        public void ExampleAttributes_02_EjemploTestCaseAttributeWithParams(int param1, int param2, int param3)
        {
            Assert.AreEqual(param3, param1 / param2);
        }

        /// <summary>
        /// Otra forma de hacer los Test es pasándole el resultado esperado. 
        /// Asi se simplifica un poco el método ya que no hace falta pasarle el resultado como parámetro
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [TestCase(10, 5, ExpectedResult = 15, Description = "Prueba TestCaseAttribute")]
        [TestCase(12, 3, ExpectedResult = 15)]
        public int ExampleAttributes_03_EjemploTestCaseAttributeWithParamsResult(int a, int b)
        {
            var sut = new CalculadoraRead();

            return sut.Sumar(a, b);

            // Ojo que aquí no hay Assert. Delegamos la comprobación al framework
        }


        /// <summary>
        /// Prueba con un test ignorado
        /// </summary>
        [Test]
        [Ignore("Ignore a test")]
        public void ExampleAttributes_04_IgnoredTest()
        {
            Console.WriteLine(" Este Test, ha sido ignorado, y no se ejecuta!!!! Pon un punto de interrupción y dale al debug");
        }


        /// <summary>
        /// Ejecutará el test con todas sus COMBINACIONES
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        [Category("Helpping Attributo Pairwise")]
        [Test, Pairwise]
        public void ExampleAttributes_05_Pairwise(
            [Values("a", "b", "c")] string a,
            [Values("+", "-")] string b,
            [Values("x", "y")] string c)
        {
            Console.WriteLine("{0} {1} {2}", a, b, c);
        }


        // Test parametrizados
        // Ojo, si buscas referencias, no las vas a encontrar
        // CodeMaid --> Reordenar código
        static object[] CasosSuma =
        {
            new object[] {2,2,4 },
            new object[] {3,3,6 },
            new object[] {4,3,7 },
        };

        /// <summary>
        /// Se utiliza en test parametrizados para identificar la propiedad, 
        /// el método o el campo que proveeran los argumentos. En este caso, 
        /// utilizará como parámetros el objeto CasosSuma
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        [Test, TestCaseSource("CasosSuma")]
        public void ExampleAttributes_06_SumaEnteros(int x, int y, int z)
        {
            Assert.AreEqual(z, x + y);
        }


        /// <summary>
        /// Ejemplo de test con llamada a una clase externa. 
        /// Se llama a la clase externa ExampleAttributes_ClasExterna y se se ejecuta el con interfaz TestCases 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        [Test, TestCaseSource(typeof(EjemploAttributesClaseExterna), "TestCases")]
        public int ExampleAttributes_07_TestClaseExterna(int n, int d)
        {
            var sut = new CalculadoraRead();

            return sut.Dividir(n, d);

            // Ojo que aquí no hay Assert. Delegamos la comprobación al framework
        }

        /// <summary>
        /// RandomAtribute
        /// Nos genera 8 casos de prueba con un número aleatorio 
        /// Entre -1 como mínimo y 1 como máximo.
        /// Se le debe de indicar un mínimo, un máximo y el número de repeticiones del Test
        /// </summary>
        /// <param name="x"></param>
        /// <param name="d"></param>
        [Category("Helpping Attributo Values and Random")]
        [Test]
        public void ExampleAttributes_08_TestConRandom(
                    [Values(1, 2, 3)] int x,
                    [Random(-1.0, 1.0, 8)] double d)
        {
            Console.WriteLine(" Resultado ." + (x * d).ToString());
        }

        /// <summary>
        ///  RangeAttribute
        ///  Se indica un rango para realizar las pruebas.
        ///    Es equivalente a ejecutar 9 veces
        ///    MyTest(1, 0.2)
        ///     MyTest(1, 0.4)
        ///     MyTest(1, 0.6)
        ///     MyTest(2, 0.2)
        ///     MyTest(2, 0.4)
        ///     MyTest(2, 0.6)
        ///     MyTest(3, 0.2)
        ///     MyTest(3, 0.4)
        ///     MyTest(3, 0.6
        /// </summary>
        /// <param name="x"></param>
        /// <param name="d"></param>
        [Category("Helpping Attributo Values and Range")]
        [Test]
        public void ExampleAttributes_09_TestConRango([Values(1, 2, 3)] int x, [Range(0.2, 0.6, 0.2)] double d)
        {
            Console.WriteLine(" Resultado ." + (x * d).ToString());
        }


        /// <summary>
        /// Test donde un parámetro se generará de forma random y el otro dentro de un rango
        /// </summary>
        /// <param name="x"></param>
        /// <param name="d"></param>
        [Category("Helpping Attributo Random and Range")]
        [Test]
        public void ExampleAttributes_10_TestRandomRange([Random(-5, 5, 5)] double x, [Range(0.2, 0.6, 0.2)] double d)
        {
            Console.WriteLine(" Resultado ." + (x * d).ToString());
        }

        /// <summary>
        /// Test con un tiempo máximo de ejecución. 
        /// Si se supera el tiempo dará el Test como fallido
        /// </summary>
        [Test, MaxTime(2000)]
        public void ExampleAttributes_11_TimedTest()
        {
            int milliseconds = 1999;
            // ojo con lo pulcro que quieras ser en el timeout
            // prueba a poner 1995 (depende de la máquina no te funcionará)
            // prueba a poner 1999...
            Thread.Sleep(milliseconds);
        }

        /// <summary>
        /// Ejemplo donde se tipa el tipo de parámetro del TextFixture        
        /// </summary>
        /// <typeparam name="TList"></typeparam>
        [Category("Helpping Listas tipadas Array and List")]
        [TestFixture(typeof(ArrayList))] // Tipado a un array de listas. Crea una prueba para el array de lsitas
        [TestFixture(typeof(List<int>))] // Tipado a una lista de enteros. Crea una prueba para la lista de enteros
        public class IList_Tests<TList> where TList : IList, new()
        {
            private IList list;

            [Test]
            public void ExampleAttributes_12_TextFixtureTipada()
            {
                //Install - Package Bitoxygen.Testing.Pane
                Output.Testing.Trace.WriteLine(list.GetType().ToString());
                
                list.Add(1); list.Add(2); list.Add(3);
                Assert.AreEqual(3, list.Count);
            }

            [SetUp]
            public void ExampleAttributes_CreateList()
            {
                this.list = new TList();
            }
        }

        /// <summary>
        /// Tipado a una lista de enteros. Crea una prueba para la lista de enteros
        /// </summary>
        [Category("Helpping Setup una vez para cada test")]
        [TestFixture] 
        public class EjemploSetupTodosLosTest
        {
            List<int> lista;

            /// <summary>
            /// Lista se configura en cada TEST
            /// </summary>
            [SetUp]
            public void Setup_EjemploSetupTodosLosTest()
            {
                lista = new List<int>();
            }

            [Test]
            public void TestUno()
            {
                lista.Add(1);
                lista.Should().NotBeNullOrEmpty();
            }

            [Test]
            public void TestDos()
            {
                lista.Add(1);
                lista.Should().NotBeNullOrEmpty();
            }
        }

        /// <summary>
        /// Tipado a una lista de enteros. Crea una prueba para la lista de enteros
        /// </summary>
        [Category("Helpping Setup una vez para todos los test")]
        [TestFixture]
        public class EjemploSetupUnaVezParaTodosLosTest
        {
            List<int> lista;

            /// <summary>
            /// Lista se configura una vez para TODOS LOS TEST
            /// TestFixtureSetUp --> Obsolete. Usar OneTimeSetUp
            /// </summary>
            [OneTimeSetUp]
            public void Setup_EjemploSetupTodosLosTest()
            {
                lista = new List<int>();
            }

            [Test]
            public void TestUno()
            {
                lista.Add(1);
                lista.Should().NotBeNullOrEmpty();
            }

            [Test]
            public void TestDos()
            {
                lista.Add(1);
                lista.Should().NotBeNullOrEmpty();
            }
        }

        /// <summary>
        /// TextFixture: Este atributo, nos marca que la clase tiene test y que puede tener setup o teardown métodos.
        /// Se inicializan 3 Test casos de uso
        /// </summary>
        [Category("Helpping Attributo TestFixture ctor")]
        [TestFixture("hello", "hello", "goodbye")]
        [TestFixture("zip", "zip")]
        [TestFixture(42, 42, 99)]
        public class ParameterizedTestFixture
        {
            private string eq1;
            private string eq2;
            private string neq;

            public ParameterizedTestFixture(string eq1, string eq2, string neq)
            {
                this.eq1 = eq1;
                this.eq2 = eq2;
                this.neq = neq;
            }

            public ParameterizedTestFixture(string eq1, string eq2)
                : this(eq1, eq2, null) { }

            public ParameterizedTestFixture(int eq1, int eq2, int neq)
            {
                this.eq1 = eq1.ToString();
                this.eq2 = eq2.ToString();
                this.neq = neq.ToString();
            }

            [Test]
            public void ExampleAttributes_13_TestEquality()
            {
                Assert.AreEqual(eq1, eq2);
                if (eq1 != null && eq2 != null)
                    Assert.AreEqual(eq1.GetHashCode(), eq2.GetHashCode());
            }

            [Test]
            public void ExampleAttributes_14_TestInequality()
            {
                Assert.AreNotEqual(eq1, neq);
                if (eq1 != null && neq != null)
                    Assert.AreNotEqual(eq1.GetHashCode(), neq.GetHashCode());
            }
        }
    }
}
