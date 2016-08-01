using System.Security.Cryptography;
using System.Text;

namespace Devian
{
    static class Extensions
    {
        public static string ToMd5(this string self)
        {
            using (var algorithm = MD5.Create())
            {
                var byteArray = algorithm.ComputeHash(Encoding.UTF8.GetBytes(self));
                var resultBuilder = new StringBuilder();
                foreach (byte bin in byteArray)
                {
                    resultBuilder.Append(bin.ToString("x2"));
                }
                return resultBuilder.ToString();
            }
        }
    }
}
