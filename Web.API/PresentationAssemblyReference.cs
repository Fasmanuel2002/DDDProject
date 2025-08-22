
using System.Reflection;

namespace Application
{
    //Esto lo que nos permite es que injectemos como dependencai como Services AddMediaR
    public class PresentationAssemblyReference
    {
        //Crea el assembly de la aplicacion, es decir, el assembly de la capa de presentacion
        internal static readonly Assembly Assembly = typeof(PresentationAssemblyReference).Assembly;
    }
}