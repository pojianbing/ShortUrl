using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShortUrl.Common.Cache
{
    public  static class NullDistributedCacheExtensions
    {
        public static IServiceCollection AddDistributedNullCache(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException("services");
            }
            ServiceCollectionDescriptorExtensions.TryAdd(services, ServiceDescriptor.Singleton<IDistributedCache, NullDistributedCache>());
            return services;
        }
    }
}
