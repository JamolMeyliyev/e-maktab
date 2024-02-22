using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Models;
public class OrganizationAsSelectListDto 
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string? Inn { get; set; }
    public int StateId { get; set; }
}
