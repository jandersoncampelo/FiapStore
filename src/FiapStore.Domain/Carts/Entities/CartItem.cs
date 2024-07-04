﻿using FiapStore.Domain.Products;
using FiapStore.Domain.Shared.Entities;

namespace FiapStore.Domain.Carts;

public class CartItem : Entity
{
    public required Product Product { get; set; }
    public required int Quantity { get; set; }
    public required decimal Price { get; set; }
    public required decimal Total { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
