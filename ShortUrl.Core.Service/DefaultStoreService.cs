using Microsoft.Extensions.Logging;
using ShortUrl.Application.Contracts;
using ShortUrl.Domain;
using ShortUrl.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShortUrl.Application.HashBase
{
    /// <summary>
    /// 默认存储服务
    /// </summary>
    public class DefaultStoreService : IStoreService
    {
        private readonly ShortUrlDbContext _context;
        private readonly ILogger<DefaultStoreService> _logger;

        public DefaultStoreService(ShortUrlDbContext context, ILogger<DefaultStoreService> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="shortId">短链接id</param>
        /// <param name="longUrl">长链接</param>
        /// <returns></returns>
        public bool Exist(string shortId, string longUrl)
        {
            return _context.ShortUrlMaps.Count(e => e.ShortId == shortId && e.LongUrl == longUrl) > 0;
        }

        /// <summary>
        /// 增加短长链接映射
        /// </summary>
        /// <param name="shortUrlMap"></param>
        public void Add(ShortUrlMap shortUrlMap)
        {
            if (Exist(shortUrlMap.ShortId, shortUrlMap.LongUrl)) throw new UniqueException();
            _context.ShortUrlMaps.Add(shortUrlMap);
        }

        /// <summary>
        /// 获取短链接
        /// </summary>
        /// <param name="shortId"></param>
        /// <returns></returns>
        public string GetShortUrl(string shortId)
        {
            return _context.ShortUrlMaps.First(e => e.ShortId == shortId).LongUrl;
        }

        /// <summary>
        /// 查询所有的短链接id
        /// </summary>
        /// <returns></returns>
        public List<string> QueryAllShortIds()
        {
            return _context.ShortUrlMaps.Select(e => e.ShortId).ToList();
        }
    }

    public class UniqueException : Exception
    {
    }
}