using InventoryManagementSystem.Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace InventoryManagementSystem.Application.Common.Behaviors
{
    public class CacheInvalidatorBehavior<TRequest, TResponse>(IMemoryCache _memoryCache) : IPipelineBehavior<TRequest, TResponse> where TRequest : ICacheInvalidatorCommand
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var response = await next();
            foreach (var key in request.CacheKey)
                _memoryCache.Remove(key);
            return response;
          
        }
    }
}
