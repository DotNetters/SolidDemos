using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2_SOLID.SOLID._03_Liskov_Substitution_Principle
{
    namespace Ex1_ElSuperEvidente
    {
        /// <summary>
        /// Al implementar la clase derivada si se reemplaza la funcionalidad de la clase base entonces
        /// podría tener efectos secundarios no deseados cuando tales clases derivadas se usen en 
        /// otros módulos.
        /// </summary>
        public class Cuadrado : Rectangulo
        {
            /// <summary>
            /// Esta clase modifica la funcionalidad de la clase base en lugar de extender 
            /// la funcionalidad de la clase base
            /// </summary>
            /// <param name="height"></param>
            public override void SetAlto(int height)
            {
                ancho = height;
                alto = height;
            }

            /// <summary>
            /// La implementación de métodos afectará la funcionalidad de la clase base.
            /// </summary>
            /// <param name="width"></param>
            public override void SetAncho(int width)
            {
                ancho = width;
                alto = width;
            }
        }

        public class LSP
        {
            /// <summary>
            /// Según el principio de sustitución de Liskov "Los tipos derivados deben ser completamente 
            /// sustituibles por sus tipos básicos".
            /// </summary>
            /// <returns></returns>
            public static Rectangulo CrearInstancia()
            {
                bool condicionParaObtenerUnaFormaUOtra = false;
                if (condicionParaObtenerUnaFormaUOtra == true)
                {
                    return new Rectangulo();
                }
                else
                {
                    return new Cuadrado();
                }
            }
        }

        /// <summary>
        /// Si cualquier módulo está usando una clase base, entonces la referencia a esa clase base puede 
        /// ser reemplazada por una clase derivada sin afectar la funcionalidad del módulo. 
        /// O. 
        /// Al implementar las clases derivadas, se necesita asegurar que, las clases derivadas 
        /// simplemente extiendan la funcionalidad de las clases base sin reemplazar la funcionalidad 
        /// de las clases base.
        /// </summary>
        public class Rectangulo
        {
            protected int alto = 0;
            protected int ancho = 0;
            public virtual int GetArea()
            {
                return ancho * alto;
            }

            public virtual void SetAlto(int alto)
            {
                this.alto = alto;
            }

            public virtual void SetAncho(int ancho)
            {
                this.ancho = ancho;
            }
        }
    }

    /// <summary>
    /// ?
    /// </summary>
    namespace Ex2_ElNoTanEvidente
    {
        public class PersonaInfo
        {
            public int AniosDeExperiencia { get; set; }
            public int ID_Persona { get; set; }
            public virtual string GetDescripcion() { return "Una persona normal"; }

            public decimal GetPaga() { return AniosDeExperiencia * 1000; }
        }

        public class PintorInfo : PersonaInfo
        {
            public override string GetDescripcion()
            {
                return base.GetDescripcion() + " y de profesión pintor ;-)";
            }
        }

        public class PoliticoInfo : PersonaInfo
        {
            private int _AniosDeExperiencia;

            new public int AniosDeExperiencia
            {
                get => _AniosDeExperiencia;
                set => _AniosDeExperiencia = value < 5 ? 5 : value;
            }

            public override string GetDescripcion()
            {
                return base.GetDescripcion() + " ja ja ja";
            }
        }

        public class ServicioDeNominas
        {
            public void PagarAEmpleados()
            {
                // obtener listado de empleados
                var empleados = new List<PersonaInfo>()
                {
                    new PintorInfo() { ID_Persona = 1, AniosDeExperiencia = 3 },
                    new PoliticoInfo() { ID_Persona = 2, AniosDeExperiencia = 3 }
                };

                GirarNominas(empleados);
            }

            private void GirarNominas(List<PersonaInfo> empleados)
            {
                empleados.ForEach(empleado =>
                {
                    var paga = empleado.GetPaga();

                    // El resto ya lo sabemos.... veamos una prueba
                }
                );
            }
        }
    }
}
