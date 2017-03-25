using Demo1_UnitTesting.PruebasUnitarias.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo1_UnitTesting.PruebasUnitarias.BLL
{
    public class CalculadoraRead
    {
        /// <summary>
        /// Realiza el cuadrado de un número entero cualquiera
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public int Cuadrado(int numero)
        {
            return numero * numero;
        }

        /// <summary>
        /// Realiza el producto de dos numeros enteros cualquiera.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public int Producto(int p1, int p2)
        {
            return p1 * p2;
        }

        /// <summary>
        /// Tiene que aceptar solo números positivos. 
        /// Si hay negativos dará una excepción, el resultado ha de ser un entero, 
        /// el resultado es el producto de los parámetros de entrada.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public int ProductoPositivo(int p1, int p2)
        {
            if (p1 < 0 || p2 < 0)
            {
                throw new ExcepcionNumeroNegativoInfo();
            }

            return p1 * p2;
        }

        /// <summary>
        /// Hay que implementar la función y realizar las pruebas.
        /// </summary>
        public void RaizCuadrada()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Realiza la suma de dos numeros enteros cualquiera
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public int Sumar(int p1, int p2)
        {
            return p1 + p2;
        }


        /// <summary>
        /// Realiza la división de dos numeros enteros cualquiera
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public int Dividir(int p1, int p2)
        {
#warning Ups creo que aquí hay un fallo pero me da miedito tocarlo...

            return p1 + p2;
        }
    }
   
}
