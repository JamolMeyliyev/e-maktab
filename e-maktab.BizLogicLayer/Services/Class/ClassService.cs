using AutoMapper;
using e_maktab.BizLogicLayer.Models;
using e_maktab.BizLogicLayer.Models.Science;
using e_maktab.DataLayer;
using e_maktab.DataLayer.Context;
using e_maktab.DataLayer.Entities;
using e_maktab.DataLayer.Repositories;


namespace e_maktab.BizLogicLayer.Services;

public class ClassService : IClassService
{
    private readonly IClassRepository _repos;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepos;
    private readonly IUserClassRepository _userClassRepos;
    private readonly ITeacherRepository _teacherRepos;
    private readonly EMaktabContext _context;
    
    public ClassService(IClassRepository repos, IMapper mapper,
        IUserRepository userRepos, IUserClassRepository userClassRepos,
        ITeacherRepository teacherRepos,EMaktabContext context)
    {
        _repos = repos;
        _mapper = mapper;
        _userRepos = userRepos;
        _userClassRepos = userClassRepos;
        _teacherRepos = teacherRepos;
        _context = context;
        
    }

    public async Task<int> AddUser(int classId, int userId)
    {


        var user = await _userRepos.SelectByIdAsync(userId);
        if (user is null)
        {
            throw new Exception("User not found");
        }
        
        if (user.IsTeacher)
        {
            throw new Exception("You can't add to Class,because He/She is Teacher");
        }
        var classEntity = await _repos.SelectByIdAsync(classId);
        if (classEntity is null)
        {
            throw new Exception("Class not found");
        }

        if (_context.UserClasses.Any(s => s.ClassId == classEntity.Id && s.UserId == user.Id))
        {
            throw new Exception(" Already added");
        }
        
        var userClass = new UserClass()
        {
            UserId = user.Id,
            ClassId = classEntity.Id
        };
        var entity = await _userClassRepos.InsertAsync(userClass);
        return entity.Id;
    }

    public List<ClassAsSelectListDto> AsSelectList()
    {
        return _repos.SelectAll().ClassSelectList();
    }

    public async Task<int> Create(CreateClassDto dto)
    {
        var entity = _mapper.Map<Class>(dto);
        var result = await _repos.InsertAsync(entity);
        return result.Id;
    }

    public async Task Delete(int id)
    {
        var entity = await _repos.SelectByIdAsync(id);
        await _repos.DeleteAsync(entity);
    }

    public async Task<ClassDto> Get(int id)
    {
        var entity = await _repos.SelectByIdAsync(id);
        return _mapper.Map<ClassDto>(entity);
    }

    public List<ClassDto> GetList(ClassListSortFilterOptions dto)
    {
        var list = _repos.SelectAll().ToList();
        return _mapper.Map<List<ClassDto>>(list);
    }

    public async Task Update(UpdateClassDto dto)
    {
        var entity = await _repos.SelectByIdAsync(dto.Id);
        await _repos.UpdateAsync(entity);
    }
}
