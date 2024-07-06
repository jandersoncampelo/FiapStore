namespace FiapStore.Application.Contracts.Shoppers;

public record ShopperCreateDto(
    string Name,
    string Email,
    string Password,
    string? Phone,
    string? Address,
    string? City,
    string? State,
    string? ZipCode,
    string? Country)
{
}
