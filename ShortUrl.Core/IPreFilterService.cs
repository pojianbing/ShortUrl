using System;
using System.Collections.Generic;
using System.Text;

namespace ShortUrl.Application.Contracts
{
    /// <summary>
    /// 前置过滤服务
    /// </summary>
    public interface IPreFilterService
    {
        /// <summary>
        /// 初始化
        /// </summary>
        void Init();

        /// <summary>
        /// 是否包含短链接id
        /// </summary>
        /// <param name="shortId"></param>
        /// <returns></returns>
        bool Contains(string shortId);
    }
}
