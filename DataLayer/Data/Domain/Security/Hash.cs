using System.Security.Cryptography;
using System.Text;

namespace CloudCore.Domain.Security
{
    public static class Hash
    {
        public static string Calculate(string valueToHash)
        {
            var md5 = MD5.Create();
            byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(valueToHash));
            var sb = new StringBuilder();
            foreach (byte character in data)
            {
                sb.Append(character.ToString("x2"));
            }
            return sb.ToString();
        }

    }
}