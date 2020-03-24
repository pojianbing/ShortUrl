using System;
using System.Collections.Generic;
using System.Text;

namespace ShortUrl.Application.Contracts
{
    public class GlobalConfig
    {
        #region 常量

        /// <summary>
        /// 冲突后缀
        /// </summary>
        public const string CONFLICT_POSTFIX = "[DUPLICATE]";
        /// <summary>
        /// 缓存key
        /// </summary>
        public const string CACHE_KEY = nameof(CACHE_KEY);

        #endregion

        #region  枚举

        /// <summary>
        /// 缓存类型
        /// </summary>
        public enum CacheType
        {
            /// <summary>
            /// 没有缓存
            /// </summary>
            None = 0,
            /// <summary>
            /// 内存
            /// </summary>
            Memory = 1,
            /// <summary>
            /// redis
            /// </summary>
            Redis = 2
        }

        #endregion
    }
}
