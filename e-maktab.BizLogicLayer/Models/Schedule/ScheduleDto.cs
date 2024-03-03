using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Models;

public class ScheduleDto
{
   public List<ScheduleDayDto> Days { get; set; }

}

public class ScheduleDayDto
{
    //public DateOnly Date { get; set; }
    public required string DayOfWeekName { get; set; }
    public List<LessonDto> Lessons { get; set; } = new List<LessonDto>();

}
