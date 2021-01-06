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
    /// This class Encrypts a message with various 
    /// symmetric encryption algorithms
    /// </summary>
    class Kryptering
    {
        public byte[] DESEncrypt(byte[] dataToBeEncrypted, byte[] key, byte[] iv)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC; // CBC = Cipher Block Chaining
                des.Padding = PaddingMode.PKCS7; // PKCS7 = Public Key Cryptography Standards 7
                des.Key = key;
                des.IV = iv;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, des.CreateEncryptor(), CryptoStreamMode.Write);

                    cryptoStream.Write(dataToBeEncrypted, 0, dataToBeEncrypted.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }

        public byte[] TripleDESEncrypt(byte[] dataToBeEncrypted, byte[] key, byte[] iv)
        {
            using (TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC; // CBC = Cipher Block Chaining
                des.Padding = PaddingMode.PKCS7; // PKCS7 = Public Key Cryptography Standards 7
                des.Key = key;
                des.IV = iv;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, des.CreateEncryptor(), CryptoStreamMode.Write);

                    cryptoStream.Write(dataToBeEncrypted, 0, dataToBeEncrypted.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }

            }

        }

        public byte[] AesEncrypt(byte[] dataToBeEncrypted, byte[] key, byte[] iv)
        {
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                aes.Mode = CipherMode.CBC; // CBC = Cipher Block Chaining
                aes.Padding = PaddingMode.PKCS7; // PKCS7 = Public Key Cryptography Standards 7
                aes.Key = key;
                aes.IV = iv;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);

                    cryptoStream.Write(dataToBeEncrypted, 0, dataToBeEncrypted.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }

    }
}
