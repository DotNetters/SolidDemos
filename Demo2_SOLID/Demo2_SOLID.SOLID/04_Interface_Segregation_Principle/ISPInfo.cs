using Demo2_SOLID.SOLID._00_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2_SOLID.SOLID._04_Interface_Segregation_Principle
{
    /// <summary>
    /// Cuando se definen interfaces estos deben ser específicos a una finalidad concreta.
    /// y que no obliguemos a los clientes a depender de clases o interfaces que no necesitan usar
    /// <seealso cref="http://librosweb.es/libro/tdd/capitulo_7/principios_solid.html"/>
    /// </summary>
    class ISPInfo : IInfo
    {
        /// <summary>
        /// Es un principio que...
        /// </summary>
        public IEnumerable<string> QueEs
        {
            get
            {
                return new[] { "Indica que no obliguemos a los clientes a depender de clases o interfaces que no necesitan usar" };
            }
        }

        /// <summary>
        /// No es un principio que...
        /// </summary>
        public IEnumerable<string> QueNoEs
        {
            get
            {
                return new[] { "Indique que una interfaz solo puede tener un método" };
            }
        }

        /// <summary>
        /// Es un principio que se aplica cuando...
        /// </summary>
        public IEnumerable<string> CuandoAplicar
        {
            get
            {
                return new[] { "Existan funciones reaprovechables en otras clases" };
            }
        }

        /// <summary>
        /// Es un principio que nos ayuda a...
        /// </summary>
        public IEnumerable<string> ParaQueNosAyuda
        {
            get
            {
                return new[] { "Evitar dependencias innecesarias entre clientes",
                               "Evitar una catástrofe frente a cambios en una interfaz o clase base"};
            }
        }
    }
}
