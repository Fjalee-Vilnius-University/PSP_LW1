using System;
using System.Linq;

namespace PSP_LW1
{
    public class PhoneValidator
    {
        readonly int _lenWithoutPrefix;
        readonly string _defaultPrefix;
        readonly string _shortcutPrefix;

        public PhoneValidator(int lenWithoutPrefix, string defaultPrefix, string shortcutPrefix)
        {
            _lenWithoutPrefix = lenWithoutPrefix;
            _defaultPrefix = defaultPrefix;
            _shortcutPrefix = shortcutPrefix;
        }

        public bool IsValid(string phone)
        {
            if (phone.Length <= _lenWithoutPrefix)
            {
                return false;
            }
            
            if (phone.Any(Char.IsLetter))
            {
                return false;
            }

            if (phone.Contains(_defaultPrefix))
            {
                return false;
            }

            if (phone[0].ToString() == _shortcutPrefix)
            {
                return false;
            }
            
            return true;
        }

        public string ChangeShortcutPrefixToDefault(string phone)
        {
            var newPhone = "";
            if (phone[0].ToString() == _shortcutPrefix)
            {
                newPhone = phone.Remove(0, 1).Insert(0, _defaultPrefix);
            }

            return newPhone;
        }
    }
}
