using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Models;

public class ModuleDto
{
    public int Id { get; set; }
    public string ShortName { get; set; } = null!;
    public int StateId { get; set; }
}
