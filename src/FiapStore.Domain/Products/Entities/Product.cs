using FiapStore.Common.Entities;

namespace FiapStore.Domain.Products
{
    public class Product : Entity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public required int Stock { get; set; }

        public long CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
