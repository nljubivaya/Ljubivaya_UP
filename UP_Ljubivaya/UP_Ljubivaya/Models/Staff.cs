using System;
using System.Collections.Generic;

namespace UP_Ljubivaya.Models;

public partial class Staff
{
    public int Id { get; set; }

    public string? Fio { get; set; }

    public DateOnly? DateBirth { get; set; }

    public string? Passport { get; set; }

    public string? BankDetails { get; set; }

    public string? Family { get; set; }

    public string? HealthStatus { get; set; }
}
