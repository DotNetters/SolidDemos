using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2_SOLID.SOLID._02_Open_Closed_Principle
{

    namespace Ex1_ElSuperEvidente
    {
        abstract class DataProvider
        {
            public abstract int CloseConnection();

            public abstract int ExecuteCommand();

            public abstract int OpenConnection();
        }

        class OpenClosePrincipleDemo
        {
            public static void OSPDemo()
            {
                Console.WriteLine("\n\nOpen Close Principle Demo ");

                DataProvider DataProviderObject = new SqlDataProvider();
                DataProviderObject.OpenConnection();
                DataProviderObject.ExecuteCommand();
                DataProviderObject.CloseConnection();

                DataProviderObject = new OracleDataProvider();
                DataProviderObject.OpenConnection();
                DataProviderObject.ExecuteCommand();
                DataProviderObject.CloseConnection();
            }
        }

        class OracleDataProvider : DataProvider
        {
            public override int CloseConnection()
            {
                Console.WriteLine("Oracle Connection closed successfully");
                return 1;
            }

            public override int ExecuteCommand()
            {
                Console.WriteLine("Oracle Command Executed successfully");
                return 1;
            }

            public override int OpenConnection()
            {
                Console.WriteLine("Oracle Connection opened successfully");
                return 1;
            }
        }

        class SqlDataProvider : DataProvider
        {
            public override int CloseConnection()
            {
                Console.WriteLine("Sql Connection closed successfully");
                return 1;
            }

            public override int ExecuteCommand()
            {
                Console.WriteLine("Sql Command Executed successfully");
                return 1;
            }

            public override int OpenConnection()
            {
                Console.WriteLine("\nSql Connection opened successfully");
                return 1;
            }
        }
    }

    namespace Ex2_AquiNoHayQueUsarlo
    {
        class Tarificador
        {
            public enum TipoSexo
            {
                Masculino,
                Femenino
            }

            public decimal ObtenerPrecioEntrada(TipoSexo tipoSexo)
            {
                decimal precioEntrada = 0;
                switch (tipoSexo)
                {
                    case TipoSexo.Femenino:
                        //Codigo
                        break;
                    case TipoSexo.Masculino:
                        //Codigo
                        break;
                }
                return precioEntrada;
            }
        }

    }

    namespace Ex3_PeroAquiSi
    {
        namespace NoSOLID
        {
            public interface IForma
            {
                int Tipo { get; }
            }

            public class FormaCuadrado : IForma
            {
                public int Tipo
                {
                    get
                    {
                        return 1;
                    }
                }
            }

            public class FormaRectangulo : IForma
            {
                public int Tipo
                {
                    get
                    {
                        return 2;
                    }
                }
            }

            /// <summary>
            /// ¿Por qué no es eficiente el planteamiento de esta clase?
            /// Porque si quisiéramos añadir una nueva forma (extender la clase), 
            /// tendríamos que modificar esta misma clase, es decir, 
            /// NO ESTÁ ABIERTA A LA EXTENSIÓN
            /// </summary>
            public class Pintor
            {
                public void PintarForma(IForma forma)
                {
                    switch (forma.Tipo)
                    {
                        case 1:
                            PintarCuadrado(forma as FormaCuadrado);
                            break;
                        case 2:
                            PintarRectangulo(forma as FormaRectangulo);
                            break;
                    }
                }

                private void PintarCuadrado(FormaCuadrado cuadrado)
                {
                    //Pinta un Cuadrado...
                }

                private void PintarRectangulo(FormaRectangulo rectangulo)
                {
                    //Pinta un Rectangulo...
                }
            }
        }

        namespace SOLID
        {
            #region Definir Clase Abstracta
            public abstract class Forma
            {
                public abstract void Pintar();
            }
            #endregion

            #region Implementarla
            public class FormaCuadrado : Forma
            {
                public override void Pintar()
                {
                    // Pinta un Cuadrado
                }
            }

            public class FormaRectangulo : Forma
            {
                public override void Pintar()
                {
                    // Pinta un Rectangulo
                }
            }
            #endregion

            #region Usarla

            public class Pintor
            {
                public void PintarForma(Forma forma)
                {
                    forma.Pintar();
                }
            }
            #endregion
        }
    }
}

