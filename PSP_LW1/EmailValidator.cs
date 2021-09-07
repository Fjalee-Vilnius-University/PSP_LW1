using System.Collections.Generic;

namespace PSP_LW1
{
    public class EmailValidator
    {
        List<char> _invalidCharacters;

        public EmailValidator(List<char> invalidCharacters)
        {
            _invalidCharacters = invalidCharacters;
        }
    }
}
