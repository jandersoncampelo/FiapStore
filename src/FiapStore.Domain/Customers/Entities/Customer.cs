using FiapStore.Common.Entities;

namespace FiapStore.Domain.Customers
{
    public class Customer : Entity
    {
        public required string FullName { get; set; }
        public required string Email { get; set; }

        public Customer(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }
    }
}