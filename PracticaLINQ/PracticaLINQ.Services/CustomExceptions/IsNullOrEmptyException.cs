using System;

namespace PracticaLINQ.Services.CustomExceptions
{
    public class IsNullOrEmptyException : Exception
    {

        public IsNullOrEmptyException(string message) : base(message)
        {
        }
    }
}
