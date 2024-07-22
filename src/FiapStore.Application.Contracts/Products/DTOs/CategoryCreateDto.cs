using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiapStore.Application.Contracts.Products.DTOs
{
    public record CategoryCreateDto(string Name, string Description);
}
