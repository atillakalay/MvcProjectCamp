using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            }
        }
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        public static void CreateMailHash(string mail, out byte[] mailHash, out byte[] mailSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                mailSalt = hmac.Key;
                mailHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(mail));

            }
        }
        public static bool VerifyMailHash(string mail, byte[] mailHash, byte[] mailSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(mailSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(mail));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != mailHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}