﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShortUrl.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using System.Linq;
using ShortUrl.Application.Contracts;

namespace ShortUrl.Application.HashBase.Extensions
{
    public static class ShortUrlExtensions
    {

        public static void AddShortUrl(this IServiceCollection services, Action<ShortUrlApplicationOptions> actionOptions)
        {
            var appOptions = new ShortUrlApplicationOptions();
            actionOptions(appOptions);

            services.AddDbContext<ShortUrlDbContext>(options =>
                options.UseSqlServer(appOptions.ShortUrlConnection));
            services.AddTransient(typeof(IShortIdService), typeof(DefaultShortIdService));
            services.AddTransient(typeof(IStoreService), typeof(DefaultStoreService));
            services.AddTransient(typeof(IShortUrlService), typeof(DefaultShortUrlService));

            //将Redis分布式缓存服务添加到服务中
            services.AddDistributedRedisCache(options =>
            {
                //用于连接Redis的配置  
                options.Configuration = appOptions.RedisConnection;
                //Redis实例名RedisDistributedCache
                options.InstanceName = "RedisDistributedCache";
            });
        }

        public static IApplicationBuilder ShortUrlDbAutoMigrate(this IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetRequiredService<ShortUrlDbContext>();
            if (dbContext.Database.GetPendingMigrations().Any())
            {
                dbContext.Database.Migrate(); //执行迁移
            }

            return app;
        }
    }
}
