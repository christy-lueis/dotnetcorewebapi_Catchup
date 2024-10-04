using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptDecrypt.Lib.Interfaces
{
    public interface ISecurityService
    {
        string GenerateSecureKey(int keySize);
        string GenerateTimeBasedKey();
        bool IsKeyRecent(string key, TimeSpan timeSpan);
    }
}
