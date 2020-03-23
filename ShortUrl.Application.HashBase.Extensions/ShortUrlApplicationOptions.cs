using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
