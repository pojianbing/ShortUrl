using ShortUrl.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ShortUrl.Core;

namespace ShortUrl.Service
{
    /// <summary>
    /// 默认存储服务
    /// </summary>
    public class DefaultStoreService : IStoreService
    {
        private List<ShortUrlMap> Db = new List<ShortUrlMap>();

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="shortId">短链接id</param>
        /// <param name="longUrl">长链接</param>
        /// <returns></returns>
        public bool Exist(string shortId, string longUrl)
        {
            return Db.Exists(e => e.ShortId == shortId && e.LongUrl == longUrl);
        }

        /// <summary>
        /// 增加短长链接映射
        /// </summary>
        /// <param name="shortUrlMap"></param>
        public void Add(ShortUrlMap shortUrlMap)
        {
            if (Exist(shortUrlMap.ShortId, shortUrlMap.LongUrl)) throw new UniqueException();
            Db.Add(shortUrlMap);
        }

        /// <summary>
        /// 获取短链接
        /// </summary>
        /// <param name="shortId"></param>
        /// <returns></returns>
        public string GetShortUrl(string shortId)
        {
            return Db.First(e => e.ShortId == shortId).LongUrl;
        }

        /// <summary>
        /// 查询所有的短链接id
        /// </summary>
        /// <returns></returns>
        public List<string> QueryAllShortIds()
        {
            return Db.Select(e => e.ShortId).ToList();
        }
    }

    public class UniqueException : Exception
    {

    }
}
