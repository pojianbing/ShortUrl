using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Polly;
using ShortUrl.Application.Contracts;
using ShortUrl.Domain;
using System;

namespace ShortUrl.Application.HashBase
{
    /// <summary>
    /// 短链接服务
    /// </summary>
    public class DefaultShortUrlService : IShortUrlService
    {
        /// <summary>
        /// 存储服务
        /// </summary>
        private IStoreService _storeService;

        /// <summary>
        /// 短链接id生成服务
        /// </summary>
        private IShortIdService _shortIdService;

        /// <summary>
        /// 分布式缓存
        /// </summary>
        private IDistributedCache _cache;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="storeService"></param>
        /// <param name="shortIdService"></param>
        /// <param name="preFilterService"></param>
        public DefaultShortUrlService(IStoreService storeService, IShortIdService shortIdService, IDistributedCache cache)
        {
            this._storeService = storeService;
            this._shortIdService = shortIdService;
            this._cache = cache;
        }

        /// <summary>
        ///根据url生成短链接id
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string Generate(string url)
        {
            var errorCount = 0;
            var postfix = string.Empty;
            var shortId = string.Empty;
            ShortUrlMap shortUrlMap = null;

            // 违反唯一索引异常
            Func<DbUpdateException, bool> duplicateKeyPredict = ex =>
                ex.InnerException != null &&
                ex.InnerException.Message.Contains("duplicate key");

            Policy.Handle<DbUpdateException>(duplicateKeyPredict).Retry(2).Execute(() =>
            {
                // 在违反唯一索引的情况下，判断是否真实的重复提交
                if (errorCount == 1 && _storeService.Exist(shortId, url))
                {
                    shortUrlMap = new ShortUrlMap { ShortId = shortId, LongUrl = url };
                    return;
                }
                // hash冲突
                else
                {
                    // 计数错误次数
                    errorCount++;
                    // 追加自定义后缀(首次不需要追加，所以为空)
                    url += postfix;
                    // 首次完成后，开始追加真正的后缀
                    if (string.IsNullOrWhiteSpace(postfix)) postfix = GlobalConfig.CONFLICT_POSTFIX;

                    shortId = _shortIdService.Generate(url);
                    shortUrlMap = new ShortUrlMap { ShortId = shortId, LongUrl = url };
                    _storeService.Add(shortUrlMap);
                }

            });

            return shortUrlMap.ShortId;
        }

        /// <summary>
        /// 获取长链接
        /// </summary>
        /// <param name="shortId"></param>
        /// <returns></returns>
        public string GetLongUrl(string shortId)
        {
            // 先从缓存取
            var url = _cache.GetString(shortId);
            // 取不到，则从db取
            if (string.IsNullOrWhiteSpace(url))
            {
                url = _storeService.GetShortUrl(shortId);
                _cache.SetString(shortId, url);
            }
            // 去除自定义后缀
            url = url ?? string.Empty;
            url = url.Replace(GlobalConfig.CONFLICT_POSTFIX, "");
            return url;
        }
    }
}