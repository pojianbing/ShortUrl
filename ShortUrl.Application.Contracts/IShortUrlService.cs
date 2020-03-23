using System;
using System.Collections.Generic;
using System.Text;

namespace ShortUrl.Application.Contracts
{
    /// <summary>
    /// 短链接生成器
    /// </summary>
    public interface IShortUrlService
    {
        /// <summary>
        ///根据url生成短链接id
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        string Generate(string url);

        /// <summary>
        /// 获取长链接
        /// </summary>
        /// <param name="shortId"></param>
        /// <returns></returns>
        string GetLongUrl(string shortId);
    }
}
