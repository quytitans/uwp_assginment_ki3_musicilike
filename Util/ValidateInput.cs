using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MainStudyApp.Util
{
    class ValidateInput
    {
        public static bool IsEmail(string email)
        {
            string pattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            return Regex.IsMatch(email, pattern);
        }

        public static bool IsPhoneNumber(string number)
        {
            string patterm = @"^(84|0[3|5|7|8|9])+([0-9]{8})$";
            return Regex.Match(number, patterm).Success;
        }

        public static bool IsStringInvalid(string text, int limit)
        {
            return string.IsNullOrEmpty(text) ||
                text.Length <= limit;
        }
    }
}
