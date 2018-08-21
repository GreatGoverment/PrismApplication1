using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PrismApplication.Common
{
    public class SafePassword
    {
        private static int STRECH_COUNT = 1000;

        // salt + password
        public static string GetSaltedPassword(string userId, string password)
        {
            string salt = GetSha256(userId);
            return GetSha256(salt + password);
        }

        // Stretch Hash
        public static string GetStretchedPassword(string userId, string password)
        {
            string salt = GetSha256(userId);
            string hash = "";

            for (int i = 0; i < STRECH_COUNT; i++)
            {
                hash = GetSha256(hash + salt + password);
            }

            return hash;
        }

        private static string GetSha256(string target)
        {
            SHA256 mySHA256 = SHA256Managed.Create();
            byte[] byteValue = Encoding.UTF8.GetBytes(target);
            byte[] hash = mySHA256.ComputeHash(byteValue);

            StringBuilder buf = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                buf.AppendFormat("{0:x2}", hash[i]);
            }

            return buf.ToString();
        }
    }
}
