using Enyim.Caching;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoreSerivce.Utilities
{
    public class CacheContoller
    {
        public static MemcachedClient CacheClient()
        {
             var config = new MemcachedClientConfiguration();
            config.AddServer("127.0.0.1", 11211);
            config.Protocol = MemcachedProtocol.Text;
            config.KeyTransformer = new DefaultKeyTransformer();

            MemcachedClient client = new MemcachedClient(config);
            return client;
        }
    }
}