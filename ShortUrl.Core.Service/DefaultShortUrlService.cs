
using ShortUrl.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShortUrl.Service
{
    /// <summary>
    /// 短链接服务
    /// </summary>
    public class DefaultShortUrlService : IShortUrlService
    {
        /// <summary>
        /// 存储服务
        /// </summary>
        private IStoreService storeService { get; set; }
        /// <summary>
        /// 短链接id生成服务
        /// </summary>
        private IShortIdService shortIdService { get; set; }

        /// <summary>
        ///根据url生成短链接id
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string Generate(string url)
        {
            return string.Empty;
        }

        /// <summary>
        /// 获取长链接
        /// </summary>
        /// <param name="shortId"></param>
        /// <returns></returns>
        public string GetLongUrl(string shortId)
        {
            return string.Empty;
        }
    }
}
