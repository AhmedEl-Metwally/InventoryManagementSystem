namespace InventoryManagementSystem.Application.Common.Interfaces
{
    public interface ICacheQuery
    {
        string CacheKey { get;  }
        TimeSpan? Expiration { get;  }
    }
}
