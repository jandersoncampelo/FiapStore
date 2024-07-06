using FiapStore.Common.Entities;

namespace FiapStore.Domain.Products
{
    public class Product : Entity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
    }
}
