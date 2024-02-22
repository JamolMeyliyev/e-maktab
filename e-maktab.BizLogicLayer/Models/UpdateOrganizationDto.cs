﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Models;

public class UpdateOrganizationDto
{
    public int Id { get; set; }
    public string? ShortName { get; set; } = null!;
    public string? FullName { get; set; } = null!;
    public string? Inn { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public int? StateId { get; set; }
}
