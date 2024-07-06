namespace FiapStore.Application.Contracts.Products;

public record ProductUpdateDto(
    string Name,
    string Description,
    decimal Price,
    int Stock,
    long CategoryId)
{
}
