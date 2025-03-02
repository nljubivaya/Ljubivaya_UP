using System;
using System.Collections.Generic;

namespace UP_Ljubivaya.Models;

public partial class Product
{
    public int Id { get; set; }

    public int? ProductType { get; set; }

    public string? ProductName { get; set; }

    public string? Article { get; set; }

    public decimal? MinCost { get; set; }

    public string? Photo { get; set; }

    public double? Length { get; set; }

    public double? Width { get; set; }

    public double? Heigth { get; set; }

    public virtual ICollection<PartnersProduct> PartnersProducts { get; set; } = new List<PartnersProduct>();

    public virtual ProductsType? ProductTypeNavigation { get; set; }
}
