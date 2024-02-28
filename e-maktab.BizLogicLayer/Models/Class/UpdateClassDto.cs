using e_maktab.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Models;

public class UpdateClassDto
{
    public int Id { get; set; }
    public int? TeacherId { get; set; }
    public string? ShortName { get; set; }
    public string? FullName { get; set; }
    public int? StateId { get; set; }

  
}
