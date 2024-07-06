using AutoMapper;
using FiapStore.Application.Contracts.Products;
using FiapStore.Application.Exceptions;
using FiapStore.Domain.Products;

namespace FiapStore.Application.Services;

public class ProductAppService : IProductAppService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductAppService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductDto> CreateAsync(ProductCreateDto productCreateDto)
    {
        var product = _mapper.Map<Product>(productCreateDto);
        await _productRepository.AddAsync(product);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> UpdateAsync(long id, ProductUpdateDto productUpdateDto)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
        {
            throw new EntityNotFoundException(typeof(Product), id);
        }

        _mapper.Map(productUpdateDto, product);
        await _productRepository.UpdateAsync(product);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task DeleteAsync(long id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
        {
            throw new EntityNotFoundException(typeof(Product), id);
        }

        await _productRepository.DeleteAsync(product);
    }

    public async Task<ProductDto> GetByIdAsync(long id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
        {
            throw new EntityNotFoundException(typeof(Product), id);
        }

        return _mapper.Map<ProductDto>(product);
    }

    public async Task<List<ProductDto>> ListAsync()
    {
        var products = await _productRepository.ListAsync();
        return _mapper.Map<List<ProductDto>>(products);
    }
}
