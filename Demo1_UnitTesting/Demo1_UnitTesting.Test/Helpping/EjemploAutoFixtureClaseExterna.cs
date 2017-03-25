using System;
using System.Collections.Generic;
using Demo1_UnitTesting.PruebasUnitarias.Model;
using Demo1_UnitTesting.PruebasUnitarias.BLL;

namespace Demo1_UnitTesting.Test
{
    public class Ejemplo_AutoFixture_Class
    {
        public String Saludo(String saludo)
        {
            return "Hola";
        }

        public int Numero(int numeroAF)
        {
            return numeroAF;
        }

        public PersonaInfo DatosPersona(PersonaInfo personaAF)
        {
            return personaAF;
        }

        public PersonaInfo DatosPersona()
        {
            PersonaInfo personaAF = new PersonaInfo();
            personaAF.Nombre = "NombrePersona";

            return personaAF;
        }

        public List<PersonaInfo> CrearLista()
        {
            List<PersonaInfo> lista = new List<PersonaInfo>();
            return lista;
        }
    }
}
