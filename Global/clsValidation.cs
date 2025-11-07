using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyDVLD.Global
{
    public class clsValidation
    {


        public static bool ValidateEmail(string Email)
        {
            var pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Email);
        }

        public static bool ValidateNumber(string Num)
        {


            return ValidateInt(Num) || ValidateFloat(Num);
        }

        public static bool ValidateInt(string Num)
        {
            var pattern = @"^[0-9]*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Num);
        }

        public static bool ValidateFloat(string Num)
        {
            var pattern = @"^[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Num);
        }
    }
}
