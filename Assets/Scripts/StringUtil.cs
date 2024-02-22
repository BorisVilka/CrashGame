using System.Security.Cryptography;
using System.Text;

namespace Utils {
    public class StringUtil {
        public static string MD5Hash(string text) {
            MD5 mD5 = new MD5CryptoServiceProvider();
            mD5.ComputeHash(Encoding.ASCII.GetBytes(text));
            var result = mD5.Hash;
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var b in result) {
                stringBuilder.Append(b.ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}