using AutoMapper;
using e_maktab.BizLogicLayer.Models;
using e_maktab.DataLayer.Entities;
using e_maktab.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Services;

public class LessonAttendanceService : ILessonAttendanceService
{
    private readonly ILessonRepository _repos;
    private readonly IMapper _mapper;
    public readonly IUserRepository _userRepos;
    public readonly IUserLessonAttendanceRepository _userLAtRepos;
    public LessonAttendanceService(ILessonRepository repos, IMapper mapper, IUserRepository userRepos,IUserLessonAttendanceRepository userLessonAttendanceRepository )
    {
        _repos = repos;
        _mapper = mapper;
        _userRepos = userRepos;
        _userLAtRepos = userLessonAttendanceRepository;
    }
    
    public async Task<List<UserDto>> GetLessonStudents(int id)
    {
        var lesson = await _repos.SelectByIdAsync(id);
        var users = _userRepos.SelectAll().Where(s => s.ClassId == lesson.ClassId).ToList();
        return _mapper.Map<List<UserDto>>(users);
    }

    public async Task SaveAttendanceByLesson(CreateLessonAttendance dto)
    {
        foreach(var at in dto.infoUsers)
        {
            var entity = new UserLessonAttendance()
            {
                LessonId = dto.LessonId,
                AttendanceId = at.AttendanceId,
                UserId = at.UserId,

            };
            await _userLAtRepos.InsertAsync(entity);
        }
    }

    public async Task<List<LessonDto>> GetUserLessons(int id)
    {
        var user = await _userRepos.SelectByIdAsync(id);
        var lessons = _repos.SelectAll().Where(s => s.ClassId== user.ClassId).ToList();
        return _mapper.Map<List<LessonDto>>(lessons);
    }
}
