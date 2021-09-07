using System.Collections.Generic;

namespace PSP_LW1
{
    public class MyRegex
    {
        string _allowedSpecialSymbols = System.Configuration.ConfigurationManager.AppSettings["AllowedSpecialSymbols"];

        public bool IsHaveAtSymbol(string str)
        {
            return true;
        }

        public bool IsFirstSpecialCharacter(string str, List<char> specialCharacters)
        {
            return true;
        }

        public bool IsLastSpecialCharacter(string str, List<char> specialCharacters)
        {
            return true;
        }

        public bool IsHaveUppercase(string str)
        {
            return true;
        }

        public bool IsHaveAllowedSpecialCharacter(string str)
        {
            return true;
        }

        public bool IsOnlyNumbers(string str)
        {
            return true;
        }

        public bool IsOnlyLetters(string str)
        {
            return true;
        }
    }
}
