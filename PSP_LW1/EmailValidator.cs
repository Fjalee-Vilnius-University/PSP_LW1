using System;
using System.Collections.Generic;
using System.Linq;

namespace PSP_LW1
{
    public class EmailValidator
    {
        List<char> _invalidCharacters;
        List<char> _specialCharacters;

        public EmailValidator(List<char> invalidCharacters, List<char> specialCharacters)
        {
            _invalidCharacters = invalidCharacters;
            _specialCharacters = specialCharacters;
        }
        public bool IsFirstSpecialCharacter(string str)
        {
            return _specialCharacters.Contains(str[0]);
        }

        public bool IsLastSpecialCharacter(string str)
        {
            return _specialCharacters.Contains(str[^1]);
        }

        public bool IsHaveTwoOrMoreConsecutiveSpecialChars(string str)
        {
            for (var i = 0; i < str.Length - 1; i++)
            {
                if (_specialCharacters.Contains(str[i]) && _specialCharacters.Contains(str[i + 1]))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsValid(string email)
        {
            if (AnyInvalidCharacters(email))
            {
                return false;
            }

            if (!email.Contains('@'))
            {
                return false;
            }

            if (!IsValidDomain(email))
            {
                return false;
            }
            


            return true;
        }

        private bool IsValidDomain(string email)
        {
            var domain = email.Split('@')[1];
            var domainName = "";
            var domainEnding = "";
            
            if (domain.Contains('.'))
            {
                domainName = domain.Split('.')[0];
                domainEnding = domain.Split('.')[1];
            }
            
            return domain.Contains('.') && domainName.All(Char.IsLetterOrDigit) && domainEnding.All(Char.IsLetter);
        }

        private bool AnyInvalidCharacters(string email)
        {
            foreach (var invalid in _invalidCharacters)
            {
                if (email.Contains(invalid))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
