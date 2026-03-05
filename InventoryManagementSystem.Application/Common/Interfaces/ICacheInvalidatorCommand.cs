namespace InventoryManagementSystem.Application.Common.Interfaces
{
    public interface ICacheInvalidatorCommand
    {
        string[] CacheKey { get; }
    }
}
