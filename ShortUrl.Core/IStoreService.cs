using ShortUrl.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShortUrl.Core
{
    /// <summary>
    /// 存储服务
    /// </summary>
    public interface IStoreService
    {
        /// <summary>
        /// 增加短长链接映射
        /// </summary>
        /// <param name="shortUrlMap"></param>
        void Add(ShortUrlMap shortUrlMap);

        /// <summary>
        /// 获取短链接
        /// </summary>
        /// <param name="shortId"></param>
        /// <returns></returns>
        string GetShortUrl(string shortId);
    }
}
