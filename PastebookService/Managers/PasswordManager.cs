using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace PastebookService
{
    public class PasswordManager
    {
        private static RNGCryptoServiceProvider m_cryptoServiceProvider;
        private const int SALT_SIZE = 24;

        static PasswordManager()
        {
            m_cryptoServiceProvider = new RNGCryptoServiceProvider();
        }

        public string GeneratePasswordHash(string Password, out string salt)
        {
            SHA256 sha = new SHA256CryptoServiceProvider();
            salt = GetSaltString();
            byte[] resultBytes = sha.ComputeHash(Mapper.GetBytes(Password + salt));

            // return the hash string to the caller
            return Mapper.GetString(resultBytes);
        }


        public string GetPasswordHash(string message)
        {
            // Let us use SHA256 algorithm to 
            // generate the hash from this salted password
            SHA256 sha = new SHA256CryptoServiceProvider();
            byte[] dataBytes = Mapper.GetBytes(message);
            byte[] resultBytes = sha.ComputeHash(dataBytes);

            // return the hash string to the caller
            return Mapper.GetString(resultBytes);
        }

        public string GetSaltString()
        {
            byte[] saltBytes = new byte[SALT_SIZE];
            // generate the salt in the byte array
            m_cryptoServiceProvider.GetNonZeroBytes(saltBytes);
            return Mapper.GetString(saltBytes);
        }

        public bool PasswordMatch(string password, string salt, string hash)
        {
            var retVal = false;
            string finalString = password + salt;
            retVal = hash == GetPasswordHash(finalString);
            return retVal;
        }

    }
}