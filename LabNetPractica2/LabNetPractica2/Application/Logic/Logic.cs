using LabNetPractica2.Application.CustomExceptions;
using System;

namespace LabNetPractica2.Application.Logic
{
    public class Logic
    {
        Logic()
        {

        }
        public static void LaunchException()
        {
            throw new IndexOutOfRangeException("Ocurrio una excepcion de IndexOutOfRangeException");
        }
        public static void LaunchCustomException()
        {
            throw new CustomException();
        }
    }
}
