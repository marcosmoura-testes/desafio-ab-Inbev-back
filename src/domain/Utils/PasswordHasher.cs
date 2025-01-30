using System.Security.Cryptography;

namespace domain.Utils;

public class PasswordHasher
{
    private const int SaltSize = 32;
    private const int KeySize = 64; 
    private const int Iterations = 10000;

    public string HashPassword(string password)
    {
        using (var algorithm = new Rfc2898DeriveBytes(
                   password, SaltSize, Iterations, HashAlgorithmName.SHA256))
        {
            var salt = algorithm.Salt;
            var hash = algorithm.GetBytes(KeySize);

            var hashBytes = new byte[SaltSize + KeySize];
            Buffer.BlockCopy(salt, 0, hashBytes, 0, SaltSize);
            Buffer.BlockCopy(hash, 0, hashBytes, SaltSize, KeySize);

            return Convert.ToBase64String(hashBytes);
        }
    }

    public bool VerifyPassword(string password, string storedHash)
    {
        var hashBytes = Convert.FromBase64String(storedHash);
        var salt = new byte[SaltSize];
        Buffer.BlockCopy(hashBytes, 0, salt, 0, SaltSize);

        using (var algorithm = new Rfc2898DeriveBytes(
                   password, salt, Iterations, HashAlgorithmName.SHA256))
        {
            var hash = algorithm.GetBytes(KeySize);
            for (int i = 0; i < KeySize; i++)
            {
                if (hashBytes[SaltSize + i] != hash[i]) return false;
            }
        }

        return true;
    }
}