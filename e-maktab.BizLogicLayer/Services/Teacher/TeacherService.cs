using AutoMapper;
using e_maktab.BizLogicLayer.Models;
using e_maktab.BizLogicLayer.Services;
using e_maktab.DataLayer.Entities;
using e_maktab.DataLayer.Repositories;


namespace e_maktab.BizLogicLayer.Service;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _repos;
    private readonly IMapper _mapper;
    public TeacherService(ITeacherRepository repos, IMapper mapper)
    {
        _repos = repos;
        _mapper = mapper;
    }
    public List<TeacherAsSelectListDto> AsSelectList()
    {
       return _repos.SelectAll().TeacherSelectList();
    }

    public async Task<int> Create(CreateTeacherDto dto)
    {
        var entity = _mapper.Map<Teacher>(dto);
        var result = await _repos.InsertAsync(entity);
        return result.Id;
    }

    public async Task Delete(int id)
    {
        var entity = await _repos.SelectByIdAsync(id);
        await _repos.DeleteAsync(entity);
    }

    public List<TeacherDto> GetList(TeacherListSortFilterOptions options)
    {
        var list = _repos.SelectAll().ToList();
        return _mapper.Map<List<TeacherDto>>(list);
    }

    public async Task Update(UpdateTeacherDto dto)
    {
        var entity = await _repos.SelectByIdAsync(dto.Id);
        await _repos.UpdateAsync(entity);
    }
}
