using System.Security.Cryptography;
using Remy.Data.Services.i;

namespace Remy.Data.Services;

internal class CryptoService : ICryptoService
{
    public byte[] Encrypt(string? plainText)
    {
        if (string.IsNullOrEmpty(plainText))
            return [];
        
        byte[] key = new byte[32];
        int tagsize = 4;
        
        
        var aes = new AesGcm(key, tagsize);

        
        //TODO: todo
        return [];
    }

    public string Decrypt(byte[] cipherText)
    {
        if (cipherText.Length == 0)
            return string.Empty;
        
        //TODO:
        return string.Empty;
    }
}