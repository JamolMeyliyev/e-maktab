using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Models;

public class CreateLessonAttendance
{
    public int LessonId { get; set; }
    
    public List<InfoUserLessonAttendance> infoUsers { get; set; }
}
public class InfoUserLessonAttendance
{
    public int UserId { get; set; }
    public int AttendanceId { get; set; }
}