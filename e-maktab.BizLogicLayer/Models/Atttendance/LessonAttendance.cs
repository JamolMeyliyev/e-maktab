using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Models;

public class LessonAttendance
{
    public int LessonId { get; set; }
    public List<int> ExistUserIds { get; set; }
}
