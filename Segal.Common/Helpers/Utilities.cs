using System;
using System.Collections.Generic;
using System.Text;

namespace Segal.Common.Helpers
{
    public class Utilities
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VrifayPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var passwordCompute = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < passwordCompute.Length; i++)
                {
                    if (passwordCompute[i] != passwordHash[i]) return false;
                }

                return true;
            }
        }
    }
}
