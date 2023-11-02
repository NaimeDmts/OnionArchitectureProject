using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KatmanliSinavProject.BLL.Utilities
{
    public class UserIslem
    {
        public static bool IsValidEmailFormat(string email)
        {
            string emailPattern = @"^[a-zA-Z]+\.[a-zA-Z]+@gmail\.com$";
            return Regex.IsMatch(email, emailPattern);
        }
        public static string AdFromEmail(string email)
        {
       
            int atSignIndex = email.IndexOf('.');
            return email.Substring(0, atSignIndex);
        }

        
        public static string SoyadFromEmail(string email)
        {

            int atSignIndex = email.IndexOf('.');
            int endIndex = email.IndexOf('@');

            string soyad = email.Substring(atSignIndex + 1, endIndex - atSignIndex - 1);

            return soyad;
        }
    }
}
