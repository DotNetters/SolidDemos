using Demo1_UnitTesting.PruebasUnitarias.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1_UnitTesting.PruebasUnitarias.BLL
{
    public class PersonaRead
    {
        /// <summary>
        /// Hay que evitar este tipo de código caótico.
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public List<PersonaInfo> LaPruebaDeEstoFuncionaPeroDeChiripaYPorqueConozcoContenido(List<PersonaInfo> original)
        {
            //Pruebas con Listas...
            int i = original.Max(item => item.ID);
            double edadmediatrabajo = original.Average(item => item.Edad);
            decimal edadmedia = Convert.ToDecimal(Math.Round(edadmediatrabajo, 2));
            int coincidenciascon_aa = original.Count(item => item.Nombre.StartsWith("aa"));
            var filtrada = original.Where(item => item.Nombre.StartsWith("a")).ToList();
            var filtrada2 = original.OrderBy(item => item.ID);
            // var filtrada3 = filtrada3;
            filtrada2.ToList().ForEach(item => item.Nombre = item.Nombre + " visitado");
            //filtrada2 = (List < Persona >) filtrada2.ForEach(item => { item.Nombre = item.Nombre + " Visto"; });
            filtrada = filtrada2.ToList();
            filtrada = original.OrderBy(item => item.ID).ToList();
            filtrada.ForEach(item => item.Nombre = item.Nombre + item.ID);
            bool result = filtrada.All(item => item.Nombre.StartsWith("b"));
            var filtrada4 = from item in original where item.Edad > 5 select item;
            filtrada = filtrada4.ToList();
            var filtrada6 = from persona in original select persona.Nombre;
            var filtrada7 = from persona in original select persona.Nombre.ToString();
            var filtrada5 = from persona in original let name = persona.Nombre from w in name select w.ToString().ToUpper();
            var filtrada8 = from persona in original group persona by persona.Nombre;
            foreach (var gupopersona in filtrada8)
            {
                foreach (PersonaInfo persona in gupopersona)
                {
                    //recorremos tods las personas con el mismo nombre
                }
            }

            return filtrada;
        }

        public List<PersonaInfo> EsteCodigoHaSidoLimpiado(List<PersonaInfo> original)
        {
            var filtrada = original.OrderBy(item => item.ID).ToList();
            filtrada.ForEach(item => item.Nombre = item.Nombre + " visitado" + +item.ID);

            return filtrada;
        }


        public List<PersonaInfo> ObtenerTresPrimeras(List<PersonaInfo> original)
        {
            return original.Take(3).ToList();
        }

        public List<PersonaInfo> OrdenarPorNombre(List<PersonaInfo> original)
        {
            return original.OrderByDescending(item => item.Nombre).ToList();
        }

        public List<PersonaInfo> OrdenarPorNombreYObtener3Primeras(List<PersonaInfo> original)
        {
            return ObtenerTresPrimeras(OrdenarPorNombre(original));
        }

        public int PersonasPruebaExcepciones(List<PersonaInfo> original)
        {
            throw new ArgumentNullException();
        }

    }
}
