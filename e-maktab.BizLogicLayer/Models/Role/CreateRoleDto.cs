using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Models.Role;

public class CreateRoleDto
{
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public bool IsAdmin { get; set; }
    public int StateId { get; set; }
    public List<int> Modules { get; set; }
}
