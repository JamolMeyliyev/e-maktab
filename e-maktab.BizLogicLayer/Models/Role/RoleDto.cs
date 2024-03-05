using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace e_maktab.BizLogicLayer.Models.Role;

public class RoleDto
{
    public int Id { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; } 
    public bool IsAdmin { get; set; }
    public int StateId { get; set; }
    public string State { get; set; }
    [JsonIgnore]
    public List<ModuleDto> Modules { get; set; }
}
