namespace FiapStore.Application.Contracts.Products;

public record ProductDto(
    long Id,
    string Name,
    string Description,
    decimal Price,
    int Stock,
    long CategoryId,
    string CategoryName)
{
}