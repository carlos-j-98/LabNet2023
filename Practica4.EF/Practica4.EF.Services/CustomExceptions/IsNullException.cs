using System;

namespace Practica4.EF.Services.CustomExceptions
{
    public class IsNullException : Exception
    {
        public IsNullException() : base("La Base de datos no contiene elementos del tipo indicado")
        {

        }
    }
}
