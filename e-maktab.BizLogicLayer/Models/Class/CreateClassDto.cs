using e_maktab.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Models;

public class CreateClassDto
{
    public int TeacherId { get; set; }
    public string? ShortName { get; set; }
    public string? FullName { get; set; }
    public int StateId { get; set; }
    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    public virtual ICollection<int> Users { get; set; }
}
