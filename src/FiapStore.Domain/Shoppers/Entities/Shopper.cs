using FiapStore.Domain.Shared.Entities;
using FiapStore.Domain.Users;

namespace FiapStore.Domain.Shoppers
{
    public class Shopper : Entity
    {
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required User User { get; set; }
    }
}