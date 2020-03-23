using Polly;
using ShortUrl.Application.Contracts;
using ShortUrl.Domain;

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
        private IStoreService storeService;

        /// <summary>
        /// 短链接id生成服务
        /// </summary>
        private IShortIdService shortIdService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="storeService"></param>
        /// <param name="shortIdService"></param>
        /// <param name="preFilterService"></param>
        public DefaultShortUrlService(IStoreService storeService, IShortIdService shortIdService)
        {
            this.storeService = storeService;
            this.shortIdService = shortIdService;
        }

        /// <summary>
        ///根据url生成短链接id
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string Generate(string url)
        {
            ShortUrlMap shortUrlMap = null;

            var postfix = string.Empty;
            Policy.Handle<UniqueException>().Retry(2).Execute(() =>
            {
                url += postfix;
                var shortId = shortIdService.Generate(url);
                shortUrlMap = new ShortUrlMap { ShortId = shortId, LongUrl = url };
                storeService.Add(shortUrlMap);

                if (string.IsNullOrWhiteSpace(postfix)) postfix = GlobalConfig.CONFLICT_POSTFIX;
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
            return storeService.GetShortUrl(shortId);
        }
    }
}