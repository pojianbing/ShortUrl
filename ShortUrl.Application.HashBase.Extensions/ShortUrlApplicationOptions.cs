using System;
using System.Collections.Generic;
using System.Text;
using static ShortUrl.Application.Contracts.GlobalConfig;

namespace ShortUrl.Application.HashBase.Extensions
{
    public class ShortUrlApplicationOptions
    {
        /// <summary>
        /// 数据库连接
        /// </summary>
        public string ShortUrlConnection { get; set; } = "ShortUrlConnection";

        /// <summary>
        /// redis连接
        /// </summary>
        public string RedisConnection { get; set; } = "localhost:6379";

        /// <summary>
        /// 缓存类型
        /// </summary>
        public CacheType CacheType { get; set; } = CacheType.Memory;
    }
}
