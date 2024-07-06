using AutoMapper;
using FiapStore.Application.Contracts.Shoppers;
using FiapStore.Application.Exceptions;
using FiapStore.Domain.Shoppers;

namespace FiapStore.Application.Services;

public class ShopperAppService : IShopperAppService
{
    private readonly IShopperRepository _shopperRepository;
    private readonly IMapper _mapper;

    public ShopperAppService(IShopperRepository shopperRepository, IMapper mapper)
    {
        _shopperRepository = shopperRepository;
        _mapper = mapper;
    }

    public async Task<ShopperDto> CreateAsync(ShopperCreateDto shopperCreateDto)
    {
        var shopper = _mapper.Map<Shopper>(shopperCreateDto);
        await _shopperRepository.AddAsync(shopper);
        return _mapper.Map<ShopperDto>(shopper);
    }

    public async Task DeleteAsync(long id)
    {
        var shopper = await _shopperRepository.GetByIdAsync(id);
        if (shopper == null)
        {
            throw new EntityNotFoundException(typeof(Shopper), id);
        }

        await _shopperRepository.DeleteAsync(shopper);
    }

    public async Task<ShopperDto> GetByIdAsync(long id)
    {
        var shopper = await _shopperRepository.GetByIdAsync(id);
        if (shopper == null)
        {
            throw new EntityNotFoundException(typeof(Shopper), id);
        }

        return _mapper.Map<ShopperDto>(shopper);
    }

    public async Task<List<ShopperDto>> ListAsync()
    {
        var shoppers = await _shopperRepository.ListAsync();
        return _mapper.Map<List<ShopperDto>>(shoppers);
    }

    public async Task<ShopperDto> UpdateAsync(long id, ShopperUpdateDto shopperUpdateDto)
    {
        var shopper = await _shopperRepository.GetByIdAsync(id);
        if (shopper == null)
        {
            throw new EntityNotFoundException(typeof(Shopper), id);
        }

        _mapper.Map(shopperUpdateDto, shopper);
        await _shopperRepository.UpdateAsync(shopper);
        return _mapper.Map<ShopperDto>(shopper);
    }
}
