using Demo1_UnitTesting.PruebasUnitarias.Model;
using Demo1_UnitTesting.PruebasUnitarias.BLL;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Demo1_UnitTesting.Test.BLL
{
    [TestFixture]
    [TestOf(typeof(PersonaRead))]
    [Category("UT Primeras pruebas PERSONA")]
    public class PersonaRead_Test
    {
        /// <summary>
        /// aunque filtrada está ordenada tiene los mismos elemntos que la original. Por eso son equivalentes.
        /// </summary>
        /// <param name="original"></param>
        [TestCaseSource("ListasTestOrigen")]
        public void OrdenarPorNombreYComprobarSonEquivalentes(List<PersonaInfo> original)
        {
            var sut = new PersonaRead();
            List<PersonaInfo> filtrada = sut.OrdenarPorNombre(original);
            filtrada.Should().BeEquivalentTo(original, "No es equivalente");
        }

        [TestCaseSource("ListasTestOrigen")]
        public void OrdenarPorNombreYComprobarEstaOrdenada(List<PersonaInfo> original)
        {
            var sut = new PersonaRead();
            List<PersonaInfo> filtrada = sut.OrdenarPorNombre(original);
            filtrada.Should().BeInDescendingOrder(Item => Item.Nombre, "No esta ordenada descendientemente");

        }

        [TestCaseSource("ListasTestOrigen")]
        public void OrdenarPorNombreYSacar3Primeras_FiltradaContienOriginal(List<PersonaInfo> original)
        {
            var sut = new PersonaRead();
            List<PersonaInfo> filtrada = sut.OrdenarPorNombreYObtener3Primeras(original);
            original.Should().Contain(filtrada);
            //Filtrada es un subconjunto de original, aunque no coincida el orden
        }

        [TestCaseSource("ListasTestOrigen")]
        public void Sacar3Primeras_ContienOriginalEnOrden(List<PersonaInfo> original)
        {
            var sut = new PersonaRead();

            List<PersonaInfo> filtrada = sut.ObtenerTresPrimeras(original);

            original.Should().ContainInOrder(filtrada);
        }

        [TestCaseSource("ListasTestOrigen")]
        public void Sacar3Primeras_ContienOriginal(List<PersonaInfo> original)
        {
            var sut = new PersonaRead();

            List<PersonaInfo> filtrada = sut.ObtenerTresPrimeras(original);

            original.Should().Contain(filtrada);
        }

        /// <summary>
        /// Dará siempre error ya que aunque el contenido sea el mismo el continente es distinto.
        /// Si evaluaramos el contenido de las listas veriamos que es igual: 
        /// result[1].Should().BeSameAs(filtrada[1]);
        /// Para evaluar listas utilizar BeEquivalentTo (Evalua el contenido y no importa el orden) 
        /// Contain (Contiene, no importa el orden) ContainInOrder (Si importa el orden)
        /// </summary>
        /// <param name="original"></param>
        [TestCaseSource("ListasTestOrigen")]
        public void Sacar3Primeras_TieneLaMismaReferencia(List<PersonaInfo> original)
        {
            var sut = new PersonaRead();
            List<PersonaInfo> filtrada = sut.ObtenerTresPrimeras(original);
            List<PersonaInfo> result = original.Take(3).ToList();
            result.Should().BeEquivalentTo(filtrada);
        }

        /// <summary>
        /// Se puede evaluar con expresiones regulares o con comodines
        /// Para expresiones regulares: MatchRegex
        /// Para no tener en cuenta mayusculas: MatchEquivalentOf (Sin expresiones regulares)
        /// </summary>
        /// <param name="original"></param>
        [TestCaseSource("ListasTestOrigen")]
        public void ModifcaCadena_ContieneCadena(List<PersonaInfo> original)
        {
            var sut = new PersonaRead();
            List<PersonaInfo> filtrada = sut.LaPruebaDeEstoFuncionaPeroDeChiripaYPorqueConozcoContenido(original);
            //List<PersonaInfo> filtrada = sut.EsteCodigoHaSidoLimpiado(original);
            filtrada.ForEach(item => item.Nombre.Should().Match("*visitado" + item.ID.ToString()));
        }

        /// <summary>
        /// Se puede evaluar con expresiones regulares o con comodines
        /// Para expresiones regulares: MatchRegex
        /// Para no tener en cuenta mayusculas: MatchEquivalentOf (Sin expresiones regulares)
        /// </summary>
        /// <param name="original"></param>
        [TestCaseSource("ListasTestOrigen")]
        public void ModifcaCadena_ContieneCadena_Refactorizado(List<PersonaInfo> original)
        {
            var sut = new PersonaRead();
            List<PersonaInfo> filtrada = sut.EsteCodigoHaSidoLimpiado(original);
            filtrada.ForEach(item => item.Nombre.Should().Match("*visitado" + item.ID.ToString()));
        }

        [TestCaseSource("ListasTestOrigen")]
        public void PruebaExcepciones_VerificarExcepcion(List<PersonaInfo> original)
        {
            var sut = new PersonaRead();
            Action act = () => sut.PersonasPruebaExcepciones(null);
            act.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Equals("message");
        }


        /// <summary>
        /// Descartado No utilizar BeSameAs para comparar Listas.Solo para asegurarse de que dos objetos son exactamente el mismo.
        /// Ver comentarios de la función..._Sacar3Primeras_TieneLaMismaReferencia
        /// </summary>
        /// <param name="original"></param>
        [TestCaseSource("ListasTestOrigen")]
        public void OrdenarPorNombreY_ComprobarSonIguales(List<PersonaInfo> original)
        {
            var sut = new PersonaRead();
            List<PersonaInfo> filtrada = sut.OrdenarPorNombre(original);
            filtrada.Should().NotBeSameAs(original, "Es igual");
        }



        /// <summary>
        /// Para las listas vamos a generar un origen de datos (Source) común para que todos los 
        /// métodos utilicen los mismos datos y hagan las mismas comprobaciones.
        /// Pueden ser una clase,propiedad o método de una clase.
        /// Tiene que ser estático,
        /// Tiene que ser Ienumerable o proporcionar un enumerador.
        /// Cada elemento de la enumeración es una lista de parámetros para el metodo que se quiere probar.
        /// </summary>
        /// <returns></returns>
        public static List<List<PersonaInfo>>/* object[]*/ ListasTestOrigen()
        {
            List<PersonaInfo> Caso_1 = new List<PersonaInfo>() {
                new PersonaInfo() {
                    ID = 1,
                    Nombre = "aaa",
                    Edad = 3
                },
                new PersonaInfo() {
                    ID = 2,
                    Nombre = "aaa",
                    Edad = 5
                },
                new PersonaInfo() {
                    ID = 6,
                    Nombre = "aba",
                    Edad = 2
                },
                new PersonaInfo() {
                    ID = 4,
                    Nombre = "aba",
                    Edad = 3
                },
                 new PersonaInfo() {
                    ID = 3,
                    Nombre = "aca",
                    Edad = 1
                }
                 ,
                 new PersonaInfo() {
                    ID = 5,
                    Nombre = "aza",
                    Edad = 8
                },
                 new PersonaInfo() {
                    ID = 7,
                    Nombre = "aza",
                    Edad = 9
                }
            };

            List<PersonaInfo> Caso_2 = new List<PersonaInfo>() {
                new PersonaInfo() {
                    ID = 1,
                    Nombre = "bbb",
                    Edad = 3
                },
                new PersonaInfo() {
                    ID = 2,
                    Nombre = "bcb",
                    Edad = 10
                },
                new PersonaInfo() {
                    ID = 6,
                    Nombre = "bab",
                    Edad = 5
                }

            };

            return new List<List<PersonaInfo>>
            {
                Caso_1,
                Caso_2
            };

        }


    }
}
