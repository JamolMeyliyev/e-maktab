using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Models;

public class UserLessonAttendanceDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int AttendanceId { get; set; }
    public int LessonId { get; set; }
    public int StateId { get; set; }
}
