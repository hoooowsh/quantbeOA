using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace quantbeApplication.Controllers
{
    public static class Encrypter
    {
        private const string ENCRYPTION_KET = "A60934D8C1A2AC3A69642A3902198";
        private readonly static byte[] SALT = new byte[] { 99, 52, 2, 24, 51, 67, 22, 88 };

        // helper function te get encrypted url
        public static string EncryptUrl(string originalUrl, int maxLength)
        {
            byte[] plainText = Encoding.Unicode.GetBytes(originalUrl);
            var secrectKey = new Rfc2898DeriveBytes(ENCRYPTION_KET, SALT);

            using (RijndaelManaged rijndaelCipher = new RijndaelManaged())
            {
                using (ICryptoTransform encryptor = rijndaelCipher.CreateEncryptor(secrectKey.GetBytes(32), secrectKey.GetBytes(16)))
                using (var memoryStream = new MemoryStream())
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainText, 0, plainText.Length);
                    cryptoStream.FlushFinalBlock();
                    string encryptedUrl = Convert.ToBase64String(memoryStream.ToArray());
                    encryptedUrl = HttpUtility.UrlEncode(encryptedUrl);

                    if (encryptedUrl.Length > maxLength)
                    {
                        encryptedUrl = encryptedUrl.Substring(0, maxLength);
                    }
                    return encryptedUrl;
                }
            }
        }
    }
}
