namespace FiapStore.Application.Contracts.Basket;

public record BasketDto(
    long CustomerId,
    List<BasketItemDto> Items);
