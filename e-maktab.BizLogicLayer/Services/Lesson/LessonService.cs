using AutoMapper;
using e_maktab.BizLogicLayer.Models;
using e_maktab.DataLayer.Entities;
using e_maktab.DataLayer.Repositories;


namespace e_maktab.BizLogicLayer.Services;

public class LessonService : ILessonService
{
    private readonly ILessonRepository _repos;
    private readonly IMapper _mapper;
    public readonly IUserRepository _userRepos;
    public LessonService(ILessonRepository repos, IMapper mapper, IUserRepository userRepos)
    {
        _repos = repos;
        _mapper = mapper;
        _userRepos = userRepos;
    }
    public List<LessonAsSlectListDto> AsSelectList()
    {
        return _repos.SelectAll().LessonSelectList();
    }

    public async Task<int> Create(CreateLessonDto dto)
    {
        var entity = _mapper.Map<Lesson>(dto);
        var result = await _repos.InsertAsync(entity);
        return result.Id;
    }

    public async Task Delete(int id)
    {
        var entity = await _repos.SelectByIdAsync(id);
        await _repos.DeleteAsync(entity);
    }

    public async Task<LessonDto> Get(int id)
    {
        var entity = await _repos.SelectByIdAsync(id);
        return _mapper.Map<LessonDto>(entity);  
    }

    

    public List<LessonDto> GetList(LessonListSortFilterOptions dto)
    {
        var list = _repos.SelectAll().ToList();
        return _mapper.Map<List<LessonDto>>(list);
    }
    public async Task Update(UpdateLessonDto dto)
    {
        var entity = await _repos.SelectByIdAsync(dto.Id);
        await _repos.DeleteAsync(entity);
    }

    
}
