using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace p2.Models.Function
{
    public class CryptorEngine
    {
        public static string Encrypt(string password)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            byte[] bytes = hashmd5.ComputeHash(new UTF8Encoding().GetBytes(password));
            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}