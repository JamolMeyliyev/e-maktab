using AutoMapper;
using e_maktab.BizLogicLayer.Models;
using e_maktab.BizLogicLayer.Models.Science;
using e_maktab.DataLayer.Entities;
using e_maktab.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Services;

public class ClassService : IClassService
{
    private readonly IClassRepository _repos;
    private readonly IMapper _mapper;
    public ClassService(IClassRepository repos, IMapper mapper)
    {
        _repos = repos;
        _mapper = mapper;
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
