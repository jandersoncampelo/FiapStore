using FiapStore.Common.Entities;

namespace FiapStore.Domain.Products;

public class Category : Entity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public List<Product> Products { get; set; }

    public Category()
    {
        Products = new List<Product>();
    }
}
