using System;
using System.Collections.Generic;

namespace UP_Ljubivaya.Models;

public partial class Partner
{
    public int Id { get; set; }

    public int? PartnerType { get; set; }

    public string? CompanyName { get; set; }

    public string? FioDirector { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? UrAddress { get; set; }

    public string? Inn { get; set; }

    public int? Rating { get; set; }

    public string? Logo { get; set; }

    public string? PlaceSale { get; set; }

    public string? History { get; set; }

    public virtual PartnersType? PartnerTypeNavigation { get; set; }

    public virtual ICollection<PartnersProduct> PartnersProducts { get; set; } = new List<PartnersProduct>();
}
