using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace VehicleHistory.Logic.Helpers
{
    public class Crypto
    {
        public static bool VerifyPasswordHash(byte[] storedHash, byte[] storedSalt, string passwordInput)
        {
            if (string.IsNullOrWhiteSpace(passwordInput))
            {
                throw new ArgumentException("Password cannot be empty or whitespace only");
            }

            if (storedHash.Length != 64)
            {
                throw new ArgumentException("Invalid password hash length");
            }

            if (storedSalt.Length != 128)
            {
                throw new ArgumentException("Invalid password salt length");
            }

            using (var hmac = new HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwordInput));
                for (var i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be empty or whitespace only");
            }

            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static string GenerateRendomPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            const int randomPasswordLength = 16;
            var random = new Random();
            return new string(Enumerable.Repeat(chars, randomPasswordLength).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
