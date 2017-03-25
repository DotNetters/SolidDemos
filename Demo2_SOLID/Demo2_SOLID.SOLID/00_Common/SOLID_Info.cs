using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2_SOLID.SOLID._00_Common
{
    /// <summary>
    /// Es un acrónimo mnemónico introducido por Robert C. Martin a comienzos de la década del 2000
    /// que representa cinco principios básicos de la programación orientada a objetos y el diseño
    /// <seealso cref="https://es.wikipedia.org/wiki/SOLID"/>
    /// <seealso cref="https://msdn.microsoft.com/en-gb/en-en/magazine/dn683797.aspx"/>
    /// </summary>
    public class SOLID_Info : IInfo, ISugerencias
    {
        /// <summary>
        /// Es un conjunto de principios que 
        /// </summary>
        public IEnumerable<string> QueEs
        {
            get
            {
                return new[]
                {
                    "Se pueden aplicar en cualquier lenguaje orientado a objetos",
                    "Nos permite crear código fácil de mantener y extender. Por lo tanto somos más productivos",
                    "Nos garantiza que estamos trabajando de una forma orientada a objetos"
                };
            }
        }

        /// <summary>
        /// Es un conjunto de principios que
        /// </summary>
        public IEnumerable<string> QueNoEs
        {
            get
            {
                return new[]
                {
                    "No es algo exclusivo de .NET (no está vinculado a ninguna tecnología)",
                    "No es un framework",
                    "No son Reglas, son guias", // Ejemplo modelo de negocio
                };
            }
        }

        /// <summary>
        /// Sugerencias para aplicar estos principios
        /// </summary>
        public IEnumerable<string> Sugerencias
        {
            get
            {
                return new[] {
                    "Las partes más críticas no deben, tienen que contar con pruebas unitarias",
                    "El equipo tiene que tener una guía de buenas prácticas y motivación para mejorarla",
                    "Ojo, no nos pasemos de mejorar. Hay que buscar el equilibrio entre maestría y complejidad innecesaria",
                    @"Nada te impide que haya algo que no cuadra, si lo detectas no lo dejes pasar 
                     (refactoriza, invierte tiempo, pon un #warning). Lo agradecerás",
                    @"Si tienes una idea, cocinala, si es muy abstracta o compleja, si puede ser en compañía mejor,
                     pero sobre todo deja que repose y mira que todo está bien al emplatar.
                     Si te la juegas a improvisar en un banquete tienes muchas papeletas 
                     para salir mal parado ;-)
                     Utilizar Aplazamientos y Code Reviews para eso los tenemos",
                };
            }
        }

        /// <summary>
        /// Los principios SOLID nacieron como una reacción a los (design smells).
        /// Es decir la violación de algún principio del diseño orientado a objetos.      
        /// <seealso cref="https://en.wikipedia.org/wiki/Design_smell"/>
        /// <seealso cref="http://mhjongerius.tumblr.com/post/61853273412/the-seven-design-smells-of-rotting-software"/>
        /// <seealso cref="https://es.slideshare.net/gvespucci/design-smells"/>
        /// </summary>
        public IEnumerable<string> CuandoAplicar
        {
            get
            {
                return new[]
                {
                    "Rigidez",      // Soft dificil de cambiar aun con cambios simples. Hard to change.
                    "Fragilidad",   // Cambio sencillo = roto en muchos lugares. Easy to break.
                    "Inmovilidad",  // Se pueden utilizar partes pero es dificil desenredar. Hard to reuse
                    "Viscosidad",   // Hacer las cosas mal es más fácil que hacer las cosas bien
                        "Software V.", // El diseño hace que sea difícil hacer lo correcto. Multiples formas de hacer lo mismo
                        "Environment V.", // Desarrollo lento, compilaciones largas, horas para check-in, mucho tiempo para desplegar
                    "Complejidad innecesaria", // Soportar necesidades que no existen ni van a existir
                    "Repetición innecesaria", // Estructuras repetidas puedes ser unificadas para una abstracción simple
                            // CTRL-C + CTRL-V --> Buscar un bug repetido en el sistema
                            // CTRL-C + CTRL-V --> Muy últil para editar texto pero desastroso para editar código
                    "Opacidad"     // Código dificil de entender. Si me ha costado tanto hacerlo, al que lo lea que le cueste leerlo
                        // El código evoluciona y si lo hace de manera compleja es dificil darle nueva funcionalidad
                        //
                };
            }
        }

        public IEnumerable<string> ParaQueNosAyuda
        {
            get
            {
                return new[] {
                    "Evita crear clases con cientos / miles de lineas", // Si creas clases con un solo propósito es mucho más dificil
                    "Evita crear clases con multiples funcionalidades", // Log, gestión de excepciones, sesión, mail
                    "Métodos con múltiples estructuras de control (if, switch)", // Pánico a los ifs dentro de ifs
                    "Evita crear código repetido", // si lo tienes que modificar o tiene un error te entra una mala leche...
                    "Evita crear código que no vayas a entender en el futuro", // Eso duele
                    "Evita tener miedo a los cambios" // Si al tocar aquí se estropea allá tenemos un problema
                };
            }
        }
    }
}
