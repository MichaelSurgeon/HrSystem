using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZonalProject
{
    public class PasswordLogin
    {
        public static string encryptPassword(string password)
        {       
            //creates an array of characters called passwordBytes then teh system encodes the password string 
            //which is set in the register form then sets the encoded value to the password string in this class
            byte[] passwordBytes = System.Text.Encoding.Unicode.GetBytes(password);
            //there is then a string created then it converts the value of the array(passwordBytes) to the equivalent string that is incoded being password bytes
            string encryptedPassword = Convert.ToBase64String(passwordBytes);
            //then it returns the value of the new encrypted password
            return encryptedPassword;
        }
    }
}
