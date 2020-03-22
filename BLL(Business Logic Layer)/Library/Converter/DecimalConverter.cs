using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Business_Logic_Layer_.Library
{
    public class DecimalConverter
    {
        public static decimal StringToDecimal(string decimalString)
        {
            decimal result = 0;
            try
            {
                result = decimal.Parse(decimalString, CultureInfo.InvariantCulture.NumberFormat);
            }
            catch { }

            return result;
        }

        public static string DecimalToString(decimal number)
        {
            string result = "";
            try
            {
                result = number.ToString(CultureInfo.InvariantCulture.NumberFormat);
            }
            catch { }

            return result;
        }
    }
}
