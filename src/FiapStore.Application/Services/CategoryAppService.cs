using AutoMapper;
using FiapStore.Application.Contracts.Category;
using FiapStore.Application.Contracts.Products;
using FiapStore.Application.Exceptions;
using FiapStore.Common;
using FiapStore.Domain.Products;
using Microsoft.Extensions.Logging;

namespace FiapStore.Application.Services;

public class CategoryAppService : ICategoryAppService
{
    private readonly IMapper _mapper;
    private readonly ILogger<CategoryAppService> _logger;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryAppService(IMapper mapper, ILogger<CategoryAppService> logger, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _logger = logger;
        _categoryRepository = categoryRepository;
            _mapper = mapper;
    }

    public async Task<CategoryDto> CreateAsync(CategoryCreateDto categoryCreateDto)
    {
        //var validator = new CategoryCreateValidator();
        //var validationResult = await validator.ValidateAsync(categoryCreateDto);
        //if (!validationResult.IsValid)
        //{
        //    throw new ValidationException("erro": validationResult);
        //}

        var category = _mapper.Map<Category>(categoryCreateDto);
        await _categoryRepository.AddAsync(category);
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task DeleteAsync(long id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category == null)
        {
            throw new EntityNotFoundException(typeof(Category), id);
        }

        await _categoryRepository.DeleteAsync(category);
    }

    public async Task<CategoryDto> GetByIdAsync(long id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category == null)
        {
            throw new EntityNotFoundException(typeof(Category), id);
        }

        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<List<CategoryDto>> ListAsync()
    {
        return _mapper.Map<List<CategoryDto>>(await _categoryRepository.ListAsync());
    }

    public async Task<CategoryDto> UpdateAsync(long id, CategoryUpdateDto categoryUpdateDto)
    {
        var validator = new CategoryUpdateValidator();
        var validationResult = validator.Validate(categoryUpdateDto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.ToString());
        }


        var category = await _categoryRepository.GetByIdAsync(id);
        if (category == null)
        {
            throw new EntityNotFoundException(typeof(Category), id);
        }

        category.Name = categoryUpdateDto.Name;
        category.Description = categoryUpdateDto.Description;

        await _categoryRepository.UpdateAsync(category);
        return _mapper.Map<CategoryDto>(category);
    }
}
