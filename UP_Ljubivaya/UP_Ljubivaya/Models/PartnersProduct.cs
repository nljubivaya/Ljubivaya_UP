using System;
using System.Collections.Generic;

namespace UP_Ljubivaya.Models;

public partial class PartnersProduct
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int? PartnerId { get; set; }

    public int? Quantity { get; set; }

    public DateOnly? Date { get; set; }

    public virtual Partner? Partner { get; set; }

    public virtual Product? Product { get; set; }
}
