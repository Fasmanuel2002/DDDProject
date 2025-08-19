using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    //ásicamente, crea una referencia a la asamblea (Assembly) del proyecto Application
    //Esto es lo que nos permite que podamos injectar las dependencias como Services AddMediaR

    // Esta clase sirve para exponer una referencia al Assembly de Application.
    // Se usa, por ejemplo, al registrar dependencias (como MediatR, AutoMapper, FluentValidation, etc.),
    // para que puedan escanear automáticamente este proyecto en busca de handlers, perfiles y validadores.
    public class ApplicationAssemblyReference
    {
        internal static readonly Assembly assembly = typeof(ApplicationAssemblyReference).Assembly;
    }
}
