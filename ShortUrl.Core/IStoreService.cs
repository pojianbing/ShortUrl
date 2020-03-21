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
        /// 是否存在
        /// </summary>
        /// <param name="shortId">短链接id</param>
        /// <param name="longUrl">长链接</param>
        /// <returns></returns>
        bool Exist(string shortId, string longUrl);

        /// <summary>
        /// 增加短长链接映射
        /// </summary>
        /// <param name="shortUrlMap"></param>
        void Add(ShortUrlMap shortUrlMap);

        /// <summary>
        /// 获取短链接
        /// </summary>
        /// <param name="shortId">短链接id</param>
        /// <returns></returns>
        string GetShortUrl(string shortId);

        /// <summary>
        /// 查询所有的短链接id
        /// </summary>
        /// <returns></returns>
        List<string> QueryAllShortIds();
    }
}
