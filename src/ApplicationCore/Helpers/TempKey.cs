using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace FAIS.ApplicationCore.Helpers
{
    public  class TempKey
    {
        public string GenerateTempKey()
        {
            byte[] keyData = new byte[32];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(keyData);
            }
            return Convert.ToBase64String(keyData);
        }
    }
}
