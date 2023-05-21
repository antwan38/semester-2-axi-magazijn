using System.Security.Cryptography;
using System.Text;
using Isopoh.Cryptography.Argon2;
using Isopoh.Cryptography.SecureArray;

namespace LogicLayer;

public class Hashing
{
    private static readonly RandomNumberGenerator Rng = RandomNumberGenerator.Create();

    
    /// <summary>
    /// Uses Password and Mail to create a password hash to save in the database
    /// mail is used as the secret
    /// </summary>
    /// <param name="password"></param>
    /// <param name="mail"></param>
    /// <returns>
    /// return the hash op the password
    /// </returns>
    public string HashPassword(string password, string mail)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] salt = new byte[16];
        Rng.GetBytes(salt);
        byte[] secretBytes = Encoding.UTF8.GetBytes(mail);

        foreach (var argon2Type in new[]
                 {
                     Argon2Type.DataIndependentAddressing, Argon2Type.DataDependentAddressing,
                     Argon2Type.HybridAddressing
                 })
        {
            var argon2Name = argon2Type == Argon2Type.DataIndependentAddressing ? "Argon2i" :
                argon2Type == Argon2Type.DataDependentAddressing ? "Argon2d" : "Argon2id";
            var config = new Argon2Config
            {
                Type = argon2Type,
                Version = Argon2Version.Nineteen,
                Password = passwordBytes,
                Salt = salt,
                Secret = secretBytes,
                TimeCost = 3,
                MemoryCost = 65536,
                Lanes = 4,
                Threads = 2,
            };
            var argon2 = new Argon2(config);
            SecureArray<byte> hash = argon2.Hash();
            var passwordHash = config.EncodeString(hash.Buffer);
            return passwordHash;
        }

        return null;
    }

    /// <summary>
    /// validates the hash with the corresponding password and Mail
    /// </summary>
    /// <param name="passwordHash"></param>
    /// <param name="password"></param>
    /// <param name="secret"></param>
    /// <returns>
    /// return true when the passwordhash verifaction is succesfull
    /// return false when the passwordhash verifaction is invalid
    /// </returns>
    public bool VerifyPassword(string passwordHash, string password, string secret)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] secretBytes = Encoding.UTF8.GetBytes(secret);

        if (Argon2.Verify(passwordHash, passwordBytes, secretBytes, SecureArray.DefaultCall))
        {
            return true;
        }

        return false;
    }
}