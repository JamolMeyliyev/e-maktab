using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Models;

public class UpdateLessonDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? ClassId { get; set; }
    public int? StateId { get; set; }
    public int? ScienceId { get; set; }
    public int? TeacherId { get; set; }
    public DateOnly? Day { get; set; }
    public TimeOnly? StartTime { get; set; }
}
