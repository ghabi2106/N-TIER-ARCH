using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Business_Logic_Layer_.Library
{
    public class StringConverter
    {
        public static string EmptyStringIfNull(string text)
        {
            try
            {
                if (text != null)
                {
                    return text;
                }
                return "";
            }
            catch
            {
                return "";
            }
        }
    }
}
