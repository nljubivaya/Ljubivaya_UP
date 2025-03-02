using System;
using System.Collections.Generic;

namespace UP_Ljubivaya.Models;

public partial class PartnersType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Partner> Partners { get; set; } = new List<Partner>();
}
