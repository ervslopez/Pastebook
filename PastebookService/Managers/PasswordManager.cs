using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace PastebookService
{
    public class PasswordManager
    {
        private static RNGCryptoServiceProvider m_cryptoServiceProvider = new RNGCryptoServiceProvider();
        private const int SALT_SIZE = 24;

        public string GeneratePasswordHash(string Password, out string salt)
        {
            SHA256 sha = new SHA256CryptoServiceProvider();
            salt = GetSaltString();
            byte[] resultBytes = sha.ComputeHash(Mapper.GetBytes(Password + salt));

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
            retVal = hash == null;// m_hashComputer.GetPasswordHashAndSalt(finalString);
            return retVal;
        }
        
    }
}