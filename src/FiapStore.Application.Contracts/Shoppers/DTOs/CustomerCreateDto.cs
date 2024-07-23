namespace FiapStore.Application.Contracts.Customers;

public record CustomerCreateDto(
    string Name,
    string FullName,
    string Email,
    string Password,
    string? Phone,
    string? Address,
    string? City,
    string? State,
    string? ZipCode,
    string? Country);
