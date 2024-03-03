using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Models.Science;

public class UpdateScienceDto
{
    public int Id { get; set; }
    public string? ShortName { get; set; } 
    public string? FullName { get; set; } 
    public int? StateId { get; set; }
}
