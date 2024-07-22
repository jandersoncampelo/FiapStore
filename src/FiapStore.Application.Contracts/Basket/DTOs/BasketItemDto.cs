namespace FiapStore.Application.Contracts.Basket;

public record BasketItemDto(
    long ProductId,
    string ProductName,
    decimal Price,
    int Quantity);