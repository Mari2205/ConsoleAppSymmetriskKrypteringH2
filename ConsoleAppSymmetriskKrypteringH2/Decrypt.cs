using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO; // input and output

namespace ConsoleAppSymmetriskKrypteringH2
{
    /// <summary>
    /// This class decrypts a message with various 
    /// symmetric encryption algorithms
    /// </summary>
    class Decrypt
    {
        public byte[] DNSDecrypt(byte[] dataToBeDecrypted, byte[] key, byte[] iv)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC; // CBC = Cipher Block Chaining
                des.Padding = PaddingMode.PKCS7; // PKCS7 = Public Key Cryptography Standards 7
                des.Key = key;
                des.IV = iv;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, des.CreateDecryptor(), CryptoStreamMode.Write);

                    cryptoStream.Write(dataToBeDecrypted, 0, dataToBeDecrypted.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }

        public byte[] TripleDESDecrypt(byte[] dataToBeDecrypted, byte[] key, byte[] iv)
        {
            using (TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC; // CBC = Cipher Block Chaining
                des.Padding = PaddingMode.PKCS7; // PKCS7 = Public Key Cryptography Standards 7
                des.Key = key;
                des.IV = iv;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, des.CreateDecryptor(), CryptoStreamMode.Write);

                    cryptoStream.Write(dataToBeDecrypted, 0, dataToBeDecrypted.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }

        public byte[] AesDecrypt(byte[] dataToBeDecrypted, byte[] key, byte[] iv)
        {
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                aes.Mode = CipherMode.CBC; // CBC = Cipher Block Chaining
                aes.Padding = PaddingMode.PKCS7; // PKCS7 = Public Key Cryptography Standards 7
                aes.Key = key;
                aes.IV = iv;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write);

                    cryptoStream.Write(dataToBeDecrypted, 0, dataToBeDecrypted.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }

    }
}
