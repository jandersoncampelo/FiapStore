namespace FiapStore.Application.Contracts.Customers;

public record CustomerUpdateDto(
    string Name,
    string Email,
    string? Phone,
    string? Address,
    string? City,
    string? State,
    string? ZipCode,
    string? Country);
