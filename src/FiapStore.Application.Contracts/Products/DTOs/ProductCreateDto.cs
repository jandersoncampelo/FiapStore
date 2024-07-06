namespace FiapStore.Application.Contracts.Products;

public record ProductCreateDto(
    string Name,
    string Description,
    decimal Price,
    int Stock,
    long CategoryId)
{
}
