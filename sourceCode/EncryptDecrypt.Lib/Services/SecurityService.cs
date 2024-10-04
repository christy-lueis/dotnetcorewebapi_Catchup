using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptDecrypt.Lib.Services
{
    public class SecurityService
    {
        private Dictionary<string, DateTime> keyStore = new Dictionary<string, DateTime>();
        public string GenerateSecureKey(int keySize)
        {
            byte[] key = new byte[keySize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }
            return Convert.ToBase64String(key);
        }

        public string GenerateTimeBasedKey()
        {
            // Get the current time as a string
            string timeString = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");

            // Convert the time string to bytes
            byte[] timeBytes = Encoding.UTF8.GetBytes(timeString);

            // Use SHA256 to hash the time bytes
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(timeBytes);

                // Convert the hash bytes to a Base64 string
                return Convert.ToBase64String(hashBytes);
            }
        }

        public bool IsKeyRecent(string key, TimeSpan timeSpan)
        {
            
            if (keyStore.TryGetValue(key, out DateTime creationTime))
            {
                if (keyStore.Count > 10)
                {
                    keyStore.Clear();
                }
                return (DateTime.UtcNow - creationTime) <= timeSpan;
            }
            return false;
        }
    }
}
