using System;

namespace LabNetPractica2.Application.ExtensionMethods
{
    public static class ExceptionExtension
    {
        public static string MessageExtension(this Exception ex)
        {
            return $"Mensaje: {ex.Message} \n";
        }
        public static string TipeExtension(this Exception ex)
        {
            return $"Tipo: {ex.GetType()} \n";
        }
    }
}
