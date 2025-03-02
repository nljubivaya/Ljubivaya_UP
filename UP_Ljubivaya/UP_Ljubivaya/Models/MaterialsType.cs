using System;
using System.Collections.Generic;

namespace UP_Ljubivaya.Models;

public partial class MaterialsType
{
    public int Id { get; set; }

    public string? MaterialType { get; set; }

    public double? Defect { get; set; }
}
