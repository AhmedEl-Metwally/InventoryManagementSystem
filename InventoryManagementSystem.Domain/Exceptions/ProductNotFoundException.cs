namespace InventoryManagementSystem.Domain.Exceptions
{
    public sealed class ProductNotFoundException(int Id) : Exception($"Product with Id {Id} was not found.")
    {
    }
}
