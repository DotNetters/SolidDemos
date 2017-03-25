using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2_SOLID.SOLID._04_Interface_Segregation_Principle
{
    namespace Ex1_Segregado
    {
        /// <summary>
        /// Métodos genéricos para todas las clases derivadas
        /// </summary>
        public interface IDataProvider
        {
            int CloseConnection();

            int OpenConnection();
        }

        /// <summary>
        /// Método específico para Oracle
        /// </summary>
        public interface IOracleDataProvider : IDataProvider
        {
            int ExecuteOracleCommand();
        }

        /// <summary>
        /// Método específico para Sql Server
        /// </summary>
        public interface ISqlDataProvider : IDataProvider
        {
            int ExecuteSqlCommand();
        }

        /// <summary>
        /// Cliente Oracle
        /// No hay que forzar a que Oracle implemente un método exclusivo de Sql
        /// </summary>
        public class OracleDataClient : IOracleDataProvider
        {
            public int CloseConnection()
            {
                Console.WriteLine("Conexión cerrada satisfactoriamente");
                return 1;
            }

            /// <summary>
            /// Implementación específica
            /// </summary>
            /// <returns></returns>
            public int ExecuteOracleCommand()
            {
                Console.WriteLine("Oracle specific Command Executed successfully");
                return 1;
            }

            public int OpenConnection()
            {
                Console.WriteLine("Conexión abierta satisfactoriamente");
                return 1;
            }
        }

        /// <summary>
        /// Cliente SQL
        /// No hay que forzar a que sql implemente un método exclusivo de Oracle
        /// </summary>
        public class SqlDataClient : ISqlDataProvider
        {
            public int CloseConnection()
            {
                Console.WriteLine("Conexión cerrada satisfactoriamente");
                return 1;
            }

            /// <summary>
            /// Implementación específica
            /// </summary>
            /// <returns></returns>
            public int ExecuteSqlCommand()
            {
                Console.WriteLine("Comando sql ejecutado satisfactoriamente");
                return 1;
            }

            public int OpenConnection()
            {
                Console.WriteLine("Conexión abierta satisfactoriamente");
                return 1;
            }
        }
    }

    namespace Ex2_ClaseBase
    {
        /// <summary>
        /// Métodos genéricos para todas las clases derivadas
        /// </summary>
        public interface IDataProvider
        {
            int CloseConnection();

            int OpenConnection();
        }

        /// <summary>
        /// Método específico para Oracle
        /// </summary>
        public interface IOracleDataProvider : IDataProvider
        {
            int ExecuteOracleCommand();
        }

        /// <summary>
        /// Método específico para Sql Server
        /// </summary>
        public interface ISqlDataProvider : IDataProvider
        {
            int ExecuteSqlCommand();
        }

        public class DataBaseClient : IDataProvider
        {
            public int CloseConnection()
            {
                Console.WriteLine("Conexión cerrada satisfactoriamente");
                return 1;
            }

            public int OpenConnection()
            {
                Console.WriteLine("Conexión abierta satisfactoriamente");
                return 1;
            }
        }

        /// <summary>
        /// Cliente Oracle
        /// No hay que forzar a que Oracle implemente un método exclusivo de Sql
        /// </summary>
        public class OracleDataClient : DataBaseClient, IOracleDataProvider
        {
            /// <summary>
            /// Implementación específica
            /// </summary>
            /// <returns></returns>
            public int ExecuteOracleCommand()
            {
                Console.WriteLine("Oracle specific Command Executed successfully");
                return 1;
            }
        }

        /// <summary>
        /// Cliente SQL
        /// No hay que forzar a que sql implemente un método exclusivo de Oracle
        /// </summary>
        public class SqlDataClient : DataBaseClient, ISqlDataProvider
        {
            /// <summary>
            /// Implementación específica
            /// </summary>
            /// <returns></returns>
            public int ExecuteSqlCommand()
            {
                Console.WriteLine("Comando sql ejecutado satisfactoriamente");
                return 1;
            }
        }
    }

    /// <summary>
    /// Cuando se definen interfaces estos deben ser específicos a una finalidad concreta
    /// </summary>
    namespace Ex3_Utils
    {
        public interface IUtils
        {
            bool Compara(object ob1, object obj2);
            object Clonar(object ojb1);
        }

        public class Utils : IUtils
        {
            public object Clonar(object ojb1)
            {
                return "objeto clonado";
            }

            public bool Compara(object ob1, object obj2)
            {
                return ob1.Equals(obj2);
            }
        }

        public class ClaseQueNecesitaClonar : IUtils
        {
            public object Clonar(object ojb1)
            {
                return "objeto clonado";
            }

            public bool Compara(object ob1, object obj2)
            {
                throw new NotImplementedException();
            }
        }

    }
}

