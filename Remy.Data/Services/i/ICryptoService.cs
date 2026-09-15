namespace Remy.Data.Services.i;

public interface ICryptoService
{
    byte[] Encrypt(string? plainText);
    string Decrypt(byte[] cipherText);
}