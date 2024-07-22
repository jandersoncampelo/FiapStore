using AutoMapper;
using FiapStore.Application.Contracts.Customers;
using FiapStore.Application.Exceptions;
using FiapStore.Domain.Customers;

namespace FiapStore.Application.Services;

public class CustomerAppService : ICustomerAppService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerAppService(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<CustomerDto> CreateAsync(CustomerCreateDto customerCreateDto)
    {
        var customer = _mapper.Map<Customer>(customerCreateDto);
        await _customerRepository.AddAsync(customer);
        return _mapper.Map<CustomerDto>(customer);
    }

    public async Task DeleteAsync(long id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        if (customer == null)
        {
            throw new EntityNotFoundException(typeof(Customer), id);
        }

        await _customerRepository.DeleteAsync(customer);
    }

    public async Task<CustomerDto> GetByIdAsync(long id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        if (customer == null)
        {
            throw new EntityNotFoundException(typeof(Customer), id);
        }

        return _mapper.Map<CustomerDto>(customer);
    }

    public async Task<List<CustomerDto>> ListAsync()
    {
        var customers = await _customerRepository.ListAsync();
        return _mapper.Map<List<CustomerDto>>(customers);
    }

    public async Task<CustomerDto> UpdateAsync(long id, CustomerUpdateDto customerUpdateDto)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        if (customer == null)
        {
            throw new EntityNotFoundException(typeof(Customer), id);
        }

        _mapper.Map(customerUpdateDto, customer);
        await _customerRepository.UpdateAsync(customer);
        return _mapper.Map<CustomerDto>(customer);
    }
}
