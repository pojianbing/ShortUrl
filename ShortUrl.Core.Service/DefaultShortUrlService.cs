
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
        private IStoreService storeService;
        /// <summary>
        /// 短链接id生成服务
        /// </summary>
        private IShortIdService shortIdService;
        /// <summary>
        /// 前置过滤服务
        /// </summary>
        private IPreFilterService preFilterService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="storeService"></param>
        /// <param name="shortIdService"></param>
        /// <param name="preFilterService"></param>
        public DefaultShortUrlService(IStoreService storeService, IShortIdService shortIdService, IPreFilterService preFilterService)
        {
            this.storeService = storeService;
            this.shortIdService = shortIdService;
            this.preFilterService = preFilterService;
        }

        /// <summary>
        ///根据url生成短链接id
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string Generate(string url)
        {
            // 生成id
            var shortId = shortIdService.Generate(url);
            var shortUrlMap = new Core.DbModels.ShortUrlMap { ShortId = shortId, LongUrl = url };

            try
            {
                storeService.Add(shortUrlMap);
            }
            catch (UniqueException)
            {
                // 长链接不能存在，则解决冲突
                if (!storeService.Exist(shortUrlMap.ShortId, shortUrlMap.LongUrl))
                {
                    // 长链接，追加自定义字符串后重新添加
                    shortUrlMap.LongUrl += "[DUPLICATE]";
                    shortUrlMap.ShortId = shortIdService.Generate(shortUrlMap.LongUrl);
                    storeService.Add(shortUrlMap);
                }
            }

            return shortUrlMap.ShortId;
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
