using FiapStore.Common.Entities;

namespace FiapStore.Domain.Shoppers
{
    public class Shopper : Entity
    {
        public required string FullName { get; set; }
        public required string Email { get; set; }
    }
}