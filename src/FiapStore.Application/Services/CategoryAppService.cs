using AutoMapper;
using FiapStore.Application.Contracts.Products;
using FiapStore.Application.Contracts.Products.DTOs;
using FiapStore.Application.Contracts.Products.Interfaces;
using FiapStore.Application.Exceptions;
using FiapStore.Domain.Products;
using FiapStore.Domain.Products.Repositories;
using FiapStore.Infrastructure.Repositories;

namespace FiapStore.Application.Services
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryAppService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<CategoryDto> CreateAsync(CategoryCreateDto categoryCreateDto)
        {
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
            var categories = await _categoryRepository.ListAsync();
            return _mapper.Map<List<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> UpdateAsync(long id, CategoryUpdateDto categoryUpdateDto)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                throw new EntityNotFoundException(typeof(Category), id);
            }

            _mapper.Map(categoryUpdateDto, category);
            await _categoryRepository.UpdateAsync(category);
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
