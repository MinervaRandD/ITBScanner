using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Asi.Itb.Utilities
{
    /// <summary>
    /// Represents container class for methods related to Cryptography
    /// </summary>
    public static class Cryptography
    {
        /// <summary>
        /// SHA1-encrypts input text using specified salt.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        /// <remarks>
        /// This is intended to match server side encryption in ruby code: 
        /// digest = password 
        /// 10.times { digest = Digest::SHA1.hexdigest([digest, salt].join('--')) }
        /// </remarks>
        public static string Sha1Encrypt(string text, string salt)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();

            string digest = text;

            for (int i = 0; i < 10; i++)
            {
                string input = salt == null ? digest : string.Format("{0}--{1}", digest, salt);
                byte[] inputBuffer = Encoding.Default.GetBytes(input);
                byte[] outputBuffer = sha.ComputeHash(inputBuffer);
                digest = BitConverter.ToString(outputBuffer).Replace("-", string.Empty).ToLower();
            }

            return digest;
        }

        /// <summary>
        /// Overloaded Sha1Encrypt() method for cases when salt is not used
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Sha1Encrypt(string text)
        {
            return Cryptography.Sha1Encrypt(text, null);
        }
    }
}
