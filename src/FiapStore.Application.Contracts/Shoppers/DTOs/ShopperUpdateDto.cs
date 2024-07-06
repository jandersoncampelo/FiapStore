namespace FiapStore.Application.Contracts.Shoppers;

public record ShopperUpdateDto(
    string Name,
    string Email,
    string? Phone,
    string? Address,
    string? City,
    string? State,
    string? ZipCode,
    string? Country)
{
}
