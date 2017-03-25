using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1_UnitTesting.PruebasUnitarias.BLL
{
    public class QuizRead
    {
        public List<int> GetListaDiezActions()
        {
            var arrayAction = new Action[10];

            List<int> milista = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                arrayAction[i] = () => milista.Add(i);
            }

            foreach (var action in arrayAction)
            {
                action();
            }

            return milista;
        }

        /// <summary>
        /// Para comprobar si al hacer la prueba de equivalencia, no importa el orden en la lista.
        /// </summary>
        /// <returns></returns>
        public List<int> GetListaDiezActionsFormadaEnDosBloques()
        {
            var arrayAction = new Action[10];

            List<int> milista = new List<int>();

            //Al crear dos variables con distinto scope en cada fragmeto el delegado tiene valores distintos y no solo por la operación
            for (int i = 0; i < 5; i++)
            {
                arrayAction[i] = () => milista.Add(i + 1);
            }

            //En este caso cada vez que llamemos a estos 
            for (int i = 5; i < 10; i++)
            {
                arrayAction[i] = () => milista.Add(i - 1);
            }

            foreach (var action in arrayAction)
            {
                action();
            }

            return milista;
        }
    }
}
