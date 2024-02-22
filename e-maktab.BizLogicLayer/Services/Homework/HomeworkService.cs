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

public class HomeworkService : IHomeworkService
{
    private readonly IHomeWorkRepository _repos;
    private readonly IMapper _mapper;
    public HomeworkService(IHomeWorkRepository repos, IMapper mapper)
    {
        _repos = repos;
        _mapper = mapper;
    }
    public List<HomeworkAsSelectListDto> AsSelectList()
    {
        return _repos.SelectAll().HomeworkSelectList();
    }

    public async Task<int> Create(CreateHomeworkDto dto)
    {
        var entity = _mapper.Map<Homework>(dto);
        var result = await _repos.InsertAsync(entity);
        return result.Id;
    }

    public async Task Delete(int id)
    {
        var entity = await _repos.SelectByIdAsync(id);
        await _repos.DeleteAsync(entity);
    }

    public Task<HomeworkDto> Get(int id)
    {
        throw new NotImplementedException();
    }

    public List<HomeworkDto> GetList(HomeworkListSortFilterOptions options)
    {
        var list = _repos.SelectAll().ToList();
        return _mapper.Map<List<HomeworkDto>>(list);
    }

    public async Task Update(UpdateHomeworkDto dto)
    {
        var entity = await _repos.SelectByIdAsync(dto.Id);
        await _repos.UpdateAsync(entity);
    }

    
}
