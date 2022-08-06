namespace NSE.Core.Utils
{
    public static class StringUtils
    {
        public static string ApenasNumeros(this string str, string input) 
            => new string(input.Where(char.IsDigit).ToArray());
    }
}