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
    [TestOf(typeof(QuizRead))]
    public class QuizRead_Test
    {
        /// <summary>
        /// Son equivalentes ya que contienen la misma información
        /// (No importa ni el orden ni la posición en memoria)
        /// </summary>
        [Test]
        public void EjecutarAccion2_ObjetoEquivalente()
        {
            var sut = new QuizRead();
            List<int> expected_result = ObtenLista10ElementosConValor10();
            List<int> result_list = sut.GetListaDiezActions();
            result_list.Should().BeEquivalentTo(expected_result);
        }

        [Test]
        public void EjecutarAccion2_ObjetoNoEsIgual_AunqueTengaLosMismosValores()
        {
            var sut = new QuizRead();
            List<int> expected_result = ObtenLista10ElementosConValor10();
            List<int> result_list = sut.GetListaDiezActions();
            result_list.Should().NotBeSameAs(expected_result);
        }

        [Test]
        public void EjecutarAccion2_TipoListaEnteros()
        {
            var sut = new QuizRead();
            List<int> expected_result = ObtenLista10ElementosConValor10();
            List<int> result_list = sut.GetListaDiezActions();
            result_list.Should().BeOfType<List<int>>("No es una lista de enteros");
            //Comprobamos el tipo de salida.
        }

        /// <summary>
        /// Tambien se puede indicar una fuente que genera los datos de prueba. 
        /// Puede ser una clase, una propiedad o un método. Se le puede pasar el tipo y el nombre de la propiedad, 
        /// método que va a devolver los datos. 
        /// La propiedad o método siempre ha de ser estática.
        /// </summary>
        /// <param name="expected_result"></param>
        [TestCaseSource("GeneradorDeListasEnteros")]
        public void EjecutarAccion2_TipoListaEnterosExternalSource(List<int> expected_result)
        {
            var sut = new QuizRead();
            List<int> result_list = sut.GetListaDiezActions();
            result_list.Should().BeEquivalentTo(expected_result);
        }

        [Test]
        public void EjecutarAccion3_ObjetoEquivalente()
        {
            List<int> expected_result = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                expected_result.Add(9);
            }
            for (int i = 5; i < 10; i++)
            {
                expected_result.Add(6);
            }
            var sut = new QuizRead();
            List<int> result_list = sut.GetListaDiezActionsFormadaEnDosBloques();
            result_list.Should().BeEquivalentTo(expected_result);
            //Son equivalentes ya que contienen la misma información (No importa ni el orden ni la posición en memoria)
            //En este caso se ha modificado el orden de la lista al generarla y sigue pasando el test            
        }

        private static Object[] GeneradorDeListasEnteros()
        {
            return new object[] { GetListInt(10).ToList() };
        }

        private static IEnumerable<int> GetListInt(int size)
        {
            for (int i = 0; i < size; i++)
            {
                yield return size;
            }
        }

        private static List<int> ObtenLista10ElementosConValor10()
        {
            List<int> expected_result = new List<int>();
            //Construimos una lista tal y como la esperamos.
            for (int i = 0; i < 10; i++)
            {
                //El valor es 10 por que es el que va a escribir el código de la función.
                expected_result.Add(10);
            }

            return expected_result;
        }
    }
}
