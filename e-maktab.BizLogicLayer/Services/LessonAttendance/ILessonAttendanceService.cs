using e_maktab.BizLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Services;

public interface ILessonAttendanceService
{
    Task<List<UserDto>> GetLessonStudents(int id);
    Task<List<LessonDto>> GetUserLessons(int id);
    Task SaveAttendanceByLesson(CreateLessonAttendance dto);
}
