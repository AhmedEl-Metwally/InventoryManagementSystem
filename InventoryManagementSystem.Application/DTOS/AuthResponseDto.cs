namespace InventoryManagementSystem.Application.DTOS
{
    public record AuthResponseDto(string Token, DateTime ExpiresOn, string UserName, string RefreshToken);

}
