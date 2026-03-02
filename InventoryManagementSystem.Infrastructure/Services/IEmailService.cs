namespace InventoryManagementSystem.Infrastructure.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string To, string Subject, string Body);
    }
}
