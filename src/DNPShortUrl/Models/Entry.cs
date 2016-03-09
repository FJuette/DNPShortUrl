using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DNPShortUrl.Models
{
    public class Entry
    {
        public string Key { get; set; }
        public string Hash { get; set; }

        private string _url;
        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                Hash = GetMd5Hash(value);
            }
        }

        public void CreateKey()
        {
            Key = RandomString(6);
        }

        // This key generation is not failsafe for production
        private readonly Random _rng = new Random();
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private string RandomString(int size)
        {
            var buffer = new char[size];

            for (var i = 0; i < size; i++)
            {
                buffer[i] = Chars[_rng.Next(Chars.Length)];
            }
            return new string(buffer);
        }

        private static string GetMd5Hash(string value)
        {
            var md5 = MD5.Create();
            var textToHash = Encoding.ASCII.GetBytes(value);
            var result = md5.ComputeHash(textToHash);

            return BitConverter.ToString(result).Replace("-", "");
        }
    }
}
