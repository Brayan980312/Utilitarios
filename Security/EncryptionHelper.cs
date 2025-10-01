namespace Utilitarios.Security
{
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>Métodos de cifrado y descifrado simétrico con AES.</summary>
    public static class EncryptionHelper
    {
        // Clave de 256 bits (32 bytes), almacenada en Base64
        private static readonly byte[] Key = Convert.FromBase64String("ki3tQu3ISNGMrt0RNvZjN6tD9itZR5mRvJN8N++fDzk=");

        // Vector de inicialización (IV) de 128 bits (16 bytes), almacenado en Base64
        private static readonly byte[] IV = Convert.FromBase64String("8zEM3A+cNUmJY7XARlnOXQ==");

        /// <summary>Cifra un texto plano usando AES con clave y vector de inicialización predefinidos.</summary>
        /// <param name="plainText">Texto plano a cifrar.</param>
        /// <returns>Cadena en Base64 que representa el texto cifrado.</returns>
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

        /// <summary>Descifra un texto cifrado en Base64 usando AES con clave y vector de inicialización predefinidos.</summary>
        /// <param name="cipherText">Texto cifrado en Base64.</param>
        /// <returns>Texto plano descifrado.</returns>
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
