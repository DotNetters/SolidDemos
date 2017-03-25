using Demo2_SOLID.SOLID._00_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2_SOLID.SOLID._02_Open_Closed_Principle
{
    /// <summary>
    /// Crear clases extensibles sin necesidad de entrar al código fuente a modificarlo
    /// <seealso cref="http://librosweb.es/libro/tdd/capitulo_7/principios_solid.html"/>
    /// </summary>
    class OCPInfo : IInfo
    {
        /// <summary>
        /// Es un principio que...
        /// </summary>
        public IEnumerable<string> QueEs
        {
            get
            {
                return new[]
                {
                    "Una clase debe estar abierta a extensiones pero cerrada a modificaciones" ,
                    "El comportamiento de una entidad debe poder ser alterado sin tener que modificar su propio código fuente"
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
                return new[] { @"Nos indique que debemos saber como va a evolucionar nuestro proyecto.
                        Llega un momento en que las necesidades pueden llegar a ser tan imprevisibles que nos 
                        topemos que con los métodos definidos en el interface o en los métodos extensibles, 
                        no sean suficientes para cubrir las necesidades. 
                        En este caso no habrá más remedio que ROMPER este principio y refactorizar" };
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
                    @"Como la totalidad del código no se puede ni se debe cerrar a cambios, el diseñador 
                     debe decidir contra cuáles protegerse mediante este principio. 
                     Su aplicación requiere bastante experiencia, no sólo por la dificultad de crear entidades 
                     de comportamiento extensible sino por el peligro que conlleva cerrar determinadas entidades 
                     o parte de ellas.",

                    "Varias técnicas",

                        @"Mediante herencia y redefinición de los métodos de la clase padre, 
                          donde dicha clase padre podría incluso ser abstracta.",

                        @"Inyectando dependencias que cumplen el mismo contrato /interfaz pero que 
                          implementan diferente funcionamiento. "
                };
            }
        }

        /// <summary>
        /// Es un principio que nos ayuda a...
        /// </summary>
        public IEnumerable<string> ParaQueNosAyuda
        {
            get
            {
                return new[] { "A cambiar el comportamiento de la clase sin que haya que tocar el código interno." };
            }
        }
    }
}
