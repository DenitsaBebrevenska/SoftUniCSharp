﻿namespace Invoices.Data.Models;
public class ProductClient
{
    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public int ClientId { get; set; }

    public virtual Client Client { get; set; } = null!;
}
