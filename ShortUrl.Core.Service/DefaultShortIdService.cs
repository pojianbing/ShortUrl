using ShortUrl.Common;
using ShortUrl.Core;
using System;
using System.Data.HashFunction.MurmurHash;
using System.Text;

namespace ShortUrl.Service
{
    /// <summary>
    /// 默认短链接id
    /// </summary>
    public class DefaultShortIdService : IShortIdService
    {
        #region 接口实现

        private long Hash(string url)
        {
            var bytes = Encoding.UTF8.GetBytes(url);
            var hashHex = MurmurHash3Factory.Instance.Create().ComputeHash(bytes).AsHexString();
            return Convert.ToInt64(hashHex, 16);
        }

        /// <summary>
        /// 短链接id生成器
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string Generate(string url)
        {
            var hashCode = Hash(url);
            return RadixConvert.To62Radix(hashCode);
        }

        #endregion 接口实现
    }
}