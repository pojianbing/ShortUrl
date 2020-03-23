using Microsoft.EntityFrameworkCore;
using ShortUrl.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShortUrl.EntityFrameworkCore
{
    /// <summary>
    /// 短链接数据库上下文
    /// </summary>
    public class ShortUrlDbContext : DbContext
    {
        public DbSet<ShortUrlMap> ShortUrlMaps { get; set; }

        public ShortUrlDbContext(DbContextOptions<ShortUrlDbContext> options)
          : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ShortUrlMap>(b =>
            {
                b.HasIndex(g => g.ShortId).IsUnique();
            });
        }
    }
}
