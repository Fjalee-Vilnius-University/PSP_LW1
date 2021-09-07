using System.Collections.Generic;

namespace PSP_LW1
{
    public class MyRegex
    {
        string _allowedSpecialSymbols = System.Configuration.ConfigurationManager.AppSettings["AllowedSpecialSymbols"];

        public bool IsOnlyNumbers(string str)
        {
            return true;
        }

        public bool IsOnlyLetters(string str)
        {
            return true;
        }

        public bool IsHaveInvalidCharacters(string str, List<char> invalidCharacters)
        {
            return true;
        }
    }
}
