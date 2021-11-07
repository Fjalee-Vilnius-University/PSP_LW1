using System;
using System.Collections.Generic;

namespace PSP_LW1
{
    public class PasswordChecker
    {
        private readonly int _minLength;
        private readonly List<char> _allowedSpecialCharacters = new List<char>();

        public PasswordChecker(int minLength, List<char> allowedSpecialCharacters)
        {
            _minLength = minLength;
            _allowedSpecialCharacters = allowedSpecialCharacters;
        }
        public bool IsValid(string str)
        {
            if (str.Length < _minLength)
            {
                return false;
            }

            bool hasUpper = false;
            
            foreach (var c in str)
            {
                if (Char.IsUpper(c))
                {
                    hasUpper = true;
                    break;
                }
            }

            if (!hasUpper)
            {
                return false;
            }

            if (!AnySpecialCharacters(str))
            {
                return false;
            }
            
            
            return true;
        }

        private bool AnySpecialCharacters(string password)
        {
            foreach (var invalid in _allowedSpecialCharacters)
            {
                if (password.Contains(invalid))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
