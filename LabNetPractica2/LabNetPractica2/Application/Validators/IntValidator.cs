namespace LabNetPractica2.Application.Validators
{
    public class IntValidator
    {
        public IntValidator()
        {

        }
        public static bool IsZero(double value)
        {
            if (value == 0)
            {
                return true;
            }
            return false;
        }
    }
}
