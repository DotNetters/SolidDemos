using Demo2_SOLID.SOLID._00_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2_SOLID.SOLID._01_Single_Responsibility_Principle
{
    /// <summary>
    /// No debe haber nunca más de una razón para cambiar una clase.
    /// Cuanto más grande sea el archivo o la clase, más difícil será lograrlo.
    /// <seealso cref="http://en.wikipedia.org/wiki/Single_responsibility_principle"/>
    /// <seealso cref="http://librosweb.es/libro/tdd/capitulo_7/principios_solid.html"/>
    /// </summary>
    public class SRPInfo : IInfo
    {
        /// <summary>
        /// Es un principio que...
        /// </summary>
        public IEnumerable<string> QueEs
        {
            get
            {
                return new[] { "Nos indica que las clases solo deberían realizan tareas que sean de su responsabilidad." };
            }
        }

        /// <summary>
        /// No es un principio que...
        /// </summary>
        public IEnumerable<string> QueNoEs
        {
            get
            {
                return new[] { @"Indique que una clase solo tiene un método sino que todos ellos deberían estar 
                                 enfocados al mismo propósito" };
            }
        }

        /// <summary>
        /// Es un principio que se aplica cuando...
        /// </summary>
        public IEnumerable<string> CuandoAplicar
        {
            get
            {
                return new[] {
                    @"¿Creo una clase para realizar esto o lo pongo aquí? --> 
                      La respuesta debería ser siempre SI. 
                      O en su defecto refactorizar si lo vas a utilizar en otro sitio." };
            }
        }

        /// <summary>
        /// Es un principio que nos ayuda a...
        /// </summary>
        public IEnumerable<string> ParaQueNosAyuda
        {
            get
            {
                return new[] { "Destinar cada entidad a una finalidad sencilla y concreta",
                                "Tener métodos fáciles de detectar / encontrar",
                                "No memorizas ubicaciones, las deduces"};
            }
        }
    }
}
