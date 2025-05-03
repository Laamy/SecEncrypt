namespace encryptsex.Config;

using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System;

class AESStream
{
    private static string EncryptionKey = "Why would you want to cheat?... :o It's no fun. :') :'D";

    private static byte[] StripSalt(byte[] data)
    {
        if (data.Length <= 16) return Array.Empty<byte>();
        return data.Skip(16).ToArray();
    }

    public static string Decrypt(byte[] encryptedData)
    {
        byte[] salts = encryptedData.Take(16).ToArray();

        using (var pbkdf2 = new Rfc2898DeriveBytes(EncryptionKey, salts, 100, HashAlgorithmName.SHA1))
        {
            byte[] key = pbkdf2.GetBytes(16);

            using (var aes = new AesManaged())
            {
                aes.Mode = CipherMode.CBC;
                aes.KeySize = 128;
                aes.BlockSize = 128;
                aes.Key = key;
                aes.IV = salts;

                using (var decryptor = aes.CreateDecryptor())
                using (var msDecrypt = new MemoryStream(encryptedData))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var reader = new BinaryReader(csDecrypt))
                {
                    byte[] decryptedData = reader.ReadBytes(encryptedData.Length);
                    decryptedData = StripSalt(decryptedData);
                    return Encoding.UTF8.GetString(decryptedData);
                }
            }
        }
    }

    public static byte[] Encrypt(string content)
    {
        byte[] data = Encoding.UTF8.GetBytes(content);
        using (var aes = new AesManaged())
        {
            aes.Mode = CipherMode.CBC;
            aes.KeySize = 128;
            aes.BlockSize = 128;
            aes.GenerateIV();
            using (var pbkdf2 = new Rfc2898DeriveBytes(EncryptionKey, aes.IV, 100, HashAlgorithmName.SHA1))
            {
                aes.Key = pbkdf2.GetBytes(16);
                using (var encryptor = aes.CreateEncryptor())
                using (var msEncrypt = new MemoryStream())
                {
                    msEncrypt.Write(aes.IV, 0, aes.IV.Length);
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var writer = new BinaryWriter(csEncrypt))
                    {
                        writer.Write(data);
                    }
                    return msEncrypt.ToArray();
                }
            }
        }
    }
}
