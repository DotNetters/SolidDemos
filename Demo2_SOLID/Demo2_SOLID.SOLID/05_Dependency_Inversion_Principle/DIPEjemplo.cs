using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2_SOLID.SOLID._05_Dependency_Inversion_Principle
{

    namespace Ex1_Casa
    {
        namespace Acoplada
        {
            public class Puerta
            {
            }
            public class Ventana
            {
            }
            public class Casa
            {
                private Puerta _puerta;
                private Ventana _ventana;

                public Casa()
                {
                    _puerta = new Puerta();
                    _ventana = new Ventana();
                }
            }
        }

        namespace AcopladaPeroAbstracta
        {
            public interface IPuerta { }
            public interface IVentana { }

            public class Puerta : IPuerta
            {
            }
            public class Ventana : IVentana
            {
            }

            public class Casa
            {
                private IPuerta _puerta;
                private IVentana _ventana;

                public Casa()
                {
                    Puerta = new Puerta();
                    Ventana = new Ventana();
                }

                public IVentana Ventana { get => _ventana; set => _ventana = value; }
                public IPuerta Puerta { get => _puerta; set => _puerta = value; }
            }
        }

        namespace DesAcopladaEInyectada
        {
            public interface IPuerta { }
            public interface IVentana { }

            public class Puerta : IPuerta
            {
            }
            public class Ventana : IVentana
            {
            }

            public class Casa
            {
                private IPuerta _puerta;
                private IVentana _ventana;

                /// <summary>
                /// En este ejemplo están inyectadas en el ctor pero podrían estar perféctamente
                /// inyectadas en las propiedades.
                /// </summary>
                /// <param name="puerta"></param>
                /// <param name="ventana"></param>
                public Casa(IPuerta puerta, IVentana ventana)
                {
                    Puerta = puerta;
                    Ventana = ventana;
                }

                public IVentana Ventana { get => _ventana; set => _ventana = value; }
                public IPuerta Puerta { get => _puerta; set => _puerta = value; }
            }


            // Yo personalmente procuro inyectar en el ctor solo aquello que dependa de mi base. 
            // El resto por norma en propiedades.
            // Ojo, cuando entran en juego los IoC Containers esto cambia. Pero eso para otra charla ;-)
        }

    }
}
