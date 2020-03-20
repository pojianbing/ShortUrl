using System;
using System.Collections.Generic;
using System.Data.HashFunction.MurmurHash;
using System.Security.Cryptography;
using System.Text;

namespace ShortUrl.Core
{
    public class ShortUrlHelper
    {
        private static long Hash(string url)
        {
            var hashHex = MurmurHash3Factory.Instance.Create().ComputeHash(Encoding.UTF8.GetBytes(url)).AsHexString();
            return Convert.ToInt64(hashHex, 16);
        }

        public static string ToShrotId(string url)
        {
            // 1. hash转化为数值, 采用murmurhash
            var hashCode = Hash(url);

            return hashCode.ToString();
        }


    }
}
