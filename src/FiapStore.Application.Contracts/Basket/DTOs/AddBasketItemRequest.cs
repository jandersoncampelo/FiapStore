namespace FiapStore.Application.Contracts.Basket;

public record AddBasketItemRequest(long ProductId, int Quantity);