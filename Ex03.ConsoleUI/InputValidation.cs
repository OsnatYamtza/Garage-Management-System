using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class InputValidation
    {
        public void ValidateNumber(string i_NumberToValidate)
        {
            if (!i_NumberToValidate.All(char.IsDigit))
            {
                throw new ArgumentException(string.Format("Invalid number!{0} input should contain only digits!"), Environment.NewLine);
            }
        }

        public void ValidateString(string i_StringToValidate)
        {
            if (!i_StringToValidate.All(char.IsLetter))
            {
                throw new ArgumentException(string.Format("Invalid string!{0} String should contain only letters!"), Environment.NewLine);
            }
        }

        public bool ConvertStringToBool(string i_StringToBool)
        {
            bool convertedBool = false;

            if (i_StringToBool.ToUpper() == "Y")
            {
                convertedBool = true;
            }

            return convertedBool;
        }
    }
}
