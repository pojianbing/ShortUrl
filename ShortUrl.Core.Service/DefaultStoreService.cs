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

        private void directAdd(ShortUrlMap shortUrlMap)
        {
            if (isExist(shortUrlMap.ShortId, shortUrlMap.LongUrl)) throw new UniqueException();
            Db.Add(shortUrlMap);
        }

        private bool isExist(string shortId, string longUrl)
        {
            return Db.Exists(e => e.ShortId == shortId && e.LongUrl == longUrl);
        }

        /// <summary>
        /// 增加短长链接映射
        /// </summary>
        /// <param name="shortUrlMap"></param>
        public void Add(ShortUrlMap shortUrlMap)
        {
            try
            {
                directAdd(shortUrlMap);
            }
            catch (UniqueException)
            {
                // 长链接不能存在，则解决冲突
                if (!isExist(shortUrlMap.ShortId, shortUrlMap.LongUrl))
                {
                    // 长链接，追加自定义字符串后重新添加
                    shortUrlMap.LongUrl += "[DUPLICATE]";
                    this.Add(shortUrlMap);
                }
            }
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
    }

    public class UniqueException : Exception
    { 
        
    }
}
