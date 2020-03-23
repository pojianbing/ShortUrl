using System;
using System.Collections.Generic;
using System.Text;

namespace ShortUrl.Domain
{
    public class ShortUrlMap
    {
        public long Id { get; set; }
        public string ShortId { get; set; }
        public string LongUrl { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
