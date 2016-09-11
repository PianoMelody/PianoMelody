namespace PianoMelody.Web.Extensions
{
    public static class StringExtensions
    {
        public static string ToFixedLenght(this string str, int lenght)
        {
            if (str.Length > lenght + 3)
            {
                return str.Substring(0, lenght - 3) + "...";
            }

            return str;
        }
    }
}