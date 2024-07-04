using FiapStore.Domain.Shared.Entities;

namespace FiapStore.Domain.Users;

public class User : Entity
{
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public ICollection<UserRole> Roles { get; set; }

    public User()
    {
        Roles = new List<UserRole>();
    }
}
