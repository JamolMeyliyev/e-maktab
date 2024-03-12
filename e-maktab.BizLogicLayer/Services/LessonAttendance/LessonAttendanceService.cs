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
    private readonly IUserClassRepository _userClassRepos;
    public readonly IUserLessonAttendanceRepository _userLAtRepos;
    private readonly IClassRepository _classRepos;
    public LessonAttendanceService
        (ILessonRepository repos, 
        IMapper mapper,
        IUserRepository userRepos,
        IUserLessonAttendanceRepository userLessonAttendanceRepository
,
        IUserClassRepository userClassRepos,
        IClassRepository classRepository)
    {
        _repos = repos;
        _mapper = mapper;
        _userRepos = userRepos;
        _userLAtRepos = userLessonAttendanceRepository;
        _userClassRepos = userClassRepos;
        _classRepos = classRepository;
    }

    public async Task<List<UserDto>> GetLessonStudents(int id)
    {
        var lesson = await _repos.SelectByIdAsync(id);
        var classEntity = await _classRepos.SelectByIdAsync(id);
        if(classEntity== null)
        {
            throw new Exception();
        }
        var users = classEntity.UserClasses.Select(s => s.User);
        return _mapper.Map<List<UserDto>>(classEntity.UserClasses.Select( s => s.User));
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
                StateId = 1

            };
            await _userLAtRepos.InsertAsync(entity);
        }
    }

    public async Task<List<LessonDto>> GetUserLessons(int id)
    {
        var user = await _userRepos.SelectByIdAsync(id);
        var classEntity = await _classRepos.SelectByIdAsync(id);
        if (classEntity == null)
        {
            throw new Exception();
        }
        var lessons = classEntity.Lessons;
        return _mapper.Map<List<LessonDto>>(lessons);
    }
}
