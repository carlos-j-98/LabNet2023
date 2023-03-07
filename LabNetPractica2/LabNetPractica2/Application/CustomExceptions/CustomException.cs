using System;

namespace LabNetPractica2.Application.CustomExceptions
{
    public class CustomException : Exception
    {
        public CustomException() : base("Esta es una excepcion personalizada \n")
        {

        }
    }
}
