using System;

namespace FAIS.ApplicationCore.Helpers
{
    public class TempKey
    {
        public string GenerateTempKey()
        {
            byte[] keyData = new byte[32];
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                rng.GetBytes(keyData);
            }

          
            return Convert.ToBase64String(keyData)
                .TrimEnd('=') 
                .Replace('+', 'a')
                .Replace('/', 'b');
        }
    }
}
