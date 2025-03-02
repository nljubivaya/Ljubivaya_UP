using System;
using System.Collections.Generic;

namespace UP_Ljubivaya.Models;

public partial class ProductsType
{
    public int Id { get; set; }

    public string? ProductType { get; set; }

    public decimal? Koeff { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
