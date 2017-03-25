using Demo2_SOLID.SOLID._00_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2_SOLID.SOLID._05_Dependency_Inversion_Principle
{
    /// <summary>
    /// Desacoplar clases mediante el uso de aabstracciones
    /// </summary>
    class DIPInfo : IInfo
    {
        /// <summary>
        /// Es un principio que...
        /// </summary>
        public IEnumerable<string> QueEs
        {
            get
            {
                return new[] {
                    "Facilita que las clases de nivel superior no conozcan las clases de nivel inferior",
                    "Requiere más esfuerzo al diseñar los módulos",
                    "Da origen a la inyección de dependencias y contenedores" // Esto da para otra charla...
                };
            }
        }

        /// <summary>
        /// No es un principio que...
        /// </summary>
        public IEnumerable<string> QueNoEs
        {
            get
            {
                return new[] { @"Indique que no haya ningún acoplamiento. Es decir, nos obligue a inyectar todo. 
                                 No todo son enchufes en una casa. 'También hay pilares'",

                                @"Sea fácil de aplicar sin experiencia debido a la complejidad 
                                para entender el panorama general del diseño"};
            }
        }

        /// <summary>
        /// Es un principio que se aplica cuando...
        /// </summary>
        public IEnumerable<string> CuandoAplicar
        {
            get
            {
                return new[] { "Se necesitan desacoplar piezas de la solución que pueden cambiar en el futuro",
                               "El nivel de acoplamiento en el código es alto." };
            }
        }

        /// <summary>
        /// Es un principio que nos ayuda a...
        /// </summary>
        public IEnumerable<string> ParaQueNosAyuda
        {
            get
            {
                return new[] {
                    "Bajo acoplamiento",
                    "Testeabilidad",
                    "Flexibilidad"
                };
            }
        }
    }
}
