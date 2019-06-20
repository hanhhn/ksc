using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Cf.Libs.Core.Cryption
{
    public class Crypto
    {
        public const string SALT = "CQQUX56L10";

        public static string EncryptMD5(string text)
        {
            var md5 = new MD5CryptoServiceProvider();
            var byteValues = Encoding.Unicode.GetBytes(text);
            var byteHash = md5.ComputeHash(byteValues);
            return Convert.ToBase64String(byteHash);
        }

        public static String Sha256(String value)
        {
            var Sb = new StringBuilder();

            using (var hash = SHA256Managed.Create())
            {
                var enc = Encoding.UTF8;
                var result = hash.ComputeHash(enc.GetBytes(value));

                foreach (var b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        public static String Sha256ByLinq(String value)
        {
            using (var hash = SHA256Managed.Create())
            {
                return String.Concat(hash
                  .ComputeHash(Encoding.UTF8.GetBytes(value))
                  .Select(item => item.ToString("x2")));
            }
        }

        public static string EncryptMd5Sha256WithSalt(string data)
        {
            return Sha256(EncryptMD5(data.Trim()) + SALT);
        }
    }
}
