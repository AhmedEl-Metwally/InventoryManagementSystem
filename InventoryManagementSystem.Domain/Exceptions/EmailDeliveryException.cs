namespace InventoryManagementSystem.Domain.Exceptions
{
    public sealed class EmailDeliveryException : Exception
    {
        public EmailDeliveryException(string message) : base(message) {}
        public EmailDeliveryException(string message,Exception? innerException = null) : base(message, innerException) {}
      
    }
}
