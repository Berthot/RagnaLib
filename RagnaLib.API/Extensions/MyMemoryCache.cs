using Microsoft.Extensions.Caching.Memory;

namespace RagnaLib.API.Extensions;

public class MyMemoryCache
{
    public MemoryCache Cache { get; set; }
    public MyMemoryCache()
    {
        Cache = new MemoryCache(new MemoryCacheOptions
        {
            SizeLimit = 1024
        });
    }
}