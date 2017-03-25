using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1_UnitTesting.PruebasUnitarias.Model
{
    public class PersonaInfo
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }

        public string PropiedadQuePuedeSerIgnorada { get; set; }


        public override string ToString()
        {
            return $" ID: {ID} Nombre: {Nombre} Edad: {Edad}";
        }
    }
}
