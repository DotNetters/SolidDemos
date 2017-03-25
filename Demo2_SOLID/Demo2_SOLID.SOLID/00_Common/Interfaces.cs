using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2_SOLID.SOLID._00_Common
{

    public interface ICuandoYParaQue
    {
        IEnumerable<string> ParaQueNosAyuda { get; }
        IEnumerable<string> CuandoAplicar { get; }
    }

    /// <summary>
    /// Ojo, nadie nos impide hacer algo como esto si vas a reutilizarlo
    /// </summary>
    public interface IInfo :
        // Principio de responsabilidad única
        IQueEsYQueNoEs,
        // Principio de responsabilidad única
        ICuandoYParaQue
    {

    }

    public interface IQueEsYQueNoEs
    {
        IEnumerable<string> QueEs { get; }
        IEnumerable<string> QueNoEs { get; }
    }

    public interface ISugerencias
    {
        IEnumerable<string> Sugerencias { get; }
    }
}
