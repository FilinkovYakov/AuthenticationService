using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace InternshipAuthenticationService.AuthenticationService
{
    public static class CryptoFunctions
    {
        public static string GenerationSalt(int length)
        {
            RNGCryptoServiceProvider p = new RNGCryptoServiceProvider();
            var salt = new byte[length];
            p.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }

        public static string GetMd5Hash(string password, string salt)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
            return Convert.ToBase64String(data);
        }
    }
}