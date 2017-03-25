using Demo2_SOLID.SOLID._00_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2_SOLID.SOLID._03_Liskov_Substitution_Principle
{
    /// <summary>
    /// También llamado diseño por contrato
    /// Habla de la importancia de crear todas las clases derivadas
    /// para que también puedan ser tratadas como la propia clase base.
    /// <seealso cref="http://librosweb.es/libro/tdd/capitulo_7/principios_solid.html"/>
    /// </summary>
    class LSPInfo : IInfo
    {
        /// <summary>
        /// Es un principio que...
        /// </summary>
        public IEnumerable<string> QueEs
        {
            get
            {
                return new[] {  @"Nos indica que no reimplementemos métodos que hagan que los métodos de la clase 
                                 base no funcionases si se tratasen como un objeto de esa clase base.",

                                @"Está diréctamente relacionado con el OCP. 
                                 Si una función no cumple el LSP entonces rompe el OCP puesto que para ser capaz 
                                 de funcionar con subtipos (clases hijas) necesita saber demasiado de la clase padre 
                                 y por tanto, modificarla."};
            }
        }

        /// <summary>
        /// No es un principio que...
        /// </summary>
        public IEnumerable<string> QueNoEs
        {
            get
            {
                return new[] { @"Nos dé la seguridad que las implementaciones de nuestras clases no serán
                                 modificadas indiréctamente. (Ejemplo new)" };
            }
        }

        /// <summary>
        /// Es un principio que se aplica cuando...
        /// </summary>
        public IEnumerable<string> CuandoAplicar
        {
            get
            {
                return new[] { "Cuando tengamos unidades de negocio Polimórficas" };
            }
        }

        /// <summary>
        /// Es un principio que nos ayuda a...
        /// </summary>
        public IEnumerable<string> ParaQueNosAyuda
        {
            get
            {
                return new[] { "Darle estabilidad al comportamiento de nuestros objetos" };
            }
        }
    }
}
