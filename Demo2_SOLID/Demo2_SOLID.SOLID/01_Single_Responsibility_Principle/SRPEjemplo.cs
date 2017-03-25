using System;

namespace Demo2_SOLID.SOLID._01_Single_Responsibility_Principle
{
    namespace Ex1_ElSuperEvidente
    {
        class DataAccess
        {
            public static void InsertData()
            {
                Console.WriteLine("Data inserted into database successfully");
            }
        }

        /// <summary>
        /// La única responsabilidad del logger es guardar los inicios de sesión
        /// </summary>
        class Logger
        {
            public static void WriteLog(string usuario)
            {
                Console.WriteLine($"Inicio de sesión del usuario { usuario } a las :" + DateTime.Now.ToLongTimeString());
            }
        }
    }

    namespace Ex2_ElNoTanEvidente
    {
        public class EmpleadoInfo
        {
        }

        namespace AlgoHueleMal
        {
            /// <summary>
            /// Si cambiara la manera de almacenar y buscar empleados habría que cambiar la clase
            /// y si cambiara la forma en la que debemos calcular la nómina también, 
            /// por tanto no cumple con el SRP.
            /// </summary>
            public class Empleado
            {
                public EmpleadoInfo GetEmpleado(int userID)
                {
                    // Devuelve un empleado de BBDD a partir de su id...
                    return new EmpleadoInfo();
                }

                public double CalculaSueldo(int userID)
                {
                    // Busca un empleado y calcula su suelo
                    return 0.0;
                }
            }
        }

        namespace SOLID
        {
            public class Nominas
            {
                public double CalculaSueldo(int userID)
                {
                    // Busca un empleado y calcula su suelo
                    return 0.0;
                }
            }

            public class Empleado
            {
                public EmpleadoInfo GetEmpleado(int empleadoID)
                {
                    // Busca y devuelve un usuario de la BD...
                    return new EmpleadoInfo();
                }

                public double CalcularSalario(int empleadoID)
                {
                    var servicioDeNominas = new Nominas();
                    return servicioDeNominas.CalculaSueldo(empleadoID);
                }
            }

        }
    }

    namespace Ex3_Spaguetti
    {
        namespace BLL
        {
            public class Servicios
            {
                public class ServicioCobro
                {
                    public void Cobrar(Model.ReciboInfo recibo)
                    {
                        throw new NotImplementedException();
                    }
                }

                public class ServicioDAL
                {
                    public void Guardar(Model.SeguroInfo seguro)
                    {
                        throw new NotImplementedException();
                    }
                }

                public class ServicioImpresion
                {
                    public void Imprimir(Model.InformeInfo informe)
                    {
                        throw new NotImplementedException();
                    }
                }
            } 
        }

        namespace Model
        {
            public class SeguroInfo { }
            public class ReciboInfo { }
            public class InformeInfo { }
        }

        public class Spaguetti
        {
            public static void ContratarSeguro(Model.SeguroInfo seguro)
            {
                var servicioDAL = new BLL.Servicios.ServicioDAL();
                // operar para obtener una contrato...
                servicioDAL.Guardar(seguro);

                var servicioCobro = new BLL.Servicios.ServicioCobro();
                // operar para obtener el recibo a cobrar
                var recibo = new Model.ReciboInfo();
                servicioCobro.Cobrar(recibo);

                var servicioImpresion = new BLL.Servicios.ServicioImpresion();
                // operar para obtener los datos de impresión a partir del seguro
                var informe = new Model.InformeInfo();
                servicioImpresion.Imprimir(informe);
            }
        }

        public class SOLID
        {
            public static void ContratarSeguro(Model.SeguroInfo seguro)
            {
                Guardar(seguro);
                Cobrar(seguro);
                Imprimir(seguro);

            }

            private static void Imprimir(Model.SeguroInfo seguro)
            {
                var servicioImpresion = new BLL.Servicios.ServicioImpresion();
                // operar para obtener los datos de impresión a partir del seguro
                var informe = new Model.InformeInfo();
                servicioImpresion.Imprimir(informe);
            }

            private static void Cobrar(Model.SeguroInfo seguro)
            {
                var servicioCobro = new BLL.Servicios.ServicioCobro();
                // operar para obtener el recibo a cobrar
                var recibo = new Model.ReciboInfo();
                servicioCobro.Cobrar(recibo);
            }

            private static void Guardar(Model.SeguroInfo seguro)
            {
                var servicioDAL = new BLL.Servicios.ServicioDAL();
                // operar para obtener una contrato...
                servicioDAL.Guardar(seguro);
            }
        }

        


    }

    //Conclusión
    // Una clase solo debe tener una razón de cambio, si tiene más de una se debe evaluar su diseño.
    // Este principio se aplica a: métodos, clases, paquetes, módulos y sistemas.
    // Como principales beneficios tenemos que nos permite crear código acoplado y cohesivo. 
    // Se debe aplicar si se encuentran clases con nombres genéricos o en las cuales se haya implementado 
    // el anti patrón Spagethi Code. 
    // También tiene argumentos en contra que se generan muchas clases o que es difícil entender el diseño 
    // completo, pero tener más clases no significa necesariamente que el código es más complicado.
}
