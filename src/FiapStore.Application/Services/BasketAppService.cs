using AutoMapper;
using FiapStore.Application.Contracts.Basket;
using FiapStore.Domain.Baskets;
using FiapStore.Domain.Customers;
using FiapStore.Domain.Products;
using Microsoft.Extensions.Logging;

namespace FiapStore.Application.Services;

public class BasketAppService : IBasketAppService
{
    private readonly ILogger<BasketAppService> _logger;
    private readonly IBasketRepository _basketRepository;
    private readonly IProductRepository _productRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public BasketAppService(ILogger<BasketAppService> logger, IBasketRepository basketRepository, IProductRepository productRepository, ICustomerRepository customerRepository, IMapper mapper)
    {
        _logger = logger;
        _basketRepository = basketRepository;
        _productRepository = productRepository;
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task AddItemAsync(long customerId, long productId, int quantity)
    {
        var customer = await _customerRepository.GetByIdAsync(customerId);
        if (customer == null)
        {
            _logger.LogError($"Customer with id {customerId} not found.");
            throw new ArgumentException($"Customer with id {customerId} not found.");
        }

        var product = await _productRepository.GetByIdAsync(productId);
        if (product == null)
        {
            _logger.LogError($"Product with id {productId} not found.");
            throw new ArgumentException($"Product with id {productId} not found.");
        }

        var basket = await GetOrCreateCustomerBasket(customerId);

        var basketItem = basket.Items.FirstOrDefault(i => i.ProductId == productId);
        if (basketItem == null)
        {
            basketItem = new BasketItem()
            {
                BasketId = basket.Id,
                ProductId = productId,
                Quantity = quantity
            };
            basket.Items.Add(basketItem);
        }
        else
        {
            basketItem.Quantity += quantity;
        }

        await _basketRepository.UpdateAsync(basket);
    }
    private async Task<Basket> GetOrCreateCustomerBasket(long customerId)
    {
        var basket = await _basketRepository.GetBasketAsync(customerId);
        basket ??= await _basketRepository.AddAsync(new Basket() { CustomerId = customerId });

        return basket;
    }

    public async Task ClearBasketAsync(long customerId)
    {
        var basket = await _basketRepository.GetBasketAsync(customerId);
        if (basket == null)
        {
            _logger.LogError($"Basket for customer with id {customerId} not found.");
            throw new ArgumentException($"Basket for customer with id {customerId} not found.");
        }

        await _basketRepository.DeleteAsync(basket);
    }

    public async Task RemoveItemAsync(long customerId, long productId)
    {
        var basket = await _basketRepository.GetBasketAsync(customerId);

        if (basket == null)
        {
            _logger.LogError($"Basket for customer with id {customerId} not found.");
            throw new ArgumentException($"Basket for customer with id {customerId} not found.");
        }

        var basketItem = basket.Items.FirstOrDefault(i => i.ProductId == productId);
        if (basketItem == null)
        {
            _logger.LogError($"Product with id {productId} not found in basket.");
            throw new ArgumentException($"Product with id {productId} not found in basket.");
        }

        basket.Items.Remove(basketItem);
        await _basketRepository.UpdateAsync(basket);
    }

    public async Task UpdateItemAsync(long customerId, long productId, int quantity)
    {
        var basket = await _basketRepository.GetBasketAsync(customerId);
        if (basket == null)
        {
            _logger.LogError($"Basket for customer with id {customerId} not found.");
            throw new ArgumentException($"Basket for customer with id {customerId} not found.");
        }

        var basketItem = basket.Items.FirstOrDefault(i => i.ProductId == productId);
        if (basketItem == null)
        {
            _logger.LogError($"Product with id {productId} not found in basket.");
            throw new ArgumentException($"Product with id {productId} not found in basket.");
        }

        basketItem.Quantity = quantity;
        await _basketRepository.UpdateAsync(basket);
    }

    public async Task<BasketDto> GetBasketAsync(long customerId)
    {
        var basket = await _basketRepository.GetBasketAsync(customerId);

        if (basket == null)
        {
            _logger.LogError($"Basket for customer with id {customerId} not found.");
            throw new ArgumentException($"Basket for customer with id {customerId} not found.");
        }

        return _mapper.Map<BasketDto>(basket);
    }
}
