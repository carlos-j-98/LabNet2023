using System;

namespace PracticaLINQ.Services.ExtensionMethods
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
