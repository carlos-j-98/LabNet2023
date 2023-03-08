namespace LabNetPractica2.Application.ExtensionMethods
{
    public static class DoubleExtension
    {
        public static string WriteResult(this double result)
        {
            return $"El resultado de la division es {result} \n";
        }
        public static bool DoubleIsZero(this double value)
        {
            if (value == 0)
            {
                return true;
            }
            return false;
        }
    }
}
