using System.Security.Cryptography;

namespace mbanq.API.Helpers
{
    public class AppConstants
    {
        public const string AppName = "mBANQ";
        public static HashAlgorithmName KEY_ALGORITHM = HashAlgorithmName.SHA256;
        public static int NUMBER_OF_ITERATIONS = 100000;
        public static int KEY_LENGTH = 255;
    }
}
