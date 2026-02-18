namespace InventoryManagementSystem.Domain.Exceptions
{
    public abstract class NotFoundException(string Message) : Exception(Message)
    {
    }
}
