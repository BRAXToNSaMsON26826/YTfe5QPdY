// 代码生成时间: 2025-09-24 07:14:01
using System;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Password Encryption Decryption Tool
/// </summary>
public class PasswordEncryptionDecryptionTool
{
    /// <summary>
    /// Encrypts the password using AES algorithm.
    /// </summary>
    /// <param name="password">The password to encrypt.</param>
    /// <returns>The encrypted password.</returns>
    public static string EncryptPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
            throw new ArgumentException("Password cannot be null or empty.", nameof(password));

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.GenerateKey();
            aesAlg.GenerateIV();

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(password);
                    }
                }
                byte[] iv = aesAlg.IV;
                byte[] encryptedPasswordBytes = msEncrypt.ToArray();
                byte[] result = new byte[iv.Length + encryptedPasswordBytes.Length];

                Array.Copy(iv, result, iv.Length);
                Array.Copy(encryptedPasswordBytes, 0, result, iv.Length, encryptedPasswordBytes.Length);

                return Convert.ToBase64String(result);
            }
        }
    }

    /// <summary>
    /// Decrypts the password using AES algorithm.
    /// </summary>
    /// <param name="encryptedPassword">The encrypted password to decrypt.</param>
    /// <returns>The decrypted password.</returns>
    public static string DecryptPassword(string encryptedPassword)
    {
        if (string.IsNullOrEmpty(encryptedPassword))
            throw new ArgumentException("Encrypted password cannot be null or empty.", nameof(encryptedPassword));

        byte[] bytes = Convert.FromBase64String(encryptedPassword);
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = bytes.Skip(16).ToArray(); // Skip the first 16 bytes of the IV
            aesAlg.IV = bytes.Take(16).ToArray();
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            using (MemoryStream msDecrypt = new MemoryStream())
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swDecrypt = new StreamWriter(csDecrypt))
                    {
                        swDecrypt.Write(encryptedPassword);
                    }
                }
                return Encoding.UTF8.GetString(msDecrypt.ToArray());
            }
        }
    }
}
