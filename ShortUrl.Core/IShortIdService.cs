using System;
using System.Collections.Generic;
using System.Text;

namespace ShortUrl.Core
{
    /// <summary>
    /// 端链接id生成器
    /// </summary>
    public interface IShortIdService
    {
        /// <summary>
        ///根据url生成短链接id
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        string Generate(string url);
    }
}
