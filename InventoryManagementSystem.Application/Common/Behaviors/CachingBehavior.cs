using InventoryManagementSystem.Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace InventoryManagementSystem.Application.Common.Behaviors
{
    public class CachingBehavior<TRequest, TResponse>(IMemoryCache _memoryCache) : IPipelineBehavior<TRequest, TResponse> where TRequest : ICacheQuery
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_memoryCache.TryGetValue(request.CacheKey, out TResponse? cachedResponse))
                return cachedResponse!;
            var response = await next();
            var options = new MemoryCacheEntryOptions().SetAbsoluteExpiration(request.Expiration ?? TimeSpan.FromMinutes(5));
            _memoryCache.Set(request.CacheKey,response,options);
            return response;

        }
    }
}
