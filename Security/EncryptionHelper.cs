namespace Utilitarios.Security
{
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Métodos de cifrado y descifrado simétrico con AES.
    /// </summary>
    public static class EncryptionHelper
    {
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("ki3tQu3ISNGMrt0RNvZjN6tD9itZR5mRvJN8N++fDzk="); 
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("8zEM3A+cNUmJY7XARlnOXQ==");  

        public static string Encrypt(string plainText)
        {
            using var aes = Aes.Create();
            aes.Key = Key;
            aes.IV = IV;

            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            var plainBytes = Encoding.UTF8.GetBytes(plainText);

            var encrypted = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
            return Convert.ToBase64String(encrypted);
        }

        public static string Decrypt(string cipherText)
        {
            using var aes = Aes.Create();
            aes.Key = Key;
            aes.IV = IV;

            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            var cipherBytes = Convert.FromBase64String(cipherText);

            var decrypted = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
            return Encoding.UTF8.GetString(decrypted);
        }
    }
}
