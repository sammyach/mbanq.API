using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace mbanq.API.Helpers
{
    public class Utilities
    {
        /**
         *  returns byte array with length of 32
         *  when Convert.ToBase64String, length = 44
         */
        public static byte[] GenerateRandomNaCl()
        {
            return RandomNumberGenerator.GetBytes(32);
        }

        public static string GenerateRandomString(int length)
        {
            var bits = (length * 6);
            var byte_size = ((bits + 7) / 8);
            var bytesarray = RandomNumberGenerator.GetBytes(byte_size);
            return Convert.ToBase64String(bytesarray);
        }

        public static string GenerateGuid()
        {
            return Guid.NewGuid().ToString();
        }

        public static string GenerateHashString()
        {
            return GenerateGuid();
            //return GenerateRandomString(32);            
        }

        public static byte[] GeneratePasswordHash(string password, byte[] nacl)
        {
            return Rfc2898DeriveBytes.Pbkdf2(password, nacl, AppConstants.NUMBER_OF_ITERATIONS, AppConstants.KEY_ALGORITHM, AppConstants.KEY_LENGTH);
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email)) return false;

                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);
                return match.Success;
                //var addr = new System.Net.Mail.MailAddress(email);
                //return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

    }   
}
