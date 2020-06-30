using System;
using System.IO;
using System.Security.Cryptography;

namespace CryptoAes
{
    public class Decryptor
    {
        public static string DecryptAndGetString(byte[] cipherText, byte[] key, byte[] iv)
        {
            if (cipherText == null || cipherText.Length <= 0)
            {
                throw new ArgumentNullException(nameof(cipherText));
            }

            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (iv == null || iv.Length <= 0)
            {
                throw new ArgumentNullException(nameof(iv));
            }

            using var aesAlg = Aes.Create();

            // ReSharper disable once PossibleNullReferenceException
            aesAlg.Key = key;
            aesAlg.IV = iv;
            aesAlg.Padding = PaddingMode.None;

            var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            using var msDecrypt = new MemoryStream(cipherText);
            using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            using var srDecrypt = new StreamReader(csDecrypt);
            var plaintext = srDecrypt.ReadToEnd();
            return plaintext;
        }

        public static byte[] DecryptAndGetBytes(byte[] cipherText, byte[] key, byte[] iv)
        {

            if (cipherText == null || cipherText.Length <= 0)
            {
                throw new ArgumentNullException(nameof(cipherText));
            }

            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (iv == null || iv.Length <= 0)
            {
                throw new ArgumentNullException(nameof(iv));
            }

            using var aesAlg = Aes.Create();

            // ReSharper disable once PossibleNullReferenceException
            aesAlg.Key = key;
            aesAlg.IV = iv;
            aesAlg.Padding = PaddingMode.None;

            var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            using var msDecrypt = new MemoryStream(cipherText);
            using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            var result = new byte[16];
            csDecrypt.Read(result, 0, 16);
            return result;
        }
    }
}
