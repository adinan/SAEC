using System;
using System.Security.Cryptography;

namespace SAEC.Common
{
    public static class StringExtension
    {
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static string CriptografaSenha(this string value)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(value, salt, 10000);

            var hash = pbkdf2.GetBytes(20);
            var hashbytes = new byte[36];

            Array.Copy(salt, 0, hashbytes, 0, 16);
            Array.Copy(hash, 0, hashbytes, 16, 20);
            
            return Convert.ToBase64String(hashbytes);
        }

        /*
        public static string DesCriptografaSenha(this string value)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(value, salt, 10000);

            var hash = pbkdf2.GetBytes(20);
            var hashbytes = new byte[36];

            Array.Copy(salt, 0, hashbytes, 0, 16);
            Array.Copy(hash, 0, hashbytes, 16, 20);

            return Convert.ToBase64String(hashbytes);
        }*/
    }
}
