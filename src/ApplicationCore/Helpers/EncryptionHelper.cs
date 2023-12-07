using System;
using System.Security.Cryptography;
using System.Text;

namespace FAIS.ApplicationCore.Helpers
{
    public class EncryptionHelper
    {
        public static string HashPassword(string password)
        {
            try
            {
                byte[] computeHash = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder stringBuilder = new StringBuilder();

                for (int index = 0; index < computeHash.Length; ++index)
                {
                    stringBuilder.Append(computeHash[index].ToString("X2"));
                }

                return stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
