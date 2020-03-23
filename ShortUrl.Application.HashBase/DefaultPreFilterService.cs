using ShortUrl.Application.Contracts;
using System.Text;

namespace ShortUrl.Application.HashBase
{
    /// <summary>
    /// 默认前置过滤服务
    /// </summary>
    public class DefaultPreFilterService : IPreFilterService
    {
        private IStoreService storeService;
        private BloomFilter.Filter<string> filter;

        public DefaultPreFilterService(IStoreService storeService)
        {
            this.storeService = storeService;
            filter = BloomFilter.FilterBuilder.Build<string>(int.MaxValue);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            storeService.QueryAllShortIds().ForEach(id =>
            {
                filter.Add(Encoding.ASCII.GetBytes(id));
            });
        }

        /// <summary>
        /// 是否包含短链接id
        /// </summary>
        /// <param name="shortId"></param>
        /// <returns></returns>
        public bool Contains(string shortId)
        {
            return false;
        }
    }
}